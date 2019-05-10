using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class GoogleCloudCommunicator : MonoBehaviour
{
    public string apiKey;

    public delegate void GoogleCloudStatus();
    public delegate void GoogleCloudResponseDel(GoogleCloudResponse response);

    public static event GoogleCloudStatus UploadStarted;
    public static event GoogleCloudResponseDel ResponseRecieved;

    public void GetText(AudioClip audio)
    {
        if (UploadStarted != null)
            UploadStarted();

        float filenameRand = UnityEngine.Random.Range(0.0f, 10.0f);

        string filename = "testing" + filenameRand;

        //Debug.Log("Recording Stopped");

        if (!filename.ToLower().EndsWith(".wav"))
        {
            filename += ".wav";
        }

        var filePath = Path.Combine("testing/", filename);
        filePath = Path.Combine(Application.persistentDataPath, filePath);
        //Debug.Log("Created filepath string: " + filePath);

        // Make sure directory exists if user is saving to sub dir.
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        SaveWav.Save(filePath, audio); //Save a temporary Wav File
        //Debug.Log("Saving @ " + filePath);
        //Insert your API KEY here.
        string apiURL = "https://speech.googleapis.com/v1/speech:recognize?&key=" + apiKey;
        string Response;

        //Debug.Log("Uploading " + filePath);
        Response = HttpUploadFile(apiURL, filePath, "file", "audio/wav; rate=44100");
        //Debug.Log(Response);

        GoogleCloudResponse parsedResponse = JsonUtility.FromJson<GoogleCloudResponse>(Response);
        //Debug.Log(parsedResponse);
        try
        {
            if(ResponseRecieved != null)
            ResponseRecieved(parsedResponse);
        }
        catch(NullReferenceException e){}

        //goAudioSource.Play(); //Playback the recorded audio

        File.Delete(filePath); //Delete the Temporary Wav file
    }

    public string HttpUploadFile(string url, string file, string paramName, string contentType)
    {

        System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
        //Debug.Log(string.Format("Uploading {0} to {1}", file, url));

        byte[] bytes = File.ReadAllBytes(file);
        string file64 = Convert.ToBase64String(bytes, Base64FormattingOptions.None);

        //Debug.Log(file64);

        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"config\": { \"languageCode\" : \"en-US\" }, \"audio\" : { \"content\" : \"" + file64 + "\"}}";

                //Debug.Log(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //Debug.Log(httpResponse);

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //Debug.Log(result);
                return result;
            }

        }
        catch (WebException ex)
        {
            var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            //Debug.Log(resp);

        }


        return "empty";

    }
}
[Serializable]
public class GoogleCloudResponse
{
    public Result[] results;
}

[Serializable]
public class Result
{
    public Alternative[] alternatives;
}

[Serializable]
public class Alternative
{
    public string transcript;
    public float confidence;
}
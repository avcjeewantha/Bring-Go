//This script is for communicating with google cloud via speech-to-text api

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
//using System.Diagnostics;
using UnityEngine.UI;

public class GoogleCloudCommunicator : MonoBehaviour
{
    public string apiKey;                                           //Get the api license key

    public delegate void GoogleCloudResponseDel(GoogleCloudResponse response);  //Delegate - GoogleCloudResponseDel
    public static event GoogleCloudResponseDel ResponseRecieved;    //Event - ResponseRecieved for the delegate - GoogleCloudResponseDel

    public void GetText(AudioClip audio)
    {

        //Stopwatch sw = new Stopwatch();
        //sw.Start();

        float filenameRand = UnityEngine.Random.Range(0.0f, 10.0f);    
        string filename = "testing" + filenameRand;                     //Creates a random file name.

        if (!filename.ToLower().EndsWith(".wav"))                       //Add the .wav extension to the file name
        {
            filename += ".wav";
        }

        var filePath = Path.Combine("testing/", filename);                  //Add the file path
        filePath = Path.Combine(Application.persistentDataPath, filePath);  //Complete the file path with application paths
        //Debug.Log("Created filepath string: " + filePath);

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));         // Make sure directory exists if user is saving to sub dir.
        SaveWav.Save(filePath, audio);                                      //Save a temporary Wav File

        string apiURL = "https://speech.googleapis.com/v1/speech:recognize?&key=" + apiKey;     //api url
        string Response;

        Response = HttpUploadFile(apiURL, filePath, "file", "audio/wav; rate=44100");   //Upload the .wav file into google cloud and take the Response as a JSON object (a string).
        //Debug.Log(Response);

        GoogleCloudResponse parsedResponse = JsonUtility.FromJson<GoogleCloudResponse>(Response);   //Convert the JSON object into a GoogleCloudResponse object.
        //Debug.Log(parsedResponse);

        try                                                             //If the record length is Zero, the exception is caught.
        {
            if (ResponseRecieved != null)
            {                               //If there is a subscriber, publish the parsedResponse.
                //sw.Stop();
                //UnityEngine.Debug.Log("time : " + sw.Elapsed);
                ResponseRecieved(parsedResponse);
            }
        }
        catch(NullReferenceException e)
        {
            UnityEngine.Debug.Log(e +" : because you have to hold the record button");
        }
        
        File.Delete(filePath); //Delete the Temporary Wav file          //Then, Delete the file path
    }



    public string HttpUploadFile(string url, string file, string paramName, string contentType)
    {

        System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
        //Debug.Log(string.Format("Uploading {0} to {1}", file, url));

        byte[] bytes = File.ReadAllBytes(file);                                 //Open the binary file and read the contents of the file into a byte array, and then close the file.
        string file64 = Convert.ToBase64String(bytes, Base64FormattingOptions.None);    // Convert the array to a base 64 sring.
        //Debug.Log(file64);

        try
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))  //Set up the web connection via google speech-to-text api to upload the file
            {
                string json = "{ \"config\": { \"languageCode\" : \"en-US\" }, \"audio\" : { \"content\" : \"" + file64 + "\"}}";  //Convert the base64 file into a JSON. 
                //Debug.Log(json);

                streamWriter.Write(json);               //Upload the json file.
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //Debug.Log(httpResponse);

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))       //Set up the web connection via google speech-to-text api to get the response
            {
                var result = streamReader.ReadToEnd();
                //Debug.Log(result);
                return result;                                                          //Return the result as a JSON
            }

        }
        catch (WebException ex)                                                         //If there is any exception while uploading and getting the response, following exception will be caught.
        {
            var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            //Debug.Log(resp);

        }

        return "empty";                                                                    //And return a string - "empty"

    }
}

//Serialization is the process of converting an object into a stream of bytes in order to store the object or transmit it to memory, a database, or a file.

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
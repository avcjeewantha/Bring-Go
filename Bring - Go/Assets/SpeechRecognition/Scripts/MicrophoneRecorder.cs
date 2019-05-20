using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneRecorder : MonoBehaviour
{
    public int RecordingLength = 5;                                     //Recording time
    private AudioClip recording;

    public void StartRecording()                                        //When clicked the record bntton, recording is started
    {
        string deviceName = GetMicrophoneName();                        
        if (deviceName == null)
            return;                                                     //If microphone is not available, nothing happens.
        //Debug.Log("Recording Started");
        recording = Microphone.Start(deviceName, false, RecordingLength, 44100);    //if available, recording is started
    }

    public void EndRecording()                                      //When mouse' click button is up, recording is ended.
    {
        //Debug.Log("Stop Recording");
        string deviceName = GetMicrophoneName();
        if (deviceName == null)
            return;                                             //If the microphone is not available, nothing happens.

        Microphone.End(deviceName);                             //If available, recording is ended and following things will be happened.

        GoogleCloudCommunicator googleCloudCommunicator = FindObjectOfType<GoogleCloudCommunicator>(); //To find the GoogleCloudCommunicator object.
        if (googleCloudCommunicator != null)
            googleCloudCommunicator.GetText(recording);         //If the above object is avilable, GetText() method is called.
    }

    private string GetMicrophoneName()                                  //Get the microphone name to check the availability
    {
        if (Microphone.devices.Length > 0)
            return Microphone.devices[0];
        return null;
    }

}
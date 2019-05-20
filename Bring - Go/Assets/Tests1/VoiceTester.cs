using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class VoiceTester : MonoBehaviour
{
    private GoogleCloudCommunicator googleCloudCommunicator;
    private MicrophoneRecorder microphoneRecorder;
    private AudioClip recording;
    
    void OnEnable()
    {
        googleCloudCommunicator = FindObjectOfType<GoogleCloudCommunicator>();
        microphoneRecorder = FindObjectOfType<MicrophoneRecorder>();

        Debug.Log("Recording Started");
        recording = Microphone.Start(Microphone.devices[0], false, 5, 44100);
        Thread.Sleep(5000);
        Microphone.End(Microphone.devices[0]);
        Debug.Log("Recording Stopped");
    }

}

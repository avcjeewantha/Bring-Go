using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneRecorder : MonoBehaviour
{
    public int RecordingLength = 2;
    private AudioClip recording;
    public void StartRecording()
    {
        string deviceName = GetMicrophoneName();
        if (deviceName == null)
            return;
        //Debug.Log("Recording Started");
        recording = Microphone.Start(deviceName, false, RecordingLength, 44100);
    }

    public void EndRecording()
    {
        //Debug.Log("Stop Recording");
        string deviceName = GetMicrophoneName();
        if (deviceName == null)
            return;

        Microphone.End(deviceName);

        GoogleCloudCommunicator googleCloudCommunicator = FindObjectOfType<GoogleCloudCommunicator>();
        if (googleCloudCommunicator != null)
            googleCloudCommunicator.GetText(recording);
    }

    private string GetMicrophoneName()
    {
        if (Microphone.devices.Length > 0)
            return Microphone.devices[0];
        return null;
    }
}
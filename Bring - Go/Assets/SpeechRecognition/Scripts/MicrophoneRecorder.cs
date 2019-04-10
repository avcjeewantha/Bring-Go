using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneRecorder : MonoBehaviour
{
    public int RecordingLength = 5;
    private AudioClip recording;
    public void StartRecording()
    {
        string deviceName = GetMicrophoneName();
        if (deviceName == null)
            return;

        recording = Microphone.Start(deviceName, false, RecordingLength, 44100);
    }

    public void EndRecording()
    {
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
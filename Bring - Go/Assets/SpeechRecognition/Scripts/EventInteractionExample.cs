using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventInteractionExample : MonoBehaviour
{
    public Text text;

    private void OnEnable()
    {
        GoogleCloudCommunicator.UploadStarted += UploadStarted;
        GoogleCloudCommunicator.ResponseRecieved += ResponseRecieved;
    }

    private void OnDisable()
    {
        GoogleCloudCommunicator.UploadStarted -= UploadStarted;
        GoogleCloudCommunicator.ResponseRecieved -= ResponseRecieved;
    }

    private void UploadStarted()
    {
        text.text = "Analysing your beautiful voice" + Environment.NewLine + ".............";
    }

    private void ResponseRecieved(GoogleCloudResponse response)
    {
        text.text = response.results[0].alternatives[0].transcript;
    }
}

//This script is the initial script which is used to create the voice recognition application.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventInteractionExample : MonoBehaviour
{
    //public Text text;

    private void OnEnable()
    {
        //GoogleCloudCommunicator.UploadStarted += UploadStarted;
        GoogleCloudCommunicator.ResponseRecieved += ResponseRecieved;       //When the script is enabled, voiceEvaluator subscribes to ResponseRecieved event.
    }

    private void OnDisable()
    {
        //GoogleCloudCommunicator.UploadStarted -= UploadStarted;
        GoogleCloudCommunicator.ResponseRecieved -= ResponseRecieved;       //When the script is disabled, voiceEvaluator unsubscribes to ResponseRecieved event.
    }

    private void ResponseRecieved(GoogleCloudResponse response)
    {
        //Debug.Log(response.results[0].alternatives[0].transcript);
        //text.text = response.results[0].alternatives[0].transcript;
    }
}

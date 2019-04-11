using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEvaluator : MonoBehaviour
{
    public string shopType;
    public string taskItem;

    public string thisShop;

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

    void Update()
    {
        shopType = TaskManager.getShopType();
        taskItem = TaskManager.getTaskItem();
    }

    private void UploadStarted()
    {
        //text.text = "Analysing your beautiful voice" + Environment.NewLine + ".............";
        //text.text = null;
    }

    private void ResponseRecieved(GoogleCloudResponse response)
    {
        //Debug.Log(response.results[0].alternatives[0].transcript);
        //text.text = response.results[0].alternatives[0].transcript;
        if(shopType  == thisShop && taskItem == response.results[0].alternatives[0].transcript)
        {
            //Debug.Log("true" + thisShop + response.results[0].alternatives[0].transcript);
            TaskManager.evaluateFromVoice(true);
        }
        else
        {
            //Debug.Log("false" + thisShop + response.results[0].alternatives[0].transcript);
            TaskManager.evaluateFromVoice(false);
        }
    }
}

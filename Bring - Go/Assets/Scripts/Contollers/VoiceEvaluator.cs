//This script is for comparing the task's item name and users word.

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
        GoogleCloudCommunicator.ResponseRecieved += ResponseRecieved;   //When the script is enabled, voiceEvaluator subscribes to ResponseRecieved event.
    }

    private void OnDisable()
    {
        GoogleCloudCommunicator.ResponseRecieved -= ResponseRecieved;   //When the script is disabled, voiceEvaluator unsubscribes to ResponseRecieved event.
    }

    void Update()                                                       
    {
        shopType = TaskManager.getShopType();
        taskItem = TaskManager.getTaskItem();
    }

    private void ResponseRecieved(GoogleCloudResponse response)
    {
        Debug.Log("You have spoken: " + response.results[0].alternatives[0].transcript);
        Debug.Log("Task: " + taskItem);

        if(shopType  == thisShop && taskItem == response.results[0].alternatives[0].transcript)     //Compare the cloud response and task and evaluate.
        {
            TaskManager.evaluateFromVoice(true);
        }
        else
        {
            TaskManager.evaluateFromVoice(false);
        }
    }
}

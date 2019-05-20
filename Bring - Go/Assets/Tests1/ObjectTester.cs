using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectTester : MonoBehaviour
{
    private GoogleCloudCommunicator googleCloudCommunicator;
    private MicrophoneRecorder microphoneRecorder;
    private Player player;

    public void createTest1()
    {      
        if (googleCloudCommunicator != null)
        {
            Debug.Log(" "+googleCloudCommunicator.GetType() + "googleCloudCommunicator created=> Test- success");
        }
        else
        {
            Debug.Log("googleCloudCommunicator Test- failed");
        }
    }

    public void createTest2()
    {
        if (microphoneRecorder != null)
        {
            Debug.Log(" " + microphoneRecorder.GetType() + "microphoneRecorder created=> Test- success");
        }
        else
        {
            Debug.Log("microphoneRecorder Test- failed");
        }
    }

    public void createTest3()
    {
        if (player != null)
        {
            Debug.Log(" " + player.GetType() + "player created=> Test- success");
        }
        else
        {
            Debug.Log("player Test- failed");
        }
    }

    void OnEnable()
    {
        googleCloudCommunicator = FindObjectOfType<GoogleCloudCommunicator>();
        createTest1();
        microphoneRecorder = FindObjectOfType<MicrophoneRecorder>();
        createTest2();
        player = FindObjectOfType<Player>();
        createTest3();
    }
}

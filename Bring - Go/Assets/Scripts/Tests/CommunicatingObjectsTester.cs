using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class CommunicatingObjectsTester
    {
        [Test]
        public void IsCommunicatorExists()
        {
            SceneManager.LoadScene("Game");
            Assert.AreEqual(GameObject.FindGameObjectsWithTag("CloudCommunication").Length, 1);
        }

        [Test]
        public void IsMicrophoneExists()
        {
            Assert.AreEqual(GameObject.FindGameObjectsWithTag("AudioRecorder").Length, 1);
        }
    }
}

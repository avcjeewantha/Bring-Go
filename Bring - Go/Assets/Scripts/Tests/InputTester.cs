using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class InputTester
    {
        [Test]
        public void IsOnePlayerObject()
        {
            SceneManager.LoadScene("Game");
            Assert.AreEqual(GameObject.FindGameObjectsWithTag("Player").Length, 1);
        }

        [Test]
        public void IsAccelerometerValueToRight()
        {
            Assert.AreEqual(Input.acceleration.x > 0.2, true);
        }

        [Test]
        public void IsAccelerometerValueToLeft()
        {
            Assert.AreEqual(Input.acceleration.x < -0.2, true);
        }

        [Test]
        public void IsAccelerometerValueToUp()
        {
            Assert.AreEqual(Input.acceleration.y > 0.2, true);
        }

        [Test]
        public void IsAccelerometerValueToDown()
        {
            Assert.AreEqual(Input.acceleration.y < -0.2, true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneTester
{

    public static IEnumerable<string> SceneTestCases
    {
        get { return new List<string> { "Menu", "Game" }; }
    }

    [UnityTest]
    public IEnumerator SceneIsValid([ValueSource("SceneTestCases")] string sceneName)
    {
        yield return LoadScene(sceneName);

        Assert.IsTrue(true);
    }

    [TearDown]
    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    private string sceneToUnload;

    private IEnumerator LoadScene(string sceneName)
    {
        sceneToUnload = sceneName;

        var loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadSceneOperation.allowSceneActivation = true;

        while (!loadSceneOperation.isDone)
            yield return null;
    }

}

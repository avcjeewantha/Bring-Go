using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{

    public static TaskManager taskManager;
    public GameObject winPanel;
    public GameObject failPanel;
    public Text score;

    public String shopType;
    public String taskItem;

    public enum Goals { Apple, Pineapple, Banana, Avocado, Orange, Mango, Blouse, Cap, Frock, Hat, Shirt, Trousers, Brinjal, Cabbage, Carrot, Cucumber, Pumpkin, Tomato};

    public Goals goal;

    public Sprite AppleSprite;
    public Sprite PineappleSprite;
    public Sprite BananaSprite;
    public Sprite AvocadoSprite;
    public Sprite OrangeSprite;
    public Sprite MangoSprite;

    public Sprite BlouseSprite;
    public Sprite CapSprite;
    public Sprite FrockSprite;
    public Sprite HatSprite;
    public Sprite ShirtSprite;
    public Sprite TrousersSprite;

    public Sprite BrinjalSprite;
    public Sprite CabbageSprite;
    public Sprite CarrotSprite;
    public Sprite CucumberSprite;
    public Sprite PumpkinSprite;
    public Sprite TomatoSprite;


    internal static void evaluate(Sprite sprite)
    {
        taskManager.evaluateObj(sprite);
    }

    private void evaluateObj(Sprite sprite)
    {
        if (GetComponent<Image>().sprite == sprite)
        {
            //Debug.Log("You're correct");
            winPanel.SetActive(true);
            PlayerPrefs.SetInt("TmpScore", (PlayerPrefs.GetInt("TmpScore", 00) + 2));
            score.text = PlayerPrefs.GetInt("TmpScore", 00).ToString();
            Start();
        }
        else
        {
            //Debug.Log("Wrong Answer");
            HighScoreScript.insertScore(PlayerPrefs.GetInt("TmpScore"));
            failPanel.SetActive(true);
        }
    }

    internal static void evaluateFromVoice(bool boolean)
    {
        taskManager.voiceEvaluateObj(boolean);
    }

    private void voiceEvaluateObj(bool boolean)
    {
        if (boolean)
        {
            //Debug.Log("You're correct");
            winPanel.SetActive(true);
            PlayerPrefs.SetInt("TmpScore", (PlayerPrefs.GetInt("TmpScore", 00) + 2));
            score.text = PlayerPrefs.GetInt("TmpScore", 00).ToString();
            Start();
        }
        else
        {
            //Debug.Log("Wrong Answer");
            HighScoreScript.insertScore(PlayerPrefs.GetInt("TmpScore"));
            failPanel.SetActive(true);
        }
    }

    void Start()
    {
        taskManager = this;
        var randomNumber = UnityEngine.Random.Range(0,18);
        
        setNewTask((Goals)Enum.ToObject(typeof(Goals), randomNumber));
    }

    public void setNewTaskObj(Goals goalID)
    {

        goal = goalID;

        if (goalID == Goals.Apple) { GetComponent<Image>().sprite = AppleSprite; shopType = "FShop"; taskItem = "apple"; }
        if (goalID == Goals.Pineapple) { GetComponent<Image>().sprite = PineappleSprite; shopType = "FShop"; taskItem = "pineapple"; }
        if (goalID == Goals.Banana) { GetComponent<Image>().sprite = BananaSprite; shopType = "FShop"; taskItem = "banana"; }
        if (goalID == Goals.Avocado) { GetComponent<Image>().sprite = AvocadoSprite; shopType = "FShop"; taskItem = "avocado"; }
        if (goalID == Goals.Orange) { GetComponent<Image>().sprite = OrangeSprite; shopType = "FShop"; taskItem = "Orange"; }
        if (goalID == Goals.Mango) { GetComponent<Image>().sprite = MangoSprite; shopType = "FShop"; taskItem = "mango"; }

        if (goalID == Goals.Blouse) { GetComponent<Image>().sprite = BlouseSprite; shopType = "CShop"; taskItem = "blouse"; }
        if (goalID == Goals.Cap) { GetComponent<Image>().sprite = CapSprite; shopType = "CShop"; taskItem = "kept"; }
        if (goalID == Goals.Frock) { GetComponent<Image>().sprite = FrockSprite; shopType = "CShop"; taskItem = "truck"; }
        if (goalID == Goals.Hat) { GetComponent<Image>().sprite = HatSprite; shopType = "CShop"; taskItem = "hat"; }
        if (goalID == Goals.Shirt) { GetComponent<Image>().sprite = ShirtSprite; shopType = "CShop"; taskItem = "shirt"; }
        if (goalID == Goals.Trousers) { GetComponent<Image>().sprite = TrousersSprite; shopType = "CShop"; taskItem = "trousers"; }

        if (goalID == Goals.Brinjal) { GetComponent<Image>().sprite = BrinjalSprite; shopType = "VShop"; taskItem = "brinjal"; }
        if (goalID == Goals.Cabbage) { GetComponent<Image>().sprite = CabbageSprite; shopType = "VShop"; taskItem = "cabbage"; }
        if (goalID == Goals.Carrot) { GetComponent<Image>().sprite = CarrotSprite; shopType = "VShop"; taskItem = "carrot"; }
        if (goalID == Goals.Cucumber) { GetComponent<Image>().sprite = CucumberSprite; shopType = "VShop"; taskItem = "cucumber"; }
        if (goalID == Goals.Pumpkin) { GetComponent<Image>().sprite = PumpkinSprite; shopType = "VShop"; taskItem = "pumpkin"; }
        if (goalID == Goals.Tomato) { GetComponent<Image>().sprite = TomatoSprite; shopType = "VShop"; taskItem = "tomato"; }


    }

    public static void setNewTask(Goals goalID)
    {
        taskManager.setNewTaskObj(goalID);
    }
    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public static String getShopType()
    {
        return taskManager.shopType;
    }

    public static String getTaskItem()
    {
        return taskManager.taskItem;
    }
}

//This script is for assigning tasks and evaluate them. 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{

    public static TaskManager taskManager;                          //Variables for visible UI objects.
    public GameObject winPanel;
    public GameObject failPanel;
    public Text score;

    public String shopType;
    public String taskItem;

                                                                    //enum for keeping items and asssigning a value to them.
    public enum Goals { Apple, Pineapple, Banana, Avocado, Orange, Mango, Blouse, Cap, Frock, Hat, Shirt, Trousers, Brinjal, Cabbage, Carrot, Cucumber, Pumpkin, Tomato};

    public Goals goal;                                              //Task

    public Sprite AppleSprite;                                      //keeps the images of tasks.
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
        if (GetComponent<Image>().sprite == sprite)                //Check whether the task is successful.
        {
            //Debug.Log("You're correct");
            winPanel.SetActive(true);
            PlayerPrefs.SetInt("TmpScore", (PlayerPrefs.GetInt("TmpScore", 00) + 2));           //Score value is increased by 2
            score.text = PlayerPrefs.GetInt("TmpScore", 00).ToString();                         //Score value is displayed.
            Start();                                                                            //Assign a new task
        }
        else
        {
            //Debug.Log("Wrong Answer");
            failPanel.SetActive(true);
            HighScoreScript.insertScore(PlayerPrefs.GetInt("TmpScore"));                       //Store the value in the database
        }
    }

    internal static void evaluateFromVoice(bool boolean)
    {
        taskManager.voiceEvaluateObj(boolean);
    }

    private void voiceEvaluateObj(bool boolean)                             //Same function as abobe but for voice recognition.
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
            failPanel.SetActive(true);
            HighScoreScript.insertScore(PlayerPrefs.GetInt("TmpScore"));    
        }
    }

    void Start()
    {
        taskManager = this;
        var randomNumber = UnityEngine.Random.Range(0,18);              //Take a random value  
        
        setNewTask((Goals)Enum.ToObject(typeof(Goals), randomNumber));  
    }

    public static void setNewTask(Goals goalID)         
    {
        taskManager.setNewTaskObj(goalID);
    }

    public void setNewTaskObj(Goals goalID)                             //set the task from selecting an item from Goals enum.
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
    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);   //When task is failed, user can restart the game.
    }

    public static String getShopType()                          //returns the shop type
    {
        return taskManager.shopType;
    }

    public static String getTaskItem()                          //Returns the task item name
    {
        return taskManager.taskItem;
    }
}

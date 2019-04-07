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

        if (goalID == Goals.Apple) GetComponent<Image>().sprite = AppleSprite;
        if (goalID == Goals.Pineapple) GetComponent<Image>().sprite = PineappleSprite;
        if (goalID == Goals.Banana) GetComponent<Image>().sprite = BananaSprite;
        if (goalID == Goals.Avocado) GetComponent<Image>().sprite = AvocadoSprite;
        if (goalID == Goals.Orange) GetComponent<Image>().sprite = OrangeSprite;
        if (goalID == Goals.Mango) GetComponent<Image>().sprite = MangoSprite;

        if (goalID == Goals.Blouse) GetComponent<Image>().sprite = BlouseSprite;
        if (goalID == Goals.Cap) GetComponent<Image>().sprite = CapSprite;
        if (goalID == Goals.Frock) GetComponent<Image>().sprite = FrockSprite;
        if (goalID == Goals.Hat) GetComponent<Image>().sprite = HatSprite;
        if (goalID == Goals.Shirt) GetComponent<Image>().sprite = ShirtSprite;
        if (goalID == Goals.Trousers) GetComponent<Image>().sprite = TrousersSprite;

        if (goalID == Goals.Brinjal) GetComponent<Image>().sprite = BrinjalSprite;
        if (goalID == Goals.Cabbage) GetComponent<Image>().sprite = CabbageSprite;
        if (goalID == Goals.Carrot) GetComponent<Image>().sprite = CarrotSprite;
        if (goalID == Goals.Cucumber) GetComponent<Image>().sprite = CucumberSprite;
        if (goalID == Goals.Pumpkin) GetComponent<Image>().sprite = PumpkinSprite;
        if (goalID == Goals.Tomato) GetComponent<Image>().sprite = TomatoSprite;


    }

    public static void setNewTask(Goals goalID)
    {
        taskManager.setNewTaskObj(goalID);
    }
    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

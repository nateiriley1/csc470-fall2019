using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreScript : MonoBehaviour
{
    GameManager gm;


    public Text money;
    private float CurrentMoney = 0;
    private float MoneyOnClick = 5;
    private float moneyPerSecond = 0.001f;
    public Text CurrentPerSecMoneyShow;
    public Text CurrentOnClickMoneyShow;

    private int score = 0;
    private string Score;
    public Text FinalScore;

    private GameObject MPS;
    private GameObject cookieClicker;

    public Image forward;
    public GameObject back;

    private float winningMoney = 10000000;
    public GameObject winningText;
    public Text winningTextfinal;

    private float temp;
    private float temp2 = 1;

    public GameObject StoreMenu;
    public GameObject FMenu;

    public GameObject goals;
    public Text moneyInGoals;

    public GameObject plant1;
    public GameObject plant2;
    public GameObject rug;
    public GameObject tvset;
    public GameObject tableset;
    public GameObject bed;


    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        temp = Time.deltaTime * temp2;

        CurrentMoney += temp + moneyPerSecond;

        CurrentPerSecMoneyShow.text = moneyPerSecond.ToString("0.000");
        CurrentOnClickMoneyShow.text = MoneyOnClick.ToString("0.00");

        money.text = CurrentMoney.ToString("0.00");

        moneyInGoals.text = "You have $" + CurrentMoney.ToString("0.00") + "/$10,000,000";

        Score = score.ToString();
        FinalScore.text = "You have " + Score + "/6 Peices of Furniture.";

        forward.fillAmount = CurrentMoney / winningMoney;

        if (CurrentMoney >= winningMoney && score >= 6)
        {
            StoreMenu.SetActive(false);
            goals.SetActive(false);
            FMenu.SetActive(false);
            temp2 = 0;
            MoneyOnClick = 0;
            moneyPerSecond = 0;
            string action = "YOU HAVE WON";
            StartCoroutine(Victory(new string[] { action, "ALL THE MONEY IN THE WORLD BELONGS TO YOU", "NOW THAT YOU HAVE THIS", "WHAT ELSE IS THERE TO GAIN?", "THATS RIGHT NOTHING, IT LOOKS LIKE WE ALL LOST OUR TIME IN THE END", "THE END!!!!! (NOW GET OUT)" }));
            Application.Quit();
        }

    }
    public void TakeActionMoney()
    {
        CurrentMoney += MoneyOnClick;
    }

    public void TakeActionMoneyMPS()
    {
        if (CurrentMoney >= 100)
        {
            CurrentMoney -= 100;
            moneyPerSecond += 0.05f;
        } 
    }
    public void TakeActionMoneyMPS2()
    {
        if (CurrentMoney >= 10000)
        {
            CurrentMoney -= 10000;
            moneyPerSecond *= 1.1f;
        }
    }
    public void TakeActionMoneyOnClick()
    {
        if (CurrentMoney >= 100)
        {
            CurrentMoney -= 100;
            MoneyOnClick += 5;

        }
    }

    public void TakeActionMoneyOnClick2()
    {
        if (CurrentMoney >= 10000)
        {
            CurrentMoney -= 10000;
            MoneyOnClick *= 1.1f;

        }
    }

    public void Goals()
    {
        StoreMenu.SetActive(false);
        goals.SetActive(true);

    }

    public void GoalsClose()
    {
        StoreMenu.SetActive(true);
        goals.SetActive(false);

    }

    public void OpenStore()
    {
        StoreMenu.SetActive(false);
        FMenu.SetActive(true);
    }

    public void CloseStore()
    {
        StoreMenu.SetActive(true);
        FMenu.SetActive(false);
    }


    public void PlacePlane1()
    {
        if (!plant1.activeSelf && CurrentMoney >= 100) 
        {

            plant1.SetActive(true);
            CurrentMoney -= 100;
            score += 1;

        }
    }

    public void PlacePlane2()
    {
        if (!plant2.activeSelf && CurrentMoney >= 1000)
        {

            plant2.SetActive(true);
            CurrentMoney -= 1000;
            score += 1;

        }
    }
    public void Rug()
    {
        if (!rug.activeSelf && CurrentMoney >= 5000)
        {

            rug.SetActive(true);
            CurrentMoney -= 5000;
            score += 1;

        }
    }

    public void TVSet()
    {
        if (!tvset.activeSelf && CurrentMoney >= 10000)
        {

            tvset.SetActive(true);
            CurrentMoney -= 10000;
            score += 1;

        }
    }

    public void TableSet()
    {
        if (!tableset.activeSelf && CurrentMoney >= 100000)
        {

            tableset.SetActive(true);
            CurrentMoney -= 100000;
            score += 1;

        }
    }
    public void Bed()
    {
        if (!bed.activeSelf && CurrentMoney >= 1000000)
        {

            bed.SetActive(true);
            CurrentMoney -= 1000000;
            score += 1;

        }
    }

    IEnumerator Victory(string[] messages)
    {
        float timePerLine = 2 * messages.Length;
        winningText.SetActive(true);
        for (int i = 0; i < messages.Length; i++)
        {
            winningTextfinal.text = messages[i];
            yield return new WaitForSeconds(timePerLine);
        }
        winningText.SetActive(false);
    }

}

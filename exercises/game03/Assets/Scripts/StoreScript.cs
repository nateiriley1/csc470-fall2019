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
    private GameObject MPS;
    private GameObject cookieClicker;
    public Image forward;
    public GameObject back;
    private float winningMoney = 100000;
    public GameObject winningText;
    public Text winningTextfinal;


    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        CurrentMoney += Time.deltaTime + moneyPerSecond;
        money.text = CurrentMoney.ToString();

        forward.fillAmount = CurrentMoney / winningMoney;

        if (CurrentMoney >= winningMoney)
        {
            MoneyOnClick = 0;
            moneyPerSecond = 0;
            string action = "MONEY!!!!!!!!!!!!!";
            StartCoroutine(Victory(new string[] { action, "I AM RICH!!!" }));

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
            moneyPerSecond += 0.5f;
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

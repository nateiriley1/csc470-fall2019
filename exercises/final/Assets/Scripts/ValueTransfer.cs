using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValueTransfer : MonoBehaviour
{
    public MainMenu mm;

    public float volumeFinalValue;
    public float volTrade;
    public float sensFinalValue;
    public float senTrade;
    public float restartSenTrade = 8;
    public float restartVolTrade = 50;
    public bool restartValueBool = false;

    void Start()
    {



    }
    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {
            GameObject gmobj = GameObject.FindWithTag("MM");

            //reference GameManager
            mm = gmobj.GetComponent<MainMenu>();

            volumeFinalValue = mm.finalVolume;
            sensFinalValue = mm.finalSens;

            volTrade = volumeFinalValue;
            senTrade = sensFinalValue;

        }
        if (senTrade != 8 && volTrade != 50)
        {
            restartValueBool = true;
            restartSenTrade = senTrade;
            restartVolTrade = volTrade;

        }
        if (restartValueBool == true)
        {
            senTrade = restartSenTrade;
            volTrade = restartVolTrade;
        }

    }
}

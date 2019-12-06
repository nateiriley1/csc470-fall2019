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
    

    private void Start()
    {

        GameObject gmobj = GameObject.FindWithTag("MM");

        //reference GameManager
        mm = gmobj.GetComponent<MainMenu>();

    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Menu")
        {

            volumeFinalValue = volTrade;
            sensFinalValue = senTrade;


        }

        volumeFinalValue = mm.finalVolume;

        sensFinalValue = mm.finalSens;

    }
}

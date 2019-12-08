using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ValueTransfer : MonoBehaviour
{
    public MainMenu mm;
    public GameManager gm;

    public float volumeFinalValue;
    public float volTrade;
    public float sensFinalValue;
    public float senTrade;
    

    void Start()
    {

        GameObject gmobj = GameObject.FindWithTag("MM");

        //reference GameManager
        mm = gmobj.GetComponent<MainMenu>();



    }
    void Update()
    {


        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {

            volumeFinalValue = mm.finalVolume;
            sensFinalValue = mm.finalSens;

            volTrade = volumeFinalValue;
            senTrade = sensFinalValue;

        }
        if (sceneName != "Menu")
        {
            GameObject gmobj = GameObject.FindWithTag("GM");

            //reference GameManager
            gm = gmobj.GetComponent<GameManager>();

            if (gm.restart == true)
            {
                Destroy(this.gameObject);
                
            }
        }

    }
}

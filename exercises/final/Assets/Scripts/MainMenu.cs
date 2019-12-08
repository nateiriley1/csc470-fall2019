using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //reference gm
    public ValueTransfer vt;
    public GameManager gm;

    //Slider Properties
    public Slider sensSlider;
    public Slider volumeSlider;
    public float senTemp = 8;
    public float volTemp = 50;
    private float volumeFloat;
    private float sensFloat;
    public Text volume;
    public Text Sens;
    public float finalSens;
    public float finalVolume;

    public bool sliderChange = false;

    void Start()
    {
        finalSens = 8;
        finalVolume = 50;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //Call the Gameobject
        GameObject gmobj = GameObject.FindWithTag("GM");

        //reference GameManager
        gm = gmobj.GetComponent<GameManager>();

        if (gm.restart == true)
        {
            //Call the Gameobject
            GameObject temp = GameObject.FindWithTag("Transfer");

            //reference GameManager
            vt = temp.GetComponent<ValueTransfer>();

            if (sceneName == "Menu" && vt.restartValueBool == false)
            {
                sensSlider.value = finalSens / 15;
                volumeSlider.value = finalVolume / 100;
            }
        }
        if (gm.restart == false)
        {
            if (sceneName == "Menu")
            {

                sensSlider.value = senTemp / 15;
                volumeSlider.value = volTemp / 100;

            }
        }
        if (sceneName != "Menu")
        {
            //putting slider values into temp values
            senTemp = vt.senTrade;
            volTemp = vt.volTrade;

            sensSlider.value = senTemp / 15;
            volumeSlider.value = volTemp/ 100;
        }
    }

    void Update()
    {


        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Menu" && sliderChange == true)
        {
            //Volume
            finalVolume = volumeFloat * 100;
            volume.text = finalVolume.ToString("0");

            //Sens
            finalSens = sensFloat * 15;
            Sens.text = finalSens.ToString("0");
        }
        if (sceneName != "Menu")
        {
            //Volume
            finalVolume = volumeFloat * 100;
            volume.text = finalVolume.ToString("0");

            //Sens
            finalSens = sensFloat * 15;
            Sens.text = finalSens.ToString("0");
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void volumeBar()
    {
        sliderChange = true;
        volumeFloat = volumeSlider.value;
    }
    public void sensBar()
    {
        sliderChange = true;
        sensFloat = sensSlider.value;
    }
}



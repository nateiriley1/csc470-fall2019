using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //reference gm
    public ValueTransfer vt;

    //Volume Slider Properties
    public Slider sensSlider;
    public Slider volumeSlider;

    //option images
    public Image sensFiller;
    public Image volumeFiller;
    private float senTemp;
    private float volTemp;

    //Volume Slider Properties
    private float volumeFloat;
    private float sensFloat;
    public Text volume;
    public Text Sens;
    public float finalSens;
    public float finalVolume;
    void Start()
    {


        //Call the Gameobject
        GameObject gmobj = GameObject.FindWithTag("Transfer");

        //reference GameManager
        vt = gmobj.GetComponent<ValueTransfer>();

        senTemp = vt.senTrade;
        volTemp = vt.volTrade;


        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName != "Menu")
        {
            sensFiller.fillAmount = senTemp / 15;
            volumeFiller.fillAmount = volTemp / 100;
        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {
            //Volume
            finalVolume = volumeFloat * 100;
            volume.text = finalSens.ToString("0");

            //Sens
            finalSens = sensFloat * 15;
            Sens.text = finalSens.ToString("0");
        }
        if (sceneName != "Menu")
        {
            //Volume
            volume.text = volTemp.ToString("0");

            //Sens
            Sens.text = senTemp.ToString("0");
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
        volumeFloat = volumeSlider.value;
    }
    public void sensBar()
    {
        sensFloat = sensSlider.value;
    }
}



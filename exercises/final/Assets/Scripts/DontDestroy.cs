using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public GameManager gm;

    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {
            //Call the Gameobject
            GameObject gmobj = GameObject.FindWithTag("GM");

            //reference GameManager
            gm = gmobj.GetComponent<GameManager>();
            if (gm.restart == true)
            {
                Destroy(this.gameObject);


            }
        }

        }
    void Awake()
    {

        DontDestroyOnLoad(this.gameObject);

    }
}

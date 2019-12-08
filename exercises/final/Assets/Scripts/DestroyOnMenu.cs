using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnMenu : MonoBehaviour
{

    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Call the Gameobject
        GameObject gmobj = GameObject.FindWithTag("GM");

        //reference GameManager
        gm = gmobj.GetComponent<GameManager>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {

            if (gm.restart == true)
            {
                Destroy(this.gameObject);

            }
        }
    }
}

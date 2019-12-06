using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //calling other scripts
    public LootDrops ld;

    //count dead enemy and display number
    public int deathCount = 0;
    public Text deathCountText;

    //loot name display
    public Text lootName;

    //damage
    public int currentDamage;

    //calling UI scenes
    public GameObject InGameUI;
    public GameObject RoundWonUI;
    public GameObject NextLevelUI;
    public GameObject DeadScreen;
    public GameObject OptionsMenu;


    //calling cameras
    public GameObject Character;
    public GameObject ItemDisplay;

    //display weapons
    public GameObject shotgun;
    public GameObject m4;

    //count number of enemies
    GameObject[] enemyArray;
    public int enemyCount;

    //stop shooting
    public bool allowFireFinal = true;

    //pause actions
    public bool pause = false;
    public bool pauseLeave = false;

    //check if player died
    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {

        //array of enemies
        enemyArray = GameObject.FindGameObjectsWithTag("BadGuy");

        //count the array
        enemyCount = enemyArray.Length;

    }

    // Update is called once per frame
    void Update()
    {

        //Death count, when above number of enemies on floor give loot
        deathCountText.text = enemyCount.ToString("0") + " Remaining";
        if (isDead == true)
        {

            //let camera free to fire
            Cursor.lockState = CursorLockMode.None;

            //stop all shooting
            allowFireFinal = false;

            //switch to death screen
            InGameUI.SetActive(false);
            DeadScreen.SetActive(true);

        }
        if (Input.GetKeyDown("escape") && pause == false)
        {

            //switch ui
            OptionsMenu.SetActive(true);
            InGameUI.SetActive(false);
            
            //pause switch
            allowFireFinal = false;
            pause = true;

            //pause leave
            StartCoroutine(PauseLeave());
        }
        if (pauseLeave == true && Input.GetKeyDown("escape"))
        {

            //switch ui
            InGameUI.SetActive(true);
            OptionsMenu.SetActive(false);

            //switch back pauses
            allowFireFinal = true;
            pause = false;

            //pause leave switched off
            pauseLeave = false;
            
        }
    }
    public void roundEnd()
    {

        //load random weapon
        ld.randomDrop();

        //let camera free to fire
        Cursor.lockState = CursorLockMode.None;

        //switch ui
        InGameUI.SetActive(false);
        RoundWonUI.SetActive(true);

        //say loot name
        lootName.text = "Do you want the " + ld.currentWeaponName + "?";

        //switch camera to display loot
        Character.SetActive(false);
        ItemDisplay.SetActive(true);

        //stop shooting
        allowFireFinal = false;


    }

    //Take the loot
    public void TakeActionLoot()
    {
        //switch UI
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(true);

        //switch back cameras so no errors
        Character.SetActive(true);
        ItemDisplay.SetActive(false);

        //switch to random gun
        ld.switchGuns();
        

    }
    //Don't take loot
    public void TakeActionLootDeny()
    {
        //switch UI
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(true);

        //switch back cameras so no errors
        Character.SetActive(true);
        ItemDisplay.SetActive(false);
    }
    public void TakeActionLevel()
    {
        allowFireFinal = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        InGameUI.SetActive(true);
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(false);
        DeadScreen.SetActive(false);
    }

    //Restart Game
    public void TakeActionRestart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);

    }

    public void TakeActionBack()
    {
        
        //switch ui
        InGameUI.SetActive(true);
        OptionsMenu.SetActive(false);

        //switch back pauses
        allowFireFinal = true;
        pause = false;

        //pause leave switched off
        pauseLeave = false;
    }

    //Quit Level
    public void TakeActionQuit()
    {
        Application.Quit();
    }

    IEnumerator PauseLeave()
    {
        // wait a second and then ask for escape
        pauseLeave = false;
        yield return new WaitForSeconds(0.2f);
        pauseLeave = true;

    }
}

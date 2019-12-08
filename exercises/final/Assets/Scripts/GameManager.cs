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
    public PlayerController pc;

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
    public GameObject rpg;
    public GameObject attackSpeed;

    //count number of enemies
    GameObject[] enemyArray;
    public int enemyCount;

    //stop shooting
    public bool allowFireFinal = true;
    public bool allowFireTemp = false;

    //pause actions
    public bool pause = false;
    public bool pauseLeave = false;

    //check if player died
    public bool isDead = false;
    public bool restart = false;

    //check button clicked
    public bool hitButton = false;

    //level count
    public int levelCount = 1;
    public Text level;

    //enemyShooting speed
    public float lowRange = 1;
    public float highRange = 5;

    //enemy health increase
    public float badGuyMaxHealth;

    //Enemy Damage
    public int enemyDamage = 5;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Menu" && sceneName != "tempBeginning")
        {
            level.text = "Level " + levelCount.ToString("0");
            lowRange = 1 - (levelCount * 0.1f);
            highRange = (6 - (levelCount) - (levelCount * .2f));


            //array of enemies
            enemyArray = GameObject.FindGameObjectsWithTag("BadGuy");

            //count the array
            enemyCount = enemyArray.Length;

            //Death count, when above number of enemies on floor give loot
            deathCountText.text = enemyCount.ToString("0") + " Remaining";
            if (isDead == true && restart == false)
            {
                pause = true;

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

                TakeActionBack();
            }
        }
    }
    public void roundEnd()
    {

        ld.randomDrop();
        print(ld.currentLoot.name);

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
        m4.SetActive(false);
        shotgun.SetActive(false);
        rpg.SetActive(false);
        attackSpeed.SetActive(false);
        hitButton = false;

        //switch UI
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(true);

        //move chracter back
        Character.transform.position = new Vector3(7, 2, -3);

        //switch to random gun
        ld.activateLoot();



    }
    //Don't take loot
    public void TakeActionLootDeny()
    {
        m4.SetActive(false);
        shotgun.SetActive(false);
        rpg.SetActive(false);
        attackSpeed.SetActive(false);
        hitButton = false;

        //move chracter back
        Character.transform.position = new Vector3(7, 2, -3);

        //switch UI
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(true);

    }
    public void TakeActionLevel()
    {
        allowFireTemp = true;
        //switch back cameras so no errors
        Character.SetActive(true);
        ItemDisplay.SetActive(false);
        InGameUI.SetActive(true);
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(false);
        DeadScreen.SetActive(false);
        allowFireFinal = true;
        levelCount += 1;

        enemyDamage = enemyDamage + levelCount * 2;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Restart Game
    public void TakeActionRestart()
    {
        restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - levelCount);

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

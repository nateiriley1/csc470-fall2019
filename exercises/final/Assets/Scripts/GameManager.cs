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

    //calling cameras
    public GameObject Character;
    public GameObject ItemDisplay;

    //display weapons
    public GameObject shotgun;
    public GameObject m4;

    //diable enemy's
    public GameObject enemies;


    //stop shooting
    public bool allowFireFinal = true;

    //check if player died
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

        //set deathcount to new number
        deathCount = 6;


    }

    // Update is called once per frame
    void Update()
    {
        //Death count, when above number of enemies on floor give loot
        deathCountText.text = deathCount.ToString("0") + " Remaining";
        if (isDead == true)
        {
            //disable enemies
            enemies.SetActive(false);

            //let camera free to fire
            Cursor.lockState = CursorLockMode.None;
            
            //stop all shooting
            allowFireFinal = false;
            
            //switch to death screen
            InGameUI.SetActive(false);
            DeadScreen.SetActive(true);

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

    }

    //Restart Game
    public void TakeActionRestart()
    {

        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);

    }

    //Quit Level
    public void TakeActionQuit()
    {
        Application.Quit();
    }
}

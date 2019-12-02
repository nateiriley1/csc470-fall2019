using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //calling other scripts
    public LootDrops ld;

    //count dead enemy and display number
    public int deathCount = 0;
    public Text deathCountText;

    //damage
    public int currentDamage;

    //calling UI scenes
    public GameObject InGameUI;
    public GameObject RoundWonUI;
    public GameObject NextLevelUI;

    //stop shooting
    public bool allowFireFinal = true;

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
        if (deathCount <= 5)
        {
            //Display weapon


            //let camera free to fire
            Cursor.lockState = CursorLockMode.None;

            //switch ui
            InGameUI.SetActive(false);
            RoundWonUI.SetActive(true);

            //stop shooting
            allowFireFinal = false; 
            

        }

    }
    //take the loot
    public void TakeActionLoot()
    {
        //switch UI
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(true);

        //switch to random gun
        ld.switchGuns();
        

    }
    //don't take loot
    public void TakeActionLootDeny()
    {
        //switch UI
        RoundWonUI.SetActive(false);
        NextLevelUI.SetActive(true);
    }
    public void TakeActionLevel()
    {

    }
}

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

    //calling gameobjects
    public Image crosshair;

    // Start is called before the first frame update
    void Start()
    {

        //starting menu


    }

    // Update is called once per frame
    void Update()
    {

        //Death count, when above number of enemies on floor give loot
        deathCountText.text = deathCount.ToString("0") + "/6 Dead";
        if (deathCount >= 6)
        {

            ld.switchGuns();

        }

    }
    public void TakeActionLoot()
    {
         
    }
    public void TakeActionLevel()
    {

    }
}

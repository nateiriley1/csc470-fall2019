using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LootDrops : MonoBehaviour
{
    //Call other classes
    public GameManager gm;

    //Loot drop array, everything labeled loot
    GameObject[] lootDrop;
    public GameObject currentLoot;
    int index;
    public GameObject shotgunOn;
    public GameObject m4On;
    public GameObject rpgOn;
    public GameObject attackSpeedOn;

    //guns
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject m4;
    public GameObject rpg;
    private int currentweapon = 1;
    public string currentWeaponName;

    //stats change
    public float attackSpeedChange;
    public bool tempFireChange = false;


    void Start()
    {
    }

    void Update()
    {

        lootDrop = GameObject.FindGameObjectsWithTag("loot");
        index = Random.Range(0, lootDrop.Length);
        currentLoot = lootDrop[index];

    }

    public void randomDrop()
    {
        currentWeaponName = currentLoot.name;


        if (currentLoot.name == "shotgun")
        {

            currentweapon = 2;
            gm.shotgun.SetActive(true);
            

        }
        if (currentLoot.name == "m4")
        {
           
            currentweapon = 3;
            gm.m4.SetActive(true);
            
        }
        if (currentLoot.name == "rpg")
        {
            
            currentweapon = 4;
            gm.rpg.SetActive(true);

        }
        if (currentLoot.name == "Attack Speed")
        {
            
            currentweapon = 5;
            gm.attackSpeed.SetActive(true);
            
        }
    }

    public void activateLoot()
    { 
        if (currentweapon == 2)
        {
            shotgunOn.SetActive(false);
            pistol.SetActive(false);
            m4.SetActive(false);
            rpg.SetActive(false);
            shotgun.SetActive(true);
        }
        if (currentweapon== 3)
        {
            m4On.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            rpg.SetActive(false);
            m4.SetActive(true);
        }
        if (currentweapon == 4)
        {
            rpgOn.SetActive(false);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            m4.SetActive(false);
            rpg.SetActive(true);
        }
        if (currentweapon == 5)
        {
            tempFireChange = true;
            attackSpeedOn.SetActive(false);
            attackSpeedChange = 0.5f;
        }
    }
}

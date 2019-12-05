using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootDrops : MonoBehaviour
{
    //Call other classes
    public GameManager gm;

    //Loot drop array, everything labeled loot
    GameObject[] lootDrop;
    GameObject currentLoot;
    int index;

    //guns
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject m4;
    private int currentweapon = 1;
    public string currentWeaponName;

    void Start()
    {
    
    }

    void Update()
    {
    }

    public void randomDrop()
    {
        // Pick random gun from array from tag loot
        lootDrop = GameObject.FindGameObjectsWithTag("loot");
        index = Random.Range(0, lootDrop.Length);
        currentLoot = lootDrop[index];
        print(currentLoot.name);
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
    }

    public void switchGuns()
    { 
        if (currentweapon == 2)
        {
            pistol.SetActive(false);
            m4.SetActive(false);
            shotgun.SetActive(true);
        }
        if (currentweapon== 3)
        {
            pistol.SetActive(false);
            shotgun.SetActive(false);
            m4.SetActive(true);
        }

    }
}

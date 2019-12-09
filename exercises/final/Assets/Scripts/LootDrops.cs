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
    public PlayerController pc;

    //Loot drop array, everything labeled loot
    GameObject[] lootDrop;
    public GameObject currentLoot;
    int index;
    public GameObject shotgunOn;
    public GameObject m4On;
    public GameObject rpgOn;
    public GameObject attackSpeedOn;
    public GameObject fullHealthOn;
    public GameObject bulletSpeedOn;
    public GameObject bulletDamageOn;

    //guns
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject m4;
    public GameObject rpg;
    private int currentweapon = 1;
    public string currentWeaponName;
    public int bulletSpeedChange = 1;

    //stats change
    public float attackSpeedChange;
    public bool tempFireChange = false;
    public bool tempBulletSpeed = false;
    public int tempBulletDamageMult = 1;


    void Start()
    {
    }

    void Update()
    {

        lootDrop = GameObject.FindGameObjectsWithTag("loot");
        index = Random.Range(0, lootDrop.Length);
        currentLoot = lootDrop[index];
        //print(currentLoot.name);

    }

    public void randomDrop()
    {
        if (gm.temp == true)
        {
            randomDropArray();
        }

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
        if (currentLoot.name == "Full Health")
        {

            currentweapon = 6;
            gm.fullHealth.SetActive(true);

        }
        if (currentLoot.name == "Bullet Speed")
        {

            currentweapon = 7;
            gm.bulletSpeed.SetActive(true);

        }
        if (currentLoot.name == "Bullet Damage")
        {

            currentweapon = 8;
            gm.bulletDamage.SetActive(true);

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
        if (currentweapon == 6)
        {
            pc.currentHealth = 100f;
            fullHealthOn.SetActive(false);

        }
        if (currentweapon == 7)
        {
            tempBulletSpeed = true;
            bulletSpeedChange = 2;
            bulletSpeedOn.SetActive(false);

        }
        if (currentweapon == 8)
        {
            tempBulletDamageMult = 2;
            bulletSpeedOn.SetActive(false);

        }
    }
    void randomDropArray()
    {
        gm.temp = false;
    }
}

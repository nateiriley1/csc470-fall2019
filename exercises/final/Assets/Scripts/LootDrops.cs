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

    void Start()
    {
    
    }

    void Update()
    {
        
    }
    public void switchGuns()
    {
        // Pick random gun from array from tag loot
        lootDrop = GameObject.FindGameObjectsWithTag("loot");
        index = Random.Range(0, lootDrop.Length);
        currentLoot = lootDrop[index];
        print(currentLoot.name);

        if (currentLoot.name == "shotgun")
        {
            pistol.SetActive(false);
            shotgun.SetActive(true);
        }
        
    }
}

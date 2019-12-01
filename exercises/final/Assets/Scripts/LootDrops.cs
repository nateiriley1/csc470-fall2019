using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootDrops : MonoBehaviour
{
    //Call other classes
    public PlayerController pc;
    public GameManager gm;

    //Loot drop array, everything labeled loot
    GameObject[] lootDrop;
    GameObject currentLoot;
    int index;

    void Start()
    {
    
    }

    void Update()
    {
        // Pick random gun from array from tag loot
        if (gm.lootDrop == true)
        {
            lootDrop = GameObject.FindGameObjectsWithTag("loot");
            index = Random.Range(0, lootDrop.Length);
            currentLoot = lootDrop[index];
            print(currentLoot.name);
          
        }
    }
    public void TakeActoinSwitchLoot()
    {
        
    }
}

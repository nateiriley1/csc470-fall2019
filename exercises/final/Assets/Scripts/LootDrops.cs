using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LootDrops : MonoBehaviour
{
    public PlayerController pc;
    public GameManager gm;
    GameObject[] lootDrop;
    GameObject currentLoot;
    int index;
    public GameObject gunLocation;
    //public Text lootText;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.lootDrop == true)
        {
            lootDrop = GameObject.FindGameObjectsWithTag("loot");
            index = Random.Range(0, lootDrop.Length);
            currentLoot = lootDrop[index];
            print(currentLoot.name);
            Destroy(pc.currentWeapon);
            //currentLoot = pc.currentWeapon;

            currentLoot.transform.position = gunLocation.transform.position;
        }
    }
    public void TakeActoinSwitchLoot()
    {
        
    }
}

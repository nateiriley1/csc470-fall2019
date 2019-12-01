using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public BadGuyScript bgs;
    public int deathCount = 0;
    public Text deathCountText;
    public bool lootDrop = false;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        deathCountText.text = deathCount.ToString("0") + "/6 Dead";
        if (deathCount >= 1)
        {

            lootDrop = true;

        }

    }

}

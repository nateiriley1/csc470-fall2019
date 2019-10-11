using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    

    public Text countdownText;
    private float countdownChange = 1;
    float currentTime = 0f;
    float startingTime = 30f;
    // Start is called before the first frame update
    void Start()
    {

        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= countdownChange * Time.deltaTime;
        countdownText.text = currentTime.ToString();

        if (currentTime == 0)
        {
            countdownChange = 0;
        }


    }
}

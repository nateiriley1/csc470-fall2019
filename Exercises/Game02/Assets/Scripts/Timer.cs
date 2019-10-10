using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public CharacterHealth CH;

    public Text countdownText;
    private float countupChange = 1;
    float currentTime = 0f;
    float startingTime = 0f;
    public Text tempTime;
    // Start is called before the first frame update
    void Start()
    {

        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {

        currentTime += countupChange * Time.deltaTime;
        countdownText.text = currentTime.ToString();
        if (CH.CurrentHealth <= 0)
        {
            countupChange = 0f;

        }


    }
}

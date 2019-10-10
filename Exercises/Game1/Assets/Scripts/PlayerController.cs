using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text endGame;

    private int randomNum; 

    private Rigidbody rb;
    private int count;


    void Start()
    {

        randomNum = Random.Range(10, 20);

        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winText.text = "";

        endGame.text = "";

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);


    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if(other.transform.tag == "gor") {
            endGame.text = "His Bananas!!!";
            other.gameObject.SetActive(false);
            
        }
        if (other.transform.tag == "gor")
        {
            gameObject.SetActive(false);
        }

    }


    void SetCountText()
    {

        countText.text = "Count: " + count.ToString();
        if (count >= randomNum)
        {
            winText.text = "Your Bananas!!!";
            speed = 0;

        }

    }

}



       
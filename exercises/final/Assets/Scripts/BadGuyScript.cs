using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour
{ 


    float speed = 5f;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(Player.transform, Vector3.up);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}

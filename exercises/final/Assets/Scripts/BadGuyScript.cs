using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyScript : MonoBehaviour
{

    hunt sight;

    //float speed = 5f;

    public GameObject Player;

    private bool huntNow = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        float theDistance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            theDistance = hit.distance;
            print(theDistance + " " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.name is "Character")
            {
                pursue();
            }

        }

    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    void pursue()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        gameObject.transform.LookAt(Player.transform, Vector3.up);
    }
}

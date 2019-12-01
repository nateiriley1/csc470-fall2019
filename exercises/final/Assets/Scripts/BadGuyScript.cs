using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BadGuyScript : MonoBehaviour
{
    //Call other classes
    public ShootingScript ss;
    public GameManager gm;
    public PlayerController pc;

    //enemey waypoints array
    public GameObject[] waypoints;
    int current = 1;

    //waypoint radius
    float WPradius = 1;

    //for rotation
    float rotSpeed;

    //enemy speed random
    public float speed;

    //when looking at player chase
    hunt sight;
    public GameObject Player;
    public bool huntNow = false;
    private bool doItNow = false;

    //enemy health
    public float badGuyHealthNumber = 100f;
    //private int maxHealth = 100;

    //enemy health bar
    public Image badGuyHealth;
    public GameObject backImage;

    public GameObject gunHolder;


    void Start()
    {

        //random enemy waypoint speed
        speed = Random.Range(5, 10);
    }

    void Update()
    {
        //enemy health bar
        badGuyHealth.fillAmount = badGuyHealthNumber / 100f;

        //check for player
        RaycastHit hit;
        float theDistance;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        
        //check if player is there, if not then follow waypoints
        if (doItNow == false)
        {
            //walk to closest waypoint
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                //flip between the two
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            //go to waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
        //Check line of sight
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            //give distance
            theDistance = hit.distance;
            //print(theDistance + " " + hit.collider.gameObject.name);

            //Check if line of sight is character
            if (hit.collider.gameObject.name is "Character")
            {
                //chase the character
                chase();
            }

        }
        //used to switch from waypoints to chase
        if (doItNow == true)
        {
            pursue();
        }

        //Get charater Weapon
        


    }
    void OnTriggerEnter(Collider other)
    {
        // Check if bullet hit badguy
        if (other.gameObject.CompareTag("Bullet"))
        {
            //set bullet false
            other.gameObject.SetActive(false);

            badGuyHealthNumber -= gm.currentDamage;
            //enemy health
            if (badGuyHealthNumber <= 0)
            {
                gameObject.SetActive(false);
                gm.deathCount += 1;
            }
        }

    }

    //chase the player
    void pursue()
    {
        huntNow = true;
        transform.Translate(Vector3.forward * Time.deltaTime);
        gameObject.transform.LookAt(Player.transform, Vector3.up);

    }
    //Check if can chase
    void chase()
    {

        doItNow = true;

    }

}

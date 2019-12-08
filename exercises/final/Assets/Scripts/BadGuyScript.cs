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

    //enemey waypoints array
    public GameObject[] waypoints;
    int current = 1;

    //waypoint radius
    float WPradius = 1;

    //for rotation
    float rotSpeed;

    //enemy speed random
    public float speed;

    //enemey
    public GameObject badGuy;

    //when looking at player chase
    public bool huntNow = false;
    private bool doItNow = false;

    //enemy health
    public float badGuyHealthNumber;
    public Image badGuyHealth;
    public GameObject backImage;

    //gun holder
    public GameObject gunHolder;

    //pause actions
    public int binary_pause_choice = 1;

    void Start()
    {
        //Call the Gameobject
        GameObject gmobj = GameObject.FindWithTag("GM");
        
        //reference GameManager
        gm = gmobj.GetComponent<GameManager>();

        //random enemy waypoint speed
        speed = Random.Range(5, 10);

        gm.badGuyMaxHealth = 100 + (gm.levelCount - 1) * 50;
        badGuyHealthNumber = gm.badGuyMaxHealth;

    }

    void Update()
    {

        //Change forward speed for pause
        if (gm.pause == true)
        {

            binary_pause_choice = 0;

        }else
        {

            binary_pause_choice = 1;

        }


        //enemy health bar
        badGuyHealth.fillAmount = badGuyHealthNumber / gm.badGuyMaxHealth;

        //check for player
        RaycastHit hit;
        float theDistance;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        
        //check if player is there, if not then follow waypoints
        if (doItNow == false && gm.pause == false)
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
            badGuy.transform.LookAt(waypoints[current].transform);
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
    }
    void OnTriggerEnter(Collider other)
    {
        // Check if bullet hit badguy
        if (other.gameObject.CompareTag("Bullet"))
        {
            //set bullet false
            other.gameObject.SetActive(false);
            chase();
            badGuyHealthNumber -= gm.currentDamage;
            //enemy health
            if (badGuyHealthNumber <= 0)
            {
                gameObject.SetActive(false);
                gm.enemyCount -= 1;
                if (gm.enemyCount <= 0)
                {
                    gm.roundEnd();
                }
            }
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //set bullet false
            other.gameObject.SetActive(false);
        }

    }

    //chase the player
    void pursue()
    {
        //when finding player
        var target = GameObject.FindWithTag("LookAt");
        huntNow = true;
        transform.Translate(Vector3.forward * Time.deltaTime * binary_pause_choice);
        gameObject.transform.LookAt(target.transform, Vector3.up);

    }
    //Check if can chase
    void chase()
    {

        doItNow = true;

    }
    //enemy firerate
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BadGuyScript : MonoBehaviour
{

    public ShootingScript ss;
    public GameManager gm;
    public GameObject[] waypoints;
    int current = 1;
    float rotSpeed;
    public float speed;
    float WPradius = 1;

    hunt sight;
    public GameObject Player;
    public bool huntNow = false;
    private bool doItNow = false;

    public float currentHealth = 100f;
    //private int maxHealth = 100;

    public Image badGuyHealth;
    public GameObject backImage;



    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5, 10);
        //badGuyHealth = GameObject.Find("PlayerHealth").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        badGuyHealth.fillAmount = currentHealth / 100f;

        RaycastHit hit;
        float theDistance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (doItNow == false)
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            theDistance = hit.distance;
            //print(theDistance + " " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.name is "Character")
            {
                chase();
            }

        }
        if (doItNow == true)
        {
            pursue();
        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            currentHealth = currentHealth - ss.pistolDamage;
            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
                gm.deathCount += 1;
            }
        }

    }

    void pursue()
    {
        huntNow = true;
        transform.Translate(Vector3.forward * Time.deltaTime);
        gameObject.transform.LookAt(Player.transform, Vector3.up);

    }
    void chase()
    {

        doItNow = true;

    }

}

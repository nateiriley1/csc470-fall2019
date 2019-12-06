using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Calling Other Scripts
    public ShootingScript ss;
    public GameManager gm;

    //movement
    public float speed = 10.0f;
    private Rigidbody rb;

    //jumping
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public CapsuleCollider col;

    //player health
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public Image playerHealth;
    public GameObject backImage;
    public Text HealthBarNumbers;

    //current Weapon
    public GameObject gunHolder;

    void Start()
    {
        //movement collider
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

    }

    void Update()
    {
        if (gm.pause == false)
        {
            //mouse on screen
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //mouse on screen
            Cursor.lockState = CursorLockMode.None;
        }

        //health bar
        playerHealth.fillAmount = currentHealth / maxHealth;

        //health bar text
        HealthBarNumbers.text = currentHealth.ToString("0") + "/" + maxHealth.ToString("0");

        //movement
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        Vector3 movement = new Vector3(straffe, 0, translation);
        rb.AddForce(movement);

        

        //check to jump
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //Check to jump
    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, 
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
        
    }

    //Triggers
    void OnTriggerEnter(Collider other)
    {

        //Bullet Collider
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //set bullet false
            other.gameObject.SetActive(false);
            //shotgun
           
            currentHealth -= ss.enemyDamage;
            
            //Check if dead
            if (currentHealth <= 0)
            {
                gm.isDead = true;
            }
        }

    }

}

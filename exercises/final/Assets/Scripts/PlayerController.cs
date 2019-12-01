using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Calling Other Scripts
    public ShootingScript ss;

    //movement
    public float speed = 10.0f;
    private Rigidbody rb;

    //jumping
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public CapsuleCollider col;

    //player health
    public float currentHealth = 100f;
    //public float maxHealth = 100;
    public Image playerHealth;
    public GameObject backImage;

    //current Weapon
    public GameObject gunHolder;

    void Start()
    {
        //movement collider
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        //mouse on screen
        Cursor.lockState = CursorLockMode.Locked;
   
    }

    void Update()
    {
        //health bar
        playerHealth.fillAmount = currentHealth / 100f;

        //movement
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        Vector3 movement = new Vector3(straffe, 0, translation);
        rb.AddForce(movement);

        //escape from mouse lock
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

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
        if (other.gameObject.CompareTag("Bullet"))
        {
            //set bullet false
            other.gameObject.SetActive(false);
            //shotgun
            if (ss.shotgun)
            {
                currentHealth = currentHealth - ss.shotgunDamage;
            }
            //pistol
            if (ss.pistol)
            {
                currentHealth = currentHealth - ss.pistolDamage;
            }
            //Check if dead
            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }

    }

}

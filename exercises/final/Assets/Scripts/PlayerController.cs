using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;

    private Rigidbody rb;

    public LayerMask groundLayers;

    public float jumpForce = 7;

    public CapsuleCollider col;

    public ShootingScript ss;

    public GameObject currentWeapon;

    public float currentHealth = 100f;
    //private int maxHealth = 100;

    public Image playerHealth;
    public GameObject backImage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        //playerHealth = GameObject.Find("PlayerHealth").GetComponent<Image>();
        



    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.fillAmount = currentHealth / 100f;
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        Vector3 movement = new Vector3(straffe, 0, translation);
        rb.AddForce(movement);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, 
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
        
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
            }
        }

    }

}

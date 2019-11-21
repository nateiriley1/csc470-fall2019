using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;

    private Rigidbody rb;

    public LayerMask groundLayers;

    public float jumpForce = 7;

    public CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();


        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

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
}

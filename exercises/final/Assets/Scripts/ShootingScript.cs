using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    private bool allowFire = true;
    public ParticleSystem effectOfGun;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        

        if (allowFire == true && Input.GetKey(KeyCode.Mouse0))
        {
            effectOfGun.Emit(1);
            StartCoroutine(WaitASecond());
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            // Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 180);


            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            Destroy(Temporary_Bullet_Handler, 10.0f);

        }
        
    }
    IEnumerator WaitASecond()
    {
        allowFire = false;
        yield return new WaitForSeconds(1);
        allowFire = true;
       
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //Call Other Scripts
    public BadGuyScript BGS;
    public GameManager gm;

    //gun and bullet effects
    public GameObject Bullet_Emitter;
    public GameObject Bullet_Emitter_Shotgun;
    public GameObject Bullet;
    public GameObject Bullet2;
    public float Bullet_Forward_Force = 500f;
    public ParticleSystem effectOfGun;

    //allow fire
    public bool allowFire = true;
    public bool allowFireBadGuy = true;

    //Who is shooting
    public GameObject Character;
    public GameObject BadGuy;

    //pistol
    public GameObject pistol;
    public int pistolDamage = 20;

    //shotgun
    public GameObject shotgun;
    public int shotgunDamage = 25;

    //m4
    public GameObject m4;
    public int m4Damage = 10;

    //Enemy Damage
    public GameObject EnemyBullet;
    public int enemyDamage = 20;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if Character
        if (Character)
        {
            //shotgun
            if (shotgun)
            {
                gm.currentDamage = shotgunDamage;
                if (gm.allowFireFinal == true && allowFire == true && Input.GetKey(KeyCode.Mouse0))
                {

                    effectOfGun.Emit(1);
                    StartCoroutine(WaitASecondShotgun());
                    //bullet 1 transform
                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                    //bullet 2 transform
                    GameObject Temporary_Bullet_Handler2;
                    Temporary_Bullet_Handler2 = Instantiate(Bullet2, Bullet_Emitter_Shotgun.transform.position, Bullet_Emitter_Shotgun.transform.rotation) as GameObject;

                    //bullet 1 rigidbody
                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
                    //bullet 2 rigidbody
                    Rigidbody Temporary_RigidBody2;
                    Temporary_RigidBody2 = Temporary_Bullet_Handler2.GetComponent<Rigidbody>();

                    //bullet 1 movement
                    Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
                    //bullet 2 movement
                    Temporary_RigidBody2.AddForce(transform.forward * Bullet_Forward_Force);

                    //destroy bullets
                    Destroy(Temporary_Bullet_Handler, 10.0f);
                    Destroy(Temporary_Bullet_Handler2, 10.0f);

                }
            }
            //pistol
            
            if (pistol)
            {
                gm.currentDamage = pistolDamage;
                if (gm.allowFireFinal == true && allowFire == true && Input.GetKey(KeyCode.Mouse0))
                {
                    gm.currentDamage = pistolDamage;
                    effectOfGun.Emit(1);
                    StartCoroutine(WaitASecondPistol());

                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


                    Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                    Destroy(Temporary_Bullet_Handler, 10.0f);

                }
            }
            if (m4)
            {
                gm.currentDamage = m4Damage;
                if (gm.allowFireFinal == true && allowFire == true && Input.GetKey(KeyCode.Mouse0))
                {
                    gm.currentDamage = pistolDamage;
                    effectOfGun.Emit(1);
                    StartCoroutine(WaitASecondM4());

                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


                    Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                    Destroy(Temporary_Bullet_Handler, 10.0f);

                }
            }
        }
        //Check if bad guy
        if (BadGuy)
        {
            if (gm.allowFireFinal == true && BGS.huntNow == true && allowFireBadGuy == true)
            {
                
                effectOfGun.Emit(1);
                StartCoroutine(RandomFire());
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(EnemyBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;


                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                Destroy(Temporary_Bullet_Handler, 10.0f);

                
            }
        }
    }

    //pistol firerate
    IEnumerator WaitASecondPistol()
    {
        allowFire = false;
        yield return new WaitForSeconds(1);
        allowFire = true;
       
    }

    //shotgun firerate
    IEnumerator WaitASecondShotgun()
    {
        allowFire = false;
        yield return new WaitForSeconds(2);
        allowFire = true;

    }
    IEnumerator WaitASecondM4()
    {
        allowFire = false;
        yield return new WaitForSeconds(.2f);
        allowFire = true;

    }

    //enemy firerate
    IEnumerator RandomFire()
    {
        allowFireBadGuy = false;
        yield return new WaitForSeconds((Random.Range(1f, 5f)));
        allowFireBadGuy = true;

    }


}

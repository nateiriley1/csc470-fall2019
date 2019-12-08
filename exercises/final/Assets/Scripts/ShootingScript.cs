using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //Call Other Scripts
    public GameManager gm;
    public LootDrops ld;

    //gun and bullet effects
    public GameObject Bullet_Emitter;
    public GameObject Bullet_Emitter_Shotgun;
    public GameObject Bullet;
    public GameObject Bullet2;
    public float Bullet_Forward_Force = 500f;
    public ParticleSystem effectOfGun;

    //allow fire
    public bool allowFire = true;

    //Who is shooting
    public GameObject Character;

    //pistol
    public GameObject pistol;
    public int pistolDamage = 20;
    public float pistolAttackSpeed = 1;

    //shotgun
    public GameObject shotgun;
    public int shotgunDamage = 25;
    public float shotgunAttackSpeed = 2;

    //m4
    public GameObject m4;
    public int m4Damage = 15;
    public float m4AttackSpeed = .1f;

    //rpg
    public GameObject rpg;
    public int rpgDamage = 100;
    public float rpgAttackSpeed = 5;

    void Start()
    {

        allowFire = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (gm.allowFireTemp == true)
        {
            allowFire = true;
            gm.allowFireTemp = false;
        }

        //Check if Character
        if (Character)
        {
            //shotgun
            if (shotgun)
            {
                gm.currentDamage = shotgunDamage;
                if (ld.tempFireChange == true)
                {
                    shotgunAttackSpeed = shotgunAttackSpeed - (shotgunAttackSpeed * ld.attackSpeedChange);
                    ld.tempFireChange = false;
                }
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
                if (ld.tempFireChange == true)
                {
                    pistolAttackSpeed = pistolAttackSpeed - (pistolAttackSpeed * ld.attackSpeedChange);
                    ld.tempFireChange = false;
                }
                if (gm.allowFireFinal == true && allowFire == true && Input.GetKey(KeyCode.Mouse0))
                {
                    
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
                if (ld.tempFireChange == true)
                {
                    m4AttackSpeed = m4AttackSpeed - (m4AttackSpeed * ld.attackSpeedChange);
                    ld.tempFireChange = false;
                }
                if (gm.allowFireFinal == true && allowFire == true && Input.GetKey(KeyCode.Mouse0))
                {
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
            if (rpg)
            {
                gm.currentDamage = rpgDamage;
                if (ld.tempFireChange == true)
                {
                    rpgAttackSpeed = rpgAttackSpeed - (rpgAttackSpeed * ld.attackSpeedChange);
                    ld.tempFireChange = false;
                }
                if (gm.allowFireFinal == true && allowFire == true && Input.GetKey(KeyCode.Mouse0))
                {
                    effectOfGun.Emit(1);
                    StartCoroutine(WaitASecondrpg());

                    GameObject Temporary_Bullet_Handler;
                    Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                    Rigidbody Temporary_RigidBody;
                    Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();


                    Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                    Destroy(Temporary_Bullet_Handler, 10.0f);

                }
            }
        }
    }

    //pistol firerate
    IEnumerator WaitASecondPistol()
    {
        allowFire = false;
        yield return new WaitForSeconds(pistolAttackSpeed);
        allowFire = true;
       
    }

    //shotgun firerate
    IEnumerator WaitASecondShotgun()
    {
        allowFire = false;
        yield return new WaitForSeconds(shotgunAttackSpeed);
        allowFire = true;

    }
    //M4 firerate
    IEnumerator WaitASecondM4()
    {
        allowFire = false;
        yield return new WaitForSeconds(m4AttackSpeed);
        allowFire = true;
    }
    //rpg firerate
    IEnumerator WaitASecondrpg()
    {
        allowFire = false;
        yield return new WaitForSeconds(rpgAttackSpeed);
        allowFire = true;

    }


}

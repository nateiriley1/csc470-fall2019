using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    public BadGuyScript bgs;

    //Enemy Damage
    public GameObject Bullet_Emitter;
    public GameObject EnemyBullet;
    public float Bullet_Forward_Force = 500f;
    public bool allowFireBadGuy = true;
    //from ss
    public ParticleSystem effectOfGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Check if bad guy
        if (bgs.huntNow == true && allowFireBadGuy == true)
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
    IEnumerator RandomFire()
    {
        allowFireBadGuy = false;
        yield return new WaitForSeconds((Random.Range(1f, 5f)));
        allowFireBadGuy = true;

    }

}

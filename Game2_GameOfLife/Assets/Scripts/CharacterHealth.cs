using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public PlayerController pc;
    public Timer timer;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider healthBar;

    bool beingDamaged = false;

    public Text wintext;


    

    // Start is called before the first frame update
    void Start()
    {
        pc.speed = 10;
        wintext.text = "";
        MaxHealth = 100f;
        //Resets health to full on game load
        CurrentHealth = MaxHealth;

        healthBar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {

        if (beingDamaged == true)
        {
            DealDamage(1);
        }

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Respawn"))
        {

            Die();

        }
        if (other.gameObject.CompareTag("Dead"))
        {
            
            beingDamaged = true;

        }
        else
        {
            beingDamaged = false;
        }

    }
    void DealDamage(float damageValue)
    {
        //deduct the damage dealt from the characters health
        CurrentHealth -= damageValue;
        healthBar.value = CalculateHealth();
        // If the character is out of health, die
        if (CurrentHealth <= 0) { 
            Die();
        }
    }
    
    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        
        wintext.text = "Is the Time You Lasted!!!";
        CurrentHealth = 0;
        pc.speed = 0;
    }
}

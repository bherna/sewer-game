using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Combat : MonoBehaviour
{

    public int maxHealth = 100;
    float currentHealth;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage, Vector2 kb){

        Debug.Log("Slime: 'ouch' ");
        currentHealth -= damage;

        //play animation

        //knockback
        transform.position = kb;
        if(currentHealth <= 0){
            Die();
        }
    }

    private void Die(){

        Debug.Log("enemy died");

        //die animation
    }
}

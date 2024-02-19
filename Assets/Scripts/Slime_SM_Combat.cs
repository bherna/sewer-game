using System.Collections;
using System.Collections.Generic;
using Pathfinding.Examples;
using UnityEngine;

public class Slime_SM_Combat : MonoBehaviour
{

    public int maxHealth = 100;
    float currentHealth;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] Slime_StateMachine stateMachine;

    public float KBTimeLength = 1f;
    private float SetTimer = float.NegativeInfinity;

    private bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(GameObject sender, float damage, float kb_force){

        //take damage
        Debug.Log("Slime: 'ouch' ");
        currentHealth -= damage;

        //kb logic
        stateMachine.idle = true; //disable SM from updating path + new velocity
        endKnockBack(); //set timer to re-enable SM
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * kb_force, ForceMode2D.Impulse);
        

        //if we are out of health
        if(currentHealth <= 0){
            Die();
        }

    }


    private void Die(){

        Debug.Log("enemy died");

        //die animation
    }

    public void Attack(){
        Debug.Log("Slime: ATTACK;");
    }


    //used to re-enable the SM: due to Knockback
    private void endKnockBack(){
        
        //set timeer
        timerIsRunning = true;
        SetTimer = KBTimeLength;

    }
    

    private void Update() {
        

        if (timerIsRunning)
        {
            if (SetTimer > 0)
            {
                SetTimer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                SetTimer = 0;
                timerIsRunning = false;
                stateMachine.idle = false; //re-enable SM

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slime_Combat : MonoBehaviour
{

    public int maxHealth = 100;
    float currentHealth;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] private float delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

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
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * kb_force, ForceMode2D.Impulse);

        //if we are out of health
        if(currentHealth <= 0){
            Die();
        }

    }

    private IEnumerator Reset(){

        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }


    private void Die(){

        Debug.Log("enemy died");

        //die animation
    }


    public void Attack(){
        Debug.Log("Slime: ATTACK;");
    }
}

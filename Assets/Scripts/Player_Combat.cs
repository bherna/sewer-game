using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{


    //vector3 of object
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackPointRadius = 0.5f;
    //layer for collision
    [SerializeField] private LayerMask _attackMask;

    //
    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float kb_force = 1f;

    
    //health
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){

            Debug.Log("player attack");
            Attack();
        }
    }

    void Attack(){

        //play animation

        //detect enemeies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
                _attackPoint.position,
                _attackPointRadius,
                _attackMask
            );
        

        //damage enemy
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Slime_SM_Combat>().TakeDamage(gameObject, attackDamage, kb_force);
        }

    }

    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(
        _attackPoint.position,
        _attackPointRadius
        );
    }


    public void TakeDamage_Player(GameObject sender, float damage){

        //take damage
        Debug.Log("<color=red>Player: </color> 'ouch' ");
        currentHealth -= damage;



        //if we are out of health
        if(currentHealth <= 0){
            Die_Player();
        }
    }

    private void Die_Player(){

        Debug.Log("<color=red>Player: </color> died");

        //die animation
    }

    
}

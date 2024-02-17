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


    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float kb_force = 1f;
    private Vector2 kb_vector;

    [SerializeField] private Transform interactor;
    // Start is called before the first frame update
    void Start()
    {
        
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
        
        if(hitEnemies.Length > 0){
            kb_vector = new Vector2(
                    interactor.localPosition.x *kb_force,
                    interactor.localPosition.y *kb_force  
                );
        }

        //damage enemy
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Slime_Combat>().TakeDamage(gameObject, attackDamage, kb_force);
        }

    }

    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(
        _attackPoint.position,
        _attackPointRadius
        );
    }

    
}

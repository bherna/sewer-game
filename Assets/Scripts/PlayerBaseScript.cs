using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{


    public float speed = 10f;
    [SerializeField] private Transform interactor;

    public float horz_move, vert_move;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //movement bool
        vert_move = Input.GetAxis("Vertical") ;
        horz_move = Input.GetAxis("Horizontal") ;

        transform.Translate(
            horz_move * Time.deltaTime * speed,
            vert_move * Time.deltaTime * speed,
            0
        );

        //facing
        if(vert_move != 0 || horz_move != 0){
            interactor.position = new Vector3(
                transform.position.x + Mathf.Sign(horz_move)*Mathf.Ceil(Mathf.Abs(horz_move))/2,
                transform.position.y + Mathf.Sign(vert_move)*Mathf.Ceil(Mathf.Abs(vert_move))/2,
                0
            );
        }

        
        
    }

    
}

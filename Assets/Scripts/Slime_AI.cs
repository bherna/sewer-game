using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Timeline.Actions;
using UnityEngine.AI;

public class Slime_AI : MonoBehaviour
{

    //
    public Transform target; 

    public float speed = 200f;
    public float nextWaypointDistance = 3f;


    public Transform sprite;

    Path path;
    int currentWaypoint = 0; //along the path
    bool reachedEndOfPath = false;

    //seeker reference in slime
    Seeker seeker;
    //rb reference in slime
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //reference
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    
    }

    //responsible to creating paths (start path, end path, function() when done cal path)
    void UpdatePath(){

        if (seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathComplete);

        }
    }


    void OnPathComplete(Path p){

        //if no errors with path
        if(!p.error){

            //set path, and reset are progress along path
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //make sure we have path
        if(path == null){
            return;
        }
        //stop moving (if we reach end of waypoint list)
        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }

        //get direction to paht
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        //force 
        Vector2 force = direction * speed * Time.deltaTime;

        //add force to enemy
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);


        //if reached current waypoint
        if(distance < nextWaypointDistance){
            //go to next waypoint then
            currentWaypoint++;
        }
        

        //animation flip sprite
        if(force.x >= 0.01f){
            sprite.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f){
            sprite.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}

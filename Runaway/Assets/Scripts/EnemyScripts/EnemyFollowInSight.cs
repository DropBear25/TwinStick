using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowInSight : MonoBehaviour
{


    public float speed;
    public float lineOfSite; 
    public Transform player;
    private Animator move;



    void Start()
    {
        //   move.SetBool("Moving", false);
     
        player = GameObject.FindGameObjectWithTag("Player").transform;
        move = GetComponent<Animator>();
    }

  

    // Update is called once per frame
    void Update()
    {
        //move.SetBool("move", false);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
       
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            move.SetBool("move", true);
        }
        else
        {
            move.SetBool("move", false);
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}

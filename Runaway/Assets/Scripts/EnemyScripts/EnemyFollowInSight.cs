using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowInSight : MonoBehaviour
{


    public int speed;
    public float lineOfSite; 
    public Transform player;
    private Animator anim;



    void Start()
    {
        //   move.SetBool("Moving", false);
     
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

  

    // Update is called once per frame
    void Update()
    {
        //move.SetBool("move", false);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer > lineOfSite)
        {
            anim.SetBool("move", false);
        }

       else if (distanceFromPlayer < lineOfSite)
        {
            anim.SetBool("move", true);
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
           

        }
       
       
    }

   

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}

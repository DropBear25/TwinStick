using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;


    public Transform moveSpots;

    private float waitTime;
    public float startWaitTIme;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    public float lineOfSite;

    //test

    public Transform player;

    private void Start()
    {
     
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTIme;
        moveSpots.position = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
    }

    private void Update()
    {

        Attack();
       


    }

    private void Attack()
    { 
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            PatrolGround();


        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }


    private void PatrolGround()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if (waitTime <= 0)
            {

                moveSpots.position = new Vector2(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY));
                waitTime = startWaitTIme;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

  

   
    






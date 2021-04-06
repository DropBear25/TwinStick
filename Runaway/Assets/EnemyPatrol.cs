﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : StateMachineBehaviour
{

    private GameObject[] patrolPoints;

    int randomPoint;

    public float speed;

    //test
   // private Transform playerPos;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

     //   playerPos = GameObject.FindGameObjectWithTag("Player").transform;


        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoints");
        randomPoint = Random.Range(0, patrolPoints.Length);



    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

            animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolPoints[randomPoint].transform.position, speed * Time.deltaTime);
       // animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

       if(Vector2.Distance(animator.transform.position, patrolPoints[randomPoint].transform.position) < 0.1f){
            randomPoint = Random.Range(0, patrolPoints.Length);
       }
    }
     

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}

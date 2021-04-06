using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour
{

    public event EventHandler OnDead;

   

    public GameObject enemy;
  

    private void Awake()
    {
  
    }

    private void Start()
    {
        Disapear();
    }

   public void Spawn()
    {
        enemy.SetActive(true);
        Debug.Log("you can see me?");
        Instantiate(enemy, transform.position, transform.rotation);
       
    }

    public void Disapear()
    {
        enemy.SetActive(false);
    }

    //public bool IsAlive() {
    //    return !enemyMain.HealthSystem.IsDead();
    //}


    public bool IsAlive()
    {
        return false;
    }
}

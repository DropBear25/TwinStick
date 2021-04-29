using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{


    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float startSpawnTime = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Player")
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoints = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoints].position, transform.rotation);
                }


    }
}

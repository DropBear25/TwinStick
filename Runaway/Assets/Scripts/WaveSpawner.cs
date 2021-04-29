using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}



public class WaveSpawner : MonoBehaviour
{

    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    public Text waveName;

    //time interval
    private float nextSpawnTime;

    private bool canSpawn = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            currentWave = waves[currentWaveNumber];
            SpawnWave();
            GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
            {
                waveName.text = waves[currentWaveNumber + 1].waveName;

            }

        }

        void SpawnNextWave()
        {
            currentWaveNumber++;
            canSpawn = true;
        }


        void SpawnWave()
        {
            if (canSpawn && nextSpawnTime < Time.time)
            {
                GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
                currentWave.noOfEnemies--;
                nextSpawnTime = Time.time + currentWave.spawnInterval;

                if (currentWave.noOfEnemies == 0)
                {
                    canSpawn = false;
                    SpawnNextWave();
                }
            }


        }
    }



   


}






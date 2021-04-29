using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveSpawner
    {
        public EnemySpawn[] enemies;
        public int count; //different enemies spawned in the wave 
        public float timeBetweenSpawns;



    }
    public AudioSource _AudioSource;

    public AudioClip _AudioClip1;
    public AudioClip _AudioClip2;


    public WaveSpawner[] wavespawner;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private WaveSpawner currentSpawn;
    private int currentSpawnIndex;
    private Transform player;

    private bool finishedSpawning;

    public GameObject boss;
    public Transform bossSpawnPoint;






    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentSpawnIndex));

        _AudioSource.Play();


    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index)
    {
        currentSpawn = wavespawner[index];

        for (int i = 0; i < currentSpawn.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            EnemySpawn randomEnemy = currentSpawn.enemies[UnityEngine.Random.Range(0, currentSpawn.enemies.Length)];
            Transform randomSpot = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if (i == currentSpawn.count - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }


            yield return new WaitForSeconds(currentSpawn.timeBetweenSpawns);

        }
    }

     void Update()
    
   
        {
            if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                finishedSpawning = false;
                if (currentSpawnIndex + 1 < wavespawner.Length)
                {
                    currentSpawnIndex++;
                    StartCoroutine(StartNextWave(currentSpawnIndex));
                    Debug.Log("next wave");
                }
                else
                {
                    Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                }
            }


            if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                finishedSpawning = false;
                if (currentSpawnIndex + 1 < wavespawner.Length)
                {
                    currentSpawnIndex++;
                    StartCoroutine(StartNextWave(currentSpawnIndex));

                }
                else
                {
                    Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                    if (_AudioSource.clip == _AudioClip1)
                    {

                        _AudioSource.clip = _AudioClip2;

                        _AudioSource.Play();

                    }

                    else
                    {

                        _AudioSource.clip = _AudioClip1;

                        _AudioSource.Play();

                    }


                }




           

            }



        }


        


    }

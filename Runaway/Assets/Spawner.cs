using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class WaveSpawner
    {
        public EnemyHealth[] enemies;
        public int count; //different enemies spawned in the wave 
        public float timeBetweenSpawns;



    }
    //   public AudioSource _AudioSource;

    //   public AudioClip _AudioClip1;
    //   public AudioClip _AudioClip2;


    public WaveSpawner[] wavespawner;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private WaveSpawner currentSpawn;
    private int currentSpawnIndex;
    private Transform player;

    private bool finishedSpawning;

    public GameObject boss;
    public Transform bossSpawnPoint;



    [SerializeField] private Collider2D spawnColiider;


    private void Start()
    {
      


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

            EnemyHealth randomEnemy = currentSpawn.enemies[Random.Range(0, currentSpawn.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
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
    private void Update()
    {
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


            }
            //         if (_AudioSource.clip == _AudioClip1)
            {

                //             _AudioSource.clip = _AudioClip2;

                //              _AudioSource.Play();

                //       }

                //       else
                //      {

                //          _AudioSource.clip = _AudioClip1;

                //         _AudioSource.Play();

            }


        }
    }



   void WaveStart()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
      //  StartCoroutine(StartNextWave(currentSpawnIndex));
        //_AudioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if(collider.tag == ("Player"))
        {
           // player = GameObject.FindGameObjectWithTag("Player").transform;
            StartCoroutine(StartNextWave(currentSpawnIndex));
            WaveStart();
            Debug.Log("am in the collider");
  



        }
    }

}
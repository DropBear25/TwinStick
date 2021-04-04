using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    private enum State
    {
        Idle,
        Active,

    }           //having an array stops the get component call
    [SerializeField] private BattleTrigger colliderTrigger;
    [SerializeField] private Wave[] waveArray;

    private State state;

    private void Awake()
    {
        state = State.Idle;

    }


    private void Start()
    {
        colliderTrigger.OnPlayerEnterTrigger += BattleTrigger_OnPlayerEnterTrigger;
    }

    private void BattleTrigger_OnPlayerEnterTrigger(object sender, EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();   //not wasting CPU Cycles 
            colliderTrigger.OnPlayerEnterTrigger -= BattleTrigger_OnPlayerEnterTrigger;
        }

    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        state = State.Active;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    wave.Update();

                }
                break;
        }

    }




    //nested class
    [System.Serializable]
    private class Wave
    {
        [SerializeField] private EnemySpawn[] enemySpawnArray;
        [SerializeField] private float timer;


        public void Update()
        {
            if (timer > 0)
            {
                //every frame 
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    SpawnEnemies();
                }
            }
        }

        private void SpawnEnemies()
        {
            foreach (EnemySpawn enemySpawn in enemySpawnArray)
            {
                enemySpawn.Spawn();


            }

        }


    }
}





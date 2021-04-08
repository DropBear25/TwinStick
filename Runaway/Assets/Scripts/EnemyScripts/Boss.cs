using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health;
    public GameObject healthBar;


    public int healthPickupChance;
    public GameObject healthPickup;
    public AudioClip enemyDeathClip;

    private float halfHealth;
    private Animator anim;

    private void Start()
    {
        EnemyBoss();
        halfHealth = health / 2;
        anim = GetComponent<Animator>();



    }


   






    private void EnemyBoss()
    {
        if (health < 1)
        {

            if (health < healthPickupChance)
            {

                Instantiate(healthPickup, transform.position, transform.rotation);
            }


            Destroy(this.gameObject);
            SoundManager.instance.PlaySound(enemyDeathClip);
        }


          if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }


        //EnemyHealth randomEnemy = enemies[UnityEngine.Random.Range(0, enemies.Length)];
        //Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);


    }




    void OnTriggerEnter2D(Collider2D target)
        {
            if (target.tag == "Bullet")
            {
                health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
                Destroy(target.gameObject);
                 Handheld.Vibrate();



            healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
          
            EnemyBoss();
          

        }
      
    }
    }


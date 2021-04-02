using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    public GameObject healthBar;

    //   public AudioClip audioClip;
    public int healthPickupChance;
    public GameObject healthPickup;

    void Update()
    {
        if (health < 1) {
            int randomHealth = Random.Range(0, 101);
            if (randomHealth < healthPickupChance)
            {

                Instantiate(healthPickup, transform.position, transform.rotation);
            }



            Destroy(this.gameObject);
            //SoundManager.instance.PlaySound(deathClip);
        }

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage; 
            Destroy(target.gameObject);

            healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }


      


        }

    }






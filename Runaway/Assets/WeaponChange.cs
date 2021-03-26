using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{

    private Transform player;
    public Weapon weapon;

    void Start()
    {
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {


            player.GetComponent<Player>().currentWeapon = weapon;
            player.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSPR;


        }


    }

        public void Use()
    {

      



        }


        }
     
       // Instantiate(effect, player.position, Quaternion.identity);
       




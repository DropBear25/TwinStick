using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Transform player;
    public Weapon weapon;



    //test
     Player health;
    public int healAmount;


    private void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }



    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {

           // Player.Heal(healAmount);
          //    Destroy(gameObject);



           // transform.GetChild(0).Find("PlayerHealthBar").gameObject

            //target.GetComponent<Player>().currentWeapon = weapon;
            // target.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSPR;
            //  Destroy(gameObject);

        }


    }
}
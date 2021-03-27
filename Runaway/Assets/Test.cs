using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Transform player;
    public Weapon weapon;


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {


            target.GetComponent<Player>().currentWeapon = weapon;
            target.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSPR;
            Destroy(gameObject);

        }


    }
}
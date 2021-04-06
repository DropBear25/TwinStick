using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{


    //test
    //   Player health;
    //   public int healAmount;
    //  private Transform player;
    //  public GameObject effect;

    Player playerHealth;
    public int healAmount;



    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
      if (collider.tag == "Player")
       {

            playerHealth.Heal(healAmount);
            Destroy(gameObject);
            //     Destroy(gameObject);


            // transform.GetChild(0).Find("PlayerHealthBar").gameObject

            //target.GetComponent<Player>().currentWeapon = weapon;
            // target.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSPR;
            //  Destroy(gameObject);

               }


        }
}
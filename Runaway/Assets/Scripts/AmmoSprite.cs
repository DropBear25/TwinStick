using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSprite : MonoBehaviour
{

    //public Transform player;
    //public GameObject effect;
    //public Weapon currentWeapon;
    private void Start()
    {
   //  player = GameObject.FindGameObjectWithTag("RedGun").transform;


    }



    public void Use(){

        // if statement == gun tag then add bullets 
  //changed from ammotext to weapon script
        AmmoText.ammoAmount += 6;
        Destroy(gameObject);

    }


    }








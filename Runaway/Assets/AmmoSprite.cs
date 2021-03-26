using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSprite : MonoBehaviour
{

    private Transform player;
    public GameObject effect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }



    public void Use(){
       
        //Instantiate(effect, player.position, Quaternion.identity);
        AmmoText.ammoAmount += 6;
        Destroy(gameObject);

    }


    }








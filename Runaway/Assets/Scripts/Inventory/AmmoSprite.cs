using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSprite : MonoBehaviour
{


    private void Start()
    {
 


    }



    public void Use(){


        AmmoText.ammoAmount += 50;
        Destroy(gameObject);

    }


    }








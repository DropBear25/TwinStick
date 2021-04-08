using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSprite : MonoBehaviour
{
    public AudioClip audioReload;

    private void Start()
    {
 


    }



    public void Use(){

        SoundManager.instance.PlaySound(audioReload);
        AmmoText.ammoAmount += 60;
        Destroy(gameObject);

    }


    }








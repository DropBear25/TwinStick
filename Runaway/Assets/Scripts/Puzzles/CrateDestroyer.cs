using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDestroyer : MonoBehaviour
{

    public static event Action CrateDestroy = delegate { };

    private Animator anim;
    private int clicksCountdown;
    public AudioClip boxDestroy;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        clicksCountdown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (clicksCountdown < 1)
        {
            SoundManager.instance.PlaySound(boxDestroy);
            CrateDestroy();
        }



     

    }

    
    private void OnMouseDown()
    {
        anim.SetTrigger("Clicked");
        clicksCountdown -= 1;
    }
}

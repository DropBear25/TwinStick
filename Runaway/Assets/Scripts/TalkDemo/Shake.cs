 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;


    public void CamShake(){
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            camAnim.SetTrigger("shake");
        }else if(rand == 1)
        {
            camAnim.SetTrigger("shakeTwo");
        }
        else if(rand == 3)
        {
            camAnim.SetTrigger("shakeThree");
        }


       

    }


}

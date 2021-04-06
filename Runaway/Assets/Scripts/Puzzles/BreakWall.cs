using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{

    [SerializeField]
    private float wallhealth;
    private Animator wall_anim;
    void Start()
    {
        wall_anim = GetComponent<Animator>();

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            wallhealth -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage;
            wall_anim.SetTrigger("Hit");  
            Destroy(target.gameObject);
            WallDestroy();

        }
       void WallDestroy()
        {

            if (wallhealth < 1)
            {
                Destroy(this.gameObject);
            }

        }

    }


}


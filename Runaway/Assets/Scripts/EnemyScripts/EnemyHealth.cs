using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    void Update()
    {
        if (health < 1)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage; 
            Destroy(target.gameObject);
        }
          
        
    }
}




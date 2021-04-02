using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;


    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            boxCollider2D.enabled = false;

            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }


}

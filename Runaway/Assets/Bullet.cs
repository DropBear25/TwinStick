using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5;
    //public int timeToLive = 5;
    private Vector2 dir;

   






    private void Start()
    {
       
     
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;

       
         Destroy(gameObject, 3f); 

        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Player").transform.eulerAngles.z);


    }




    // changed to Fixed Michelle Teeeeeeeeeeeeeeeeest
    void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);

    }


  
}

// IEnumerator DestroyBullet() // 1hour30Doom MICHELLE Talk about this
//  {
//  yield return new WaitForSeconds(timeToLive);
//   }


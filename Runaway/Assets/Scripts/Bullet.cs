using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5;
    //public int timeToLive = 5;
    private Vector2 dir;



                                                                                                                       //Test New Bullet Pool  
    //test
 //   private float angle = 0f;



    private void Start()
    {
       // InvokeRepeating("Fire", 0f, 0.1f);
     
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;

       
         Destroy(gameObject, 3f); 

        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Player").transform.eulerAngles.z);


    }




   
    void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);

    }
    //private void Fire()
    //{
    //    float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
    //    float bulDirY = transform.position.y + Mathf.Sin((angle * Mathf.PI) / 180f);

    //    Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
    //    Vector2 bulDir = (bulMoveVector - transform.position).normalized;

    //    GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
    //    bul.transform.position = transform.position;
    //    bul.transform.rotation = transform.rotation;
    //    bul.SetActive(true);
    //   // bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
    //    transform.position = GameObject.Find("FirePoint").transform.position;




    //}

  
}

// IEnumerator DestroyBullet() // 1hour30Doom MICHELLE Talk about this
//  {
//  yield return new WaitForSeconds(timeToLive);
//   }


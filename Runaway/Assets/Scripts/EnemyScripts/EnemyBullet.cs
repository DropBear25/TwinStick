using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5;
    GameObject target;
    private Vector2 dir;
    Rigidbody2D rb;


    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Player").transform.eulerAngles.z);
       Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
    //    transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }





    void Update()
    {

     // transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);

    }




}

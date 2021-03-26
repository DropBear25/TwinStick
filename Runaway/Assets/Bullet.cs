using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5;
    public int timeToLive = 5;
    private Vector2 dir;




    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }

  
    IEnumerator DestroyBullet() // 1hour30Doom MICHELLE Talk about this
    {
        yield return new WaitForSeconds(timeToLive);
    }
}

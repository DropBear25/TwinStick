using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    List<GameObject> bulletList;
    GameObject bullet;

    private float speed = 5;
    //public int timeToLive = 5;
    private Vector2 dir;

    void Start()
    {
        bulletList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
    }

    void Pool()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
                break;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

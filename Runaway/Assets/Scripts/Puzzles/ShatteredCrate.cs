using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredCrate : MonoBehaviour
{
    private Rigidbody2D[] childerenRbs;
    private float randomTorque, randomDirX, randomDirY;

    private void Start()
    {
        childerenRbs = GetComponentsInChildren<Rigidbody2D>();


        foreach (Rigidbody2D rigidbody2D in childerenRbs)
    {
            randomTorque = Random.Range(-100f, 100f);
            randomDirX = Random.Range(-200f, 200f);
            randomDirY = Random.Range(-200, 200f);
            rigidbody2D.AddTorque(randomTorque);
            rigidbody2D.AddForce(new Vector2(randomDirX, randomDirY));
            

    }
        Destroy(gameObject, 2f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWay : MonoBehaviour
{

    private BoxCollider2D doorCollider;




    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

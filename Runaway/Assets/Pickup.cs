using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectsWithTag("Player").GetComponent<Inventory>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

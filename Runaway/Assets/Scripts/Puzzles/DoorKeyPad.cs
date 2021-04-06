using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyPad : MonoBehaviour
{


    [SerializeField]
    GameObject codePanel, closedSafe, openSafe;

    public static bool isSafeOpened = false;




    void Start()
    {
        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openSafe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSafeOpened)
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
            openSafe.SetActive(true);
        }

    }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.name.Equals ("Safe") && !isSafeOpened) {
            codePanel.SetActive(true);
            
        }
        }
     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Safe"))
        {
            codePanel.SetActive(false);
        }
    }
}


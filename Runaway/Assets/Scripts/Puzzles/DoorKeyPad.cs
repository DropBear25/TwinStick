using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyPad : MonoBehaviour
{


    [SerializeField]
  //  GameObject codePanel, closedSafe, openSafe;
    GameObject codePanel, bossDoor, openDoor;

   // public static bool isSafeOpened = false;
    public static bool isBossDoorOpened = false;




    void Start()
    {
        //codePanel.SetActive(false);
        //closedSafe.SetActive(true);
        //openSafe.SetActive(false);

        codePanel.SetActive(false);
        bossDoor.SetActive(true);
        openDoor.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (isBossDoorOpened)
        {
            //codePanel.SetActive(false);
            //closedSafe.SetActive(false);
            //openSafe.SetActive(true);


            codePanel.SetActive(false);
            bossDoor.SetActive(false);
            openDoor.SetActive(true);
        }

    }
        void OnTriggerEnter2D(Collider2D col)
        {//safe
            if(col.gameObject.name.Equals ("ControlPanel") && !isBossDoorOpened) {
            codePanel.SetActive(true);
            
        }
        }
     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("ControlPanel"))
        {
            codePanel.SetActive(false);
        }
    }
}


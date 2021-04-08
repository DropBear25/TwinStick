using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyPad : MonoBehaviour
{


    [SerializeField]
    GameObject codePanel, bossDoor, openDoor;
    public AudioClip doorOpen;
  
    public static bool isBossDoorOpened = false;




    void Start()
    {


        codePanel.SetActive(false);
        bossDoor.SetActive(true);
        openDoor.SetActive(false);


    }

   
    void Update()
    {
        if (isBossDoorOpened)
        {
     

            codePanel.SetActive(false);
            bossDoor.SetActive(false);
            openDoor.SetActive(true);
        }

    }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.name.Equals ("ControlPanel") && !isBossDoorOpened) {
            codePanel.SetActive(true);
            
        }
        }
     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("ControlPanel"))
        {
            codePanel.SetActive(false);
            SoundManager.instance.PlaySound(doorOpen);
        }
    }
}


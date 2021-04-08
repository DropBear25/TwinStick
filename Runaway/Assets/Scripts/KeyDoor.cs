using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{

    [SerializeField] private Key.KeyType keyType;
    public AudioClip doorOpen;

    public Key.KeyType GetKeyType(){

        return keyType;
    }

    public void OpenDoor() {

        SoundManager.instance.PlaySound(doorOpen);
        gameObject.SetActive(false);


    }

 
}

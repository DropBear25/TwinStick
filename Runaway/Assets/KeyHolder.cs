using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;



    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void Addkey(Key.KeyType keyType)
    {
        Debug.Log("Added Key" + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool Containskey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }
    void OnTriggerEnter2D(Collider2D other){
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            Addkey(key.GetKeyType());
            Destroy(key.gameObject);

        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (Containskey(keyDoor.GetKeyType()))
            {
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();

            }
        }

    }
}
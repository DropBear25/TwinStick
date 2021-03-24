﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyHolder : MonoBehaviour
{

    public event EventHandler OnKeysChanged;
    private List<Key.KeyType> keyList;



    private void Awake() {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList() {
        return keyList;
    }
    public void Addkey(Key.KeyType keyType){
        Debug.Log("Added Key" + keyType);
        keyList.Add(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
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
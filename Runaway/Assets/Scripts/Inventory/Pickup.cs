using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private List<Key.KeyType> keyList;

    private Inventory inventory;
    public GameObject itemButton;
    public AudioClip itemAudio;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    public void Addkey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
        Handheld.Vibrate();
     
    }

    public bool Containskey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //add item
                    inventory.isFull[i] = true;
                    Handheld.Vibrate();
                    SoundManager.instance.PlaySound(itemAudio);
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
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

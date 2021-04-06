using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    //does not have any reference to the battle system at all Cleaner than using GetComponent

    public event EventHandler OnPlayerEnterTrigger;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if(player != null)
        {
            Debug.Log("Am In");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }








}

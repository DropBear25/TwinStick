using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    Player playerHealth;
    public int healAmount;
    public AudioClip audioHeal;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       

    }



    public void Use()
    {

       
        SoundManager.instance.PlaySound(audioHeal);
        playerHealth.Heal(healAmount);
        Destroy(gameObject);

    }
}

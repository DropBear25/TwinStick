using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{

    private Transform player;
    public Weapon weapon;
    public AudioClip audioWeaponChange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }





    public void Use()
    {





        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.GetComponent<Player>().currentWeapon = weapon;
        player.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSPR;
        SoundManager.instance.PlaySound(audioWeaponChange);
        Destroy(gameObject);


    }



}



     
       // Instantiate(effect, player.position, Quaternion.identity);
       




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    internal static int currentWeapon;
    public Sprite currentWeaponSPR;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;

    Text text;
    public static int ammoAmount = 5;

    //test 
    // readonly Text text;
    // public static int ammoAmount = 100;

    // public Text ammoAmount = 100;


   

    public void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        //muzzleflash 

        
    }

    public void AmmoDisplay()
    {
        if (ammoAmount > 0)
            text.text = "Ammo " + ammoAmount;
        else
            text.text = "Out of Ammo!";

    }



}

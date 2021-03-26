using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{

    public Sprite currentWeaponSPR;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        //muzzleflash 
    }





}

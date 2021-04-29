using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{

    internal static int currentWeapon;
    public Sprite currentWeaponSPR;

    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;
   

    public AudioClip[] shootClips;













    public void Shoot()
    {
        
        SoundManager.instance.PlaySound(shootClips[Random.Range(0, shootClips.Length)]);




        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);


    }

}
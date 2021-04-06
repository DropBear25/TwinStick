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
    public int ammoAmount = 10;

    public SimplePool Pooler { get; set; }

    //test 
    // readonly Text text;
    // public static int ammoAmount = 100;

    // public Text ammoAmount = 100;




    public void Shoot()
    {
        //projectile spawn position
       // SpawnBullet(bulletSpawnPosition);

        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        //  this.bulletPrefab.SetActive(true);


       

        // GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        //  bullet.SetActive(true);
        //muzzleflash 
        //   




    }

    private void SpawnBullet(Vector2 spawnPosition)
    {
        GameObject bulletPooled = Pooler.GetObjectFromPool();
        bulletPooled.transform.position = spawnPosition;
        bulletPooled.SetActive(true);

        Bullet bullet = bulletPooled.GetComponent<Bullet>();
    }



}

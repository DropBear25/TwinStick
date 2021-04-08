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
    public int ammoAmount = 10;

    public AudioClip[] shootClips;







    //test 
    // readonly Text text;
    // public static int ammoAmount = 100;

    // public Text ammoAmount = 100;




    public void Shoot()
    {
        //projectile spawn position
        // SpawnBullet(bulletSpawnPosition);

        GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        SoundManager.instance.PlaySound(shootClips[Random.Range(0, shootClips.Length)]);
        //  this.bulletPrefab.SetActive(true);




        // GameObject bullet = Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);
        //  bullet.SetActive(true);
        //muzzleflash 
        //   




    }

}
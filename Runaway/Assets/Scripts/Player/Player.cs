using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Weapon currentWeapon;
    private Rigidbody2D myBody;
    private Animator FireAnim;
    public AudioClip hitClip, playerDeathClip;
  

    public float speed;


    private float nextTimeOfFire = 0f;

    public GameObject bullet;

    private Vector2 moveVelocity;

    public ControlJoystick movejoystick;
    public ControlJoystick shootJoystick;


  


        [HideInInspector]
    public int numOfHealth;

    public Image[] healthbar;
    public Sprite fullhealthbar;
    public Sprite emptyhealthbar;





    [SerializeField]
    public int health;

    private bool hit = true;

    [HideInInspector]
    public bool canShoot;


 

    public void Awake()
    { 
        
        myBody = GetComponent<Rigidbody2D>();
        FireAnim = transform.GetChild(0).GetComponent<Animator>();
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSPR;

    }

    private void Update()
    {
        HealthBar(health);
        Rotation();

        //&& Weapon.ammoAmount > 0
        //shoot function //     AmmoText.ammoAmount > 0 changed to currentWeapon.ammoAmount > 0
        if (Input.GetMouseButton(0) && canShoot && AmmoText.ammoAmount > 0)

    

            Shoot();
       

    }



    private void Shoot()
    {
      
        if (Time.time >= nextTimeOfFire)
        {   
            AmmoText.ammoAmount -= 1;
            currentWeapon.Shoot();
            nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;

            
             
            // GameObject g = bulletPool.GetObject();
            //  g.transform.position = transform.position;
            //  g.transform.rotation = transform.rotation;
            //  g.SetActive(true);

            //GameObject.Find("FirePoint").transform.position, Quaternion.identity);
            //  ammoSlot.ReduceCurrentAmmo();

        }

      

        }
        // Update is called once per frame
        void FixedUpdate()
        {

            Movement();

        }

        void Rotation()
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            if (shootJoystick.InputDir != Vector3.zero)
                angle = Mathf.Atan2(shootJoystick.InputDir.y, shootJoystick.InputDir.x) * Mathf.Rad2Deg + 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
        }

        void Movement()
        {

            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));

            if (movejoystick.InputDir != Vector3.zero)
                moveInput = movejoystick.InputDir;

            moveVelocity = moveInput.normalized * speed;
            myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);

            if (moveVelocity == Vector2.zero)
                FireAnim.SetBool("Fire", false);

            else
                FireAnim.SetBool("Fire", true);
        }



        //test 

        IEnumerator HitBoxOff()
        {
            hit = false;
            yield return new WaitForSeconds(1.5f);
            hit = true;

        }

        void OnTriggerEnter2D(Collider2D target)
        {
            if (target.tag == "Enemy" && health > numOfHealth)
            {
                if (hit)
                {
                SoundManager.instance.PlaySound(hitClip);
                    StartCoroutine(HitBoxOff());
                    health--;
            //    health = numOfHealth;
                    //    health = numOfHearts;
                  
                    if (health < 1)
                    {
                      StartCoroutine(Death());
                    SoundManager.instance.PlaySound(playerDeathClip);
                    }
                }

            }

        }



      IEnumerator Death()
      {
       SoundManager.instance.PlaySound(playerDeathClip);
     yield return new WaitForSeconds(1);
    SceneManager.LoadScene("GameOver");
     }

    void HealthBar(int health)
    {
        for (int i = 0; i < healthbar.Length; i++)
        {

            if (i < health)
            {

                healthbar[i].GetComponent<Image>().sprite = fullhealthbar;

            }
            else
            {
                healthbar[i].GetComponent<Image>().sprite = emptyhealthbar;
            }

        }
    }


     public void Heal(int healAmount)
            {
                if (health + healAmount > 5)
                {
                    health = 5;
                }
                else
                {
                    health += healAmount;

                }
                HealthBar(health);

            }
        



    //possibly set weapon script

}




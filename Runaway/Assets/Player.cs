using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Weapon currentWeapon;
    private Rigidbody2D myBody;
    private Animator FireAnim;
  

    public float speed;


    private float nextTimeOfFire = 0f;

    public GameObject bullet;

    private Vector2 moveVelocity;

    public ControlJoystick movejoystick;
    public ControlJoystick shootJoystick;

    [HideInInspector]
    public bool canShoot;

   // public static int AmmoCapacity { get; internal set; }

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        FireAnim = transform.GetChild(0).GetComponent<Animator>();
     //   StartCoroutine(DestroyBullet());

    }

    private void Update()
    {
        Rotation();

        //shoot function
        if (Input.GetMouseButton(0) && canShoot && AmmoText.ammoAmount > 0)

            shoot();
         
    }

    private void shoot()
    {
        //Instantiate(bullet, transform.position, Quaternion.identity);

        if (Time.time >= nextTimeOfFire)
        {
            AmmoText.ammoAmount -= 1;
            currentWeapon.Shoot();
            nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;


        }
    }

   

    void Start()
    {
        
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
}

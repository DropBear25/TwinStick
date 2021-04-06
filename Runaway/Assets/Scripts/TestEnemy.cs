using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

    private List<Rigidbody2D> EnemyRBs;

    private float repelRange = .5f;


    [SerializeField]
    private float health;
    public GameObject healthBar;
    public float speed;

    public Transform player;
    private Rigidbody2D rb;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Awake()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        if (EnemyRBs == null)
        {
            EnemyRBs = new List<Rigidbody2D>();
        }

        EnemyRBs.Add(rb);
    }

    private void OnDestroy()
    {
        EnemyRBs.Remove(rb);

    }




    void Update()
    {


        //if (health < 1)
        //    Destroy(gameObject);

        //if (Vector2.Distance(transform.position, player.position) > 0.3f)
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector2 repelForce = Vector2.zero;
        foreach (Rigidbody2D enemy in EnemyRBs)
        {
            if (enemy == rb)
                continue;

            if (Vector2.Distance(enemy.position, rb.position) <= repelRange)
            {
                Vector2 repelDir = (rb.position - enemy.position).normalized;
                repelForce += repelDir;
            }
        }
    }
    // void OnTriggerEnter2D(Collider2D target)
    //{
    //    if (target.tag == "Bullet")
    //    {
    //        health -= GameObject.Find("Player").GetComponent<Player>().currentWeapon.damage; 
    //        Destroy(target.gameObject);

    //        healthBar.transform.localScale = new Vector3(health / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    //    }

       


    //}

}
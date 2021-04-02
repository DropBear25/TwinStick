using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{

    private SpriteRenderer rend;
    private Sprite jim, sideways;

    public Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        jim = Resources.Load<Sprite>("Player");
        sideways = Resources.Load<Sprite>("Sideways");
             rend.sprite = jim;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
        }




    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            if (rend.sprite == jim)
                rend.sprite = sideways;
            else if (rend.sprite == sideways)
            //    rend.sprite = jim;
            IsGrounded();



        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = .01f;
        Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y);
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightText));
        return raycastHit.collider != null;

    }
    
}
     
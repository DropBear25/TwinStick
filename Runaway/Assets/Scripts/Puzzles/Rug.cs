using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rug : MonoBehaviour
{


    private Touch touch;

    private Vector2 initialPosition, touchPosition;

    private BoxCollider2D rugCollider;

    private float deltaY;

    private bool moveAllowed;

    private GameObject key_dimond;
    private BoxCollider2D keyCollider;


    void Start()
    {
        initialPosition = transform.position;
        rugCollider = GetComponent<BoxCollider2D>();
        moveAllowed = false;

        key_dimond = GameObject.Find("DimondKey");
        keyCollider = key_dimond.GetComponent<BoxCollider2D>();
        keyCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (rugCollider == Physics2D.OverlapPoint(touchPosition))
                    {
                        deltaY = touchPosition.y - transform.position.y;
                        moveAllowed = true;
                    }
                    break;
            
            case TouchPhase.Moved:
            if (rugCollider == Physics2D.OverlapPoint(touchPosition) && moveAllowed)
                transform.position = new Vector2(transform.position.x, touchPosition.y - deltaY);
                    break;
            

            }
            }
        transform.position = new Vector2(
            transform.position.x,
            Mathf.Clamp(transform.position.y, initialPosition.y - 1f, initialPosition.y));

        if (transform.position.y < initialPosition.y - 0.3f)
            keyCollider.enabled = true;
        }
    }


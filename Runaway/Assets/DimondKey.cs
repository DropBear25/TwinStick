using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimondKey : MonoBehaviour
{
    private Touch touch;

    private Vector2 touchPosition;

    private BoxCollider2D rugCollider;

    private BoxCollider2D keyCollider;

    private float deltaY, deltaX;

    private bool moveAllowed;

    [SerializeField]
    private GameObject doorLock, door;

    private BoxCollider2D doorLockCollider;


    
  


    void Start()
    {
        keyCollider = GetComponent<BoxCollider2D>();
        doorLockCollider = doorLock.GetComponent<BoxCollider2D>();
        moveAllowed = false;
    }

     void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (keyCollider == Physics2D.OverlapPoint(touchPosition))
                    {
                        deltaY = touchPosition.y - transform.position.y;
                        deltaX = touchPosition.x - transform.position.x;
                        moveAllowed = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (keyCollider == Physics2D.OverlapPoint(touchPosition) && moveAllowed)
                        transform.position = new Vector2(transform.position.x - deltaX,  touchPosition.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    moveAllowed = false;
                    if (keyCollider.bounds.Intersects(doorLockCollider.bounds))
                    {
                        door.GetComponent<BoxCollider2D>().enabled = true;
                        doorLock.SetActive(false);
                    }
                    break;
                    
            }
        }
      
    }
}

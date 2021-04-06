using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimondKey : MonoBehaviour
{

    private Touch touch;

    private Vector2 touchPosition;

    private BoxCollider2D keyCollider;

    private float deltaX, deltaY;

    private bool moveAllowed;

    [SerializeField]
    private GameObject doorLock, door;

    private BoxCollider2D doorLockCollider;

    // Start is called before the first frame update
    void Start()
    {
        keyCollider = GetComponent<BoxCollider2D>();
        doorLockCollider = doorLock.GetComponent<BoxCollider2D>();
        moveAllowed = false;
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
                    if (keyCollider == Physics2D.OverlapPoint(touchPosition))
                    {
                        deltaX = touchPosition.x - transform.position.x;
                        deltaY = touchPosition.y - transform.position.y;
                        moveAllowed = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (keyCollider == Physics2D.OverlapPoint(touchPosition) && moveAllowed)
                        transform.position = new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    moveAllowed = false;
                    if (keyCollider.bounds.Intersects(doorLockCollider.bounds))
                    {
                        door.GetComponent<BoxCollider2D>().enabled = true;
                        doorLock.SetActive(false);
                        gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }
}

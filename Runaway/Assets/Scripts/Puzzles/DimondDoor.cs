using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimondDoor : MonoBehaviour
{

    private BoxCollider2D doorCollider;

    [SerializeField]
    private GameObject doorway;


    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorCollider.enabled = false;
    }

    private void OnMouseDown()
    {
        doorway.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] private float startHealth = 10f;
    [SerializeField] private float maxHealth = 10f;



    [Header("Settings")]
    [SerializeField] private bool destroyObject;


    private Player character;
    private CharacterController controller;
    private Collider2D Collider2D;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weapon;


    public float CurrentHealth { get; set; }


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        character = GetComponent<Player>();
        Collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        weapon = transform.GetChild(1).GetComponent<SpriteRenderer>();



        CurrentHealth = startHealth;
        UI_Manager.Instance.UpdateHealth(CurrentHealth, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Revive();
        }
    }


    //recieve damage 
    public void TakeDamage(int damage)
    {
        if(CurrentHealth <= 0)
        {
            return;
        }

        UI_Manager.Instance.UpdateHealth(CurrentHealth, maxHealth);
        CurrentHealth -= damage;
       
        if(CurrentHealth <= 0)
        {
            Die();
        }



    }

    private void Die()
    {

        if(character != null)
        {
            Collider2D.enabled = false;
            spriteRenderer.enabled = false;
             
            character.enabled = false;
            controller.enabled = false;
            weapon.enabled = false;
        }


        if (destroyObject)
        {
            DestroyObject();
        }

    }


    private void Revive()
    {

        if (character != null)
        {
            Collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
            weapon.enabled = true;
        }
        gameObject.SetActive(true);
    }


    private void DestroyObject()
    {
        gameObject.SetActive(false);

    }


}

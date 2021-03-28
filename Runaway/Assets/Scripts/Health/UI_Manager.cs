using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{

    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI currentHealthHealthTMP;



    private float playerCurrentHealth;
    private float playerMaxHealth;


    private void Update()
    {
        InternalUpdate();
    }


    public void UpdateHealth(float currentHealth, float MaxHealth)
    {
        playerCurrentHealth = currentHealth;
        playerMaxHealth = MaxHealth;
    }

    private void InternalUpdate()
    {

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
        currentHealthHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString();
    }








}

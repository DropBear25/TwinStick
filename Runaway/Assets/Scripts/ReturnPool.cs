using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPool : MonoBehaviour
{
    //bullet script 

    [SerializeField] private float lifeTime = 2f;

    private void Return()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        Invoke(nameof(Return), lifeTime);
    }


    private void OnDisable()
    {
        CancelInvoke();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{

    [SerializeField]
    public GameObject crate, pickup, shatteredcrate;


    void Start()
    {
        CrateDestroyer.CrateDestroy += DestroyCrate;
    }


    private void DestroyCrate()
    {
        Destroy(crate);
        Instantiate(shatteredcrate, transform.position, Quaternion.identity);
        Instantiate(pickup, transform.position, Quaternion.identity);
    }
    
    private void OnDestroy()
    {
        CrateDestroyer.CrateDestroy -= DestroyCrate; 
    }


}

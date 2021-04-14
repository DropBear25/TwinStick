using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{






    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Handheld.Vibrate();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    Text text;
    public static int ammoAmount = 100;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (ammoAmount > 0)
            text.text = "Ammo " + ammoAmount;
        else
            text.text = "Out of Ammo!";
    }


}

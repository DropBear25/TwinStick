using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAmmo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots; 

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
      // public Weapon currentWeapon;

    }

    private void Start()
    {
      //  transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = ammoSlots.
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
      return GetAmmoSlot(ammoType).ammoAmount;


    }

   public void ReduceCurrentAmmo(AmmoType ammoType)
  {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}

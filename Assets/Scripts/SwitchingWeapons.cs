using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapons : MonoBehaviour
{   //serialized-fields
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotGun;

    //private-fields
    bool shotGunEquipped = false;
    UpdatingUIForWeapons weaponsUI;

    void Start()
    {
        shotGun.SetActive(false);
        weaponsUI =FindObjectOfType<UpdatingUIForWeapons>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && shotGunEquipped == false)
        {
            shotGun.SetActive(true);          
            pistol.SetActive(false);
            weaponsUI.SetToShotGunUI();
            shotGunEquipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && shotGunEquipped == true)
        {
            shotGun.SetActive(false);
            pistol.SetActive(true);
            weaponsUI.SetToPistolUI();
            shotGunEquipped = false;
        }
    }


}

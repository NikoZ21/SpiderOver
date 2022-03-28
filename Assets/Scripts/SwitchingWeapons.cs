using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingWeapons : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotGun;

    private bool hasShotGunEquipped = false;
    private UpdatingUIForWeapons _weaponsUI;

    void Start()
    {
        shotGun.SetActive(false);
        _weaponsUI = FindObjectOfType<UpdatingUIForWeapons>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && hasShotGunEquipped == false)
        {
            SwitchWeapons(hasShotGunEquipped,1);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && hasShotGunEquipped == true)
        {
            SwitchWeapons(hasShotGunEquipped,0);
        }
    }

    private void SwitchWeapons(bool isSwitching,int x)
    {
        shotGun.SetActive(!isSwitching);
        pistol.SetActive(isSwitching);
        _weaponsUI.ChnageBetweenGunsUI(x, hasShotGunEquipped);
        hasShotGunEquipped = !isSwitching;
    }
}

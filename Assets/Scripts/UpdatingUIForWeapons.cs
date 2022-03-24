using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatingUIForWeapons : MonoBehaviour
{
    [SerializeField] Image gunHolder;
    [SerializeField] Sprite[] guns;
    [SerializeField] GameObject pistolCanvas;
    [SerializeField] GameObject ShotgunCanvas;

    void Start()
    {
        gunHolder.sprite = guns[0];
        ShotgunCanvas.SetActive(false);
    }

    public void SetToPistolUI()
    {
        gunHolder.sprite = guns[0];
        ShotgunCanvas.SetActive(false);
        pistolCanvas.SetActive(true);
    }

    public void SetToShotGunUI()
    {
        gunHolder.sprite = guns[1];
        ShotgunCanvas.SetActive(true);
        pistolCanvas.SetActive(false);
    }
}

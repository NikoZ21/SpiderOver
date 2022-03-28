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

    public void ChnageBetweenGunsUI(int x, bool isSwitching)
    {
        gunHolder.sprite = guns[x];
        ShotgunCanvas.SetActive(!isSwitching);
        pistolCanvas.SetActive(isSwitching);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackground : MonoBehaviour
{
    [SerializeField] Sprite[] backGrounds;

    void Start()
    {
        int randomIndex = Random.Range(0, backGrounds.Length);
        GetComponent<Image>().sprite = backGrounds[randomIndex];
    }
}

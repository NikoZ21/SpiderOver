using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var keyCard = collision.GetComponent<KeyCard>();
        if (keyCard)
        { 
            CompareColors(keyCard);
        }
    }

    private void CompareColors(KeyCard keyCard)
    {
        switch (keyCard.keyCardColor)
        {
            default:
            case KeyCard.KeyCardColor.black:
                FillSLot(keyCard, 0);
                break;
            case KeyCard.KeyCardColor.brown:
                FillSLot(keyCard, 1);
                break;
            case KeyCard.KeyCardColor.yellow:
                FillSLot(keyCard, 2);
                break;
            case KeyCard.KeyCardColor.orange:
                FillSLot(keyCard, 3);
                break;
            case KeyCard.KeyCardColor.red:
                FillSLot(keyCard, 4);
                break;

        }
    }

    private void FillSLot(KeyCard keyCard, int x)
    {
        _inventory.isFull[x] = true;

        var placeholder = _inventory.slots[x].transform.Find("PlaceHolder");
        placeholder.GetComponent<Image>().sprite = keyCard.keyCardSprite;

        Destroy(keyCard.gameObject);
    }
}


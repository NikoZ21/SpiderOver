using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    [SerializeField] GameObject keyCard;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        keyCard.SetActive(false);
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(_boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (Input.GetKeyDown(KeyCode.E  ) && keyCard != null)
            {
                keyCard.SetActive(true);
            }
        }
    }
}

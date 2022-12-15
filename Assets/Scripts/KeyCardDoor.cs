using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    [SerializeField] GameObject cutScene;
    [SerializeField] [Range(0, 4)] int index = 0;

    private BoxCollider2D _boxCollider;
    private Inventory _inventory;
    private GameSession _gameSession;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _inventory = FindObjectOfType<Inventory>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        if (_boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (Input.GetKeyDown(keyCode) && _inventory.isFull[index] == true)
            {
                if (index == 0)
                {
                    _gameSession.LoadNextLevel();
                }
                StartCoroutine(ProccesDoorOpen());

            }
            else if(Input.GetKeyDown(keyCode))
            {
                Debug.Log("check ur inventory");
            }
        }

    }

    private IEnumerator ProccesDoorOpen()
    {
        cutScene.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
        cutScene.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private GameSession _gameSession;


    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _gameSession = FindObjectOfType<GameSession>();
    }

    private void Update()
    {
        ValidateExit();
    }

    private void ValidateExit()
    {
        bool isCorrectName = gameObject.name == "ExitDoor";
        bool isPlayer = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player"));
        bool hasEnoughKeys = FindObjectsOfType<Key>().Length <= 0;

        if (isCorrectName && isPlayer)
        {
            if (!hasEnoughKeys) return;
            SetDoorAnimation();
            _gameSession.LoadNextLevel();
        }
        else
        {
            Debug.Log("Find All Keys");
        }
    }

    private void SetDoorAnimation()
    {
        _animator.SetBool("Open", _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")));
    }
}

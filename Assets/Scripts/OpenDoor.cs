using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider2D;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("Open", boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")));
        if (gameObject.name == "ExitDoor" && boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")) && FindObjectsOfType<Key>().Length <= 0)
        {
            FindObjectOfType<GameSession>().LoadNextLevel();
        }
        else if(gameObject.name == "ExitDoor" && boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")) && FindObjectsOfType<Key>().Length > 0)
        {
            Debug.Log("Find All Keys");
        }

    }
}

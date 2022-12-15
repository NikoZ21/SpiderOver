using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    void Update()
    {
        if (FindObjectOfType<PlayerHealth>() == null)
        {
            FindObjectOfType<GameSession>().ResetScene();
        }
    }
}

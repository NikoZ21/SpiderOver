using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Vector3 offSet;
    PlayerMovement player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        offSet = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player == null)
        {
            return;
        }
        transform.position = player.transform.position + offSet;
    }
}

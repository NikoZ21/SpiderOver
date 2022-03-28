using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //serilized
    [SerializeField] Vector3 offSet;

    //Cached-variables
    private PlayerMovement _player;


    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        offSet = new Vector3(0, 0, -10);
    }


    void LateUpdate()
    {
        if (_player == null) return;

        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        transform.position = _player.transform.position + offSet;
    }
}

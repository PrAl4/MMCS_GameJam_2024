using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHelper : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, 0.3f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform _player;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = this.transform.position;
        pos = new Vector3(_player.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = pos;
    }
}

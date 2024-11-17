using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject camHelper;

    void FixedUpdate()
    {
        Vector3 pos = this.transform.position;
        pos = new Vector3(camHelper.transform.position.x, 0, -10);
        transform.position = pos;
    }
}

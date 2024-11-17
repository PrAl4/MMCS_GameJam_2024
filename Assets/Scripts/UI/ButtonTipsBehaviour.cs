using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TipsManager;

public class ButtonTipsBehaviour : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curGunMode = gunModes.Top;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curGunMode = gunModes.Right;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curGunMode = gunModes.Bottom;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) 
        {
            curGunMode = gunModes.Left;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TipsManager;

public class ButtonTipsBehaviour : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && UIShowManager.curNumberOfGuns >= 1)
        {
            curGunMode = gunModes.Top;
            Debug.Log(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && UIShowManager.curNumberOfGuns >= 2)
        {
            curGunMode = gunModes.Right;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && UIShowManager.curNumberOfGuns >= 3)
        {
            curGunMode = gunModes.Bottom;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && UIShowManager.curNumberOfGuns >= 4) 
        {
            curGunMode = gunModes.Left;
        }
    }
}

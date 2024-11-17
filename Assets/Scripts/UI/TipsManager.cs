using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    GameObject[] wheelButtonsEnhanced;

    [SerializeField]
    GameObject[] gunTipsEnhanced;

    public enum gunModes { Top, Right, Bottom, Left };
    public static gunModes curGunMode = gunModes.Top;
    gunModes oldGunMode = gunModes.Top;
    private int numberOfGunModes = System.Enum.GetValues(typeof(gunModes)).Length;

    private void Update()
    {
        if (oldGunMode != curGunMode)
        {
            oldGunMode = curGunMode;
            SetNewActiveGun();
        }
        if (UIShowManager.wheelIsActive) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TwistWheelRight();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                TwistWheelLeft();
            }
        }  
    }

    void TwistWheelRight()
    {
        curGunMode += 1;
        if ((int)curGunMode == numberOfGunModes)
            curGunMode = 0;
        oldGunMode = curGunMode;
        SetNewActiveGun();
    }

    void TwistWheelLeft()
    {
        curGunMode -= 1;
        if ((int)curGunMode == -1)
            curGunMode = (gunModes)(numberOfGunModes - 1);
        oldGunMode = curGunMode;
        SetNewActiveGun();
    }

    void SetNewActiveGun()
    {
        SetNewTips((int)curGunMode);
        playerController.WeaponKey = (int)curGunMode + 1;
    }

    void SetNewTips(int num)
    {
        for (int i = 0; i < gunTipsEnhanced.Length; i++)
        {
            if (i == num)
            {
                wheelButtonsEnhanced[i].SetActive(true);
                gunTipsEnhanced[i].SetActive(true);
            }
            else
            {
                gunTipsEnhanced[i].SetActive(false);
                wheelButtonsEnhanced[i].SetActive(false);
            }

        }
    }

}

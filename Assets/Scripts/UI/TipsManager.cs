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

    private void OnEnable()
    {
        UIShowManager.gunUp += UnlockNewTip;
    }

    private void OnDisable()
    {
        UIShowManager.gunUp -= UnlockNewTip;
    }

    void UnlockNewTip() 
    {
        numberOfGunModes++;
        if (numberOfGunModes == 0)
            soundManager.PlaySoundtrack(playerController.WeaponKey);
        
    }

    public enum gunModes { Top, Right, Bottom, Left };
    public static gunModes curGunMode = gunModes.Top;
    gunModes oldGunMode = gunModes.Top;
    private int numberOfGunModes = UIShowManager.curNumberOfGuns - 1;

    private SoundManager soundManager;
    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (oldGunMode != curGunMode)
        {
            oldGunMode = curGunMode;
            SetNewActiveGun();
        }
        if (UIShowManager.wheelIsActive && numberOfGunModes >= 1) 
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
        if ((int)curGunMode == numberOfGunModes + 1)
            curGunMode = 0;
        oldGunMode = curGunMode;
        SetNewActiveGun();
        

        soundManager.PlayButtonSound();
        
    }

    void TwistWheelLeft()
    {
        curGunMode -= 1;
        if ((int)curGunMode == -1)
            curGunMode = (gunModes)(numberOfGunModes);
        oldGunMode = curGunMode;
        SetNewActiveGun();
        
        soundManager.PlayButtonSound();
    }

    void SetNewActiveGun()
    {
        SetNewTips((int)curGunMode);
        playerController.WeaponKey = (int)curGunMode + 1;
        soundManager.PlaySoundtrack(playerController.WeaponKey);
    }

    void SetNewTips(int num)
    {
        for (int i = 0; i <= numberOfGunModes; i++)
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

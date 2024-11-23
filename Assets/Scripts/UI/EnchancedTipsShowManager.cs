using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchancedTipsShowManager : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    GameObject[] wheelButtonsEnhanced;

    [SerializeField]
    GameObject[] gunTipsEnhanced;

    GameData gameData;

    private SoundManager soundManager;

    private void OnEnable()
    {
        GameData.OnSwithingToAnotherGunMode += SetNewActiveGun;
        GameData.OnTakingNewGun += SetNewActiveGun;
    }

    private void OnDisable()
    {
        GameData.OnSwithingToAnotherGunMode -= SetNewActiveGun;
        GameData.OnTakingNewGun -= SetNewActiveGun;
    }

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        gameData = GettingGameData.GetDataObj();
        SetNewActiveGun((int)gameData.curGunMode);
    }

    void SetNewActiveGun(int gunNum)
    {
        if (gunNum != 0) 
        {
            SetNewTips(gunNum - 1);

            playerController.WeaponKey = gunNum;

            soundManager.PlaySoundtrack(gunNum);
        }
    }

    void SetNewTips(int num)
    {
        for (int i = 0; i <= gameData.unlockedGuns - 1; i++)
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

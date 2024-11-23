using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowManager : MonoBehaviour
{
    [SerializeField]
    GameObject WheelOfChoice;

    [SerializeField]
    GameObject[] wheelButtons;

    [SerializeField]
    GameObject[] gunTips;

    GameDataScript gameData;

    public static event Action gunUp;

    public static bool wheelIsActive = false;

    private SoundManager soundManager;

    private void OnEnable()
    {
        GameDataScript.OnTakingNewGun += ShowNewTips;
    }

    private void OnDisable()
    {
        GameDataScript.OnTakingNewGun -= ShowNewTips;
    }

    void ShowNewTips(int newGunNum) 
    {
        for (int i = 0; i < newGunNum; i++) 
        {
            wheelButtons[i].SetActive(true);
            gunTips[i].SetActive(true);
        }
    }

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        gameData = GettingGameData.GetDataObj();
        //Debug.Log(gameData.curGunMode);
        ShowNewTips(gameData.unlockedGuns);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !wheelIsActive)
        {
            WheelOfChoice.SetActive(true);
            wheelIsActive = true;
            soundManager.PlayButtonSound();
        }
        else if (Input.GetKeyDown(KeyCode.R) && wheelIsActive) 
        {
            WheelOfChoice.SetActive(false);
            wheelIsActive = false;
            soundManager.PlayButtonSound();
        }
    }
}

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

    [SerializeField]
    GameData gameData;

    public static event Action gunUp;

    public static bool wheelIsActive = false;

    private SoundManager soundManager;

    private void OnEnable()
    {
        GameData.OnTakingNewGun += ShowNewTips;
    }

    private void OnDisable()
    {
        GameData.OnTakingNewGun -= ShowNewTips;
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

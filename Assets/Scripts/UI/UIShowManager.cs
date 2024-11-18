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

    public static event Action gunUp;

    public static bool wheelIsActive = false;

    public static int curNumberOfGuns = 0;

    private SoundManager soundManager;

    private void OnEnable()
    {
        TakingWeaponScript.takingWeapon +=IncreaseAmountOfGuns;
    }

    private void OnDisable()
    {
        TakingWeaponScript.takingWeapon -= IncreaseAmountOfGuns;
    }

    void IncreaseAmountOfGuns(int n)
    {
        curNumberOfGuns++;
        gunUp?.Invoke();
        ShowNewTips();
    }

    void ShowNewTips() 
    {
        for (int i = 0; i < curNumberOfGuns; i++) 
        {
            wheelButtons[i].SetActive(true);
            gunTips[i].SetActive(true);
        }
    }

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        ShowNewTips();
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

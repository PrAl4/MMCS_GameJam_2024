using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Icons;

public class WheelOfChoice : MonoBehaviour
{

    [SerializeField]
    GameObject playerObj;

    [SerializeField]
    GameObject topEnhanced;
    [SerializeField]
    GameObject righEnhanced;
    [SerializeField]
    GameObject bottomEnhanced;
    [SerializeField]
    GameObject leftEnhanced;

    enum gunModes { Top , Right, Bottom, Left };
    gunModes curGunMode = gunModes.Top;
    private int numberOfGunModes = System.Enum.GetValues(typeof(gunModes)).Length;


    private void OnEnable()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(playerObj.transform.position);
        this.GetComponent<RectTransform>().localPosition = new Vector3(temp.x - Screen.width / 2, temp.y - Screen.height/2, 0.0f); // WorldToScreenPoint WorldToViewportPoin
        Debug.Log(Camera.main.WorldToScreenPoint(playerObj.transform.position));
    }

    private void Update()
    {
        if (this.isActiveAndEnabled) 
        {
            Vector3 temp = Camera.main.WorldToScreenPoint(playerObj.transform.position);
            this.GetComponent<RectTransform>().localPosition = new Vector3(temp.x - Screen.width / 2, temp.y - Screen.height / 2, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            TwistWheelRight();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TwistWheelLeft();
        }

    }

    void TwistWheelRight() 
    {
        curGunMode += 1;
        if ((int)curGunMode == numberOfGunModes)
            curGunMode = 0;
        SetNewActiveGun();
    }

    void TwistWheelLeft() 
    {
        curGunMode -= 1;
        if ((int)curGunMode == -1)
            curGunMode = (gunModes)(numberOfGunModes - 1);
        SetNewActiveGun();
    }

    void SetNewActiveGun() 
    {
        switch (curGunMode) 
        {
            case gunModes.Top:
                {
                    topEnhanced.SetActive(true);
                    righEnhanced.SetActive(false);
                    bottomEnhanced.SetActive(false);
                    leftEnhanced.SetActive(false);
                    break;
                }

            case gunModes.Right: 
                {
                    topEnhanced.SetActive(false);
                    righEnhanced.SetActive(true);
                    bottomEnhanced.SetActive(false);
                    leftEnhanced.SetActive(false);
                    break;
                }

            case gunModes.Bottom:
                {
                    topEnhanced.SetActive(false);
                    righEnhanced.SetActive(false);
                    bottomEnhanced.SetActive(true);
                    leftEnhanced.SetActive(false);
                    break;
                }

            case gunModes.Left:
                {
                    topEnhanced.SetActive(false);
                    righEnhanced.SetActive(false);
                    bottomEnhanced.SetActive(false);
                    leftEnhanced.SetActive(true);
                    break;
                }
            default:
                throw new Exception("Как так 0_0");
        }
    }

}

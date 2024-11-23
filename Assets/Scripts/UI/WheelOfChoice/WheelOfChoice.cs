using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WheelOfChoice : MonoBehaviour
{

    [SerializeField]
    GameObject playerObj;

    private void OnEnable()
    {
        Vector3 temp = Camera.main.WorldToScreenPoint(playerObj.transform.position);
        this.GetComponent<RectTransform>().localPosition = new Vector3(temp.x - Screen.width / 2, temp.y - Screen.height/2, 0.0f); // WorldToScreenPoint WorldToViewportPoin
    }

    private void Update()
    {
        if (isActiveAndEnabled) 
        {
            Vector3 temp = Camera.main.WorldToScreenPoint(playerObj.transform.position);
            this.GetComponent<RectTransform>().localPosition = new Vector3(temp.x - Screen.width / 2, temp.y - Screen.height / 2, 0.0f);
        }
    }
}

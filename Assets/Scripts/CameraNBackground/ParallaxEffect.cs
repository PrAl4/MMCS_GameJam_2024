using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxEffect : MonoBehaviour
{

    public Camera _mainCamera;
    public float _amountOfParallax;
    private float _startPosition;
    float _lengthOfSprite;


    void Start()
    {
        _startPosition = transform.position.x;
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        Vector3 cameraPos = _mainCamera.transform.position;
        float temp = cameraPos.x * (1 - _amountOfParallax);
        float distance = cameraPos.x * _amountOfParallax;

        Vector3 newCameraPos = new Vector3(_startPosition + distance, transform.position.y, transform.position.z);

        transform.position = newCameraPos;
    }
}

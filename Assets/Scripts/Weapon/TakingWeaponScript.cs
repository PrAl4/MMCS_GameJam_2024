using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameDataScript;

public class TakingWeaponScript : MonoBehaviour
{
    [SerializeField] int _weaponNumber;

    GameDataScript _gameData;

    private void Start()
    {
        _gameData = GettingGameData.GetDataObj();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _gameData.AddNewGun(_weaponNumber);
            Destroy(gameObject);

        }
    }
}

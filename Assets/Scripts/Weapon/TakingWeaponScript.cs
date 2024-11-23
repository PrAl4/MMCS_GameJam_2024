using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;

public class TakingWeaponScript : MonoBehaviour
{

    public PlayerController _player;
    [SerializeField] int _weaponNumber;

    GameData _gameData;

    private void Start()
    {
        _gameData = GettingGameData.GetDataObj();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _player.WeaponKey = _weaponNumber;

            _gameData.AddNewGun(_weaponNumber);

            Destroy(gameObject);
        }
    }
}

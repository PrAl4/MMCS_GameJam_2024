using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingWeaponScript : MonoBehaviour
{
    public PlayerController _player;
    [SerializeField] int _weaponNumber;

    public static event Action<int> takingWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _player.WeaponKey = _weaponNumber;
            takingWeapon?.Invoke(_weaponNumber);
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game Data", order = 51)]
public class GameData : ScriptableObject
{
    public int _score;

    public bool havingGun = false;
    public enum gunModes { Without, Top, Right, Bottom, Left }; // Without = 0 = NoWeapon; Top = 1 = Scythe ; Right = 2 = Shield; Bottom = 3 = Wand; Left = 4 = Glove
    public gunModes curGunMode = gunModes.Without;

    public int unlockedGuns = 0; // счетик если 1 - Есть коса , если 2 - Есть коса + щит и т.д.

    public gunModes[] obtainedGuns = new gunModes[4]; // для понятия какие оружия мы уже получили (если мы умерли и потеряли что-то)

    public static event Action<int> OnTakingNewGun; // Подписываем у себя, где надо словить, что мы взяли новую оружку и экипировали ее
    public static event Action<int> OnSwithingToAnotherGunMode; // Подписываем у себя, где надо словить, что мы поменяли на новую оружку
    public event Action OnSwithingToNoGunMode; // Подписываем у себя, где надо словить, что мы убрали оружие

    public void AddNewGun(int gunNum) 
    {
        if (!obtainedGuns.Contains((gunModes)gunNum))
        {
            unlockedGuns++;
            curGunMode = (gunModes)gunNum;
            havingGun = true;
            obtainedGuns[gunNum - 1] = (gunModes)gunNum;

            OnTakingNewGun?.Invoke(gunNum);
        }
    }

    public void SetGunMode(int gunNum) 
    {
        curGunMode = (gunModes)gunNum;
        havingGun = true;

        OnSwithingToAnotherGunMode?.Invoke(gunNum);

    }

    public void SetNoGunMode() 
    {
        havingGun = false;
        curGunMode = gunModes.Without;

        OnSwithingToNoGunMode?.Invoke();

    }

    public void ResetLvlProgress(int gunNum) // Это надо еще обговорить
    {
        obtainedGuns[gunNum - 1] = gunModes.Without;
        if (unlockedGuns < 0)
            unlockedGuns = 0;
        else
            unlockedGuns--;

        if (unlockedGuns == 0)
        {
            havingGun = false;
            curGunMode = gunModes.Without;
        }
        else 
        {
            havingGun = true;
            curGunMode = gunModes.Top;
        }
    }
}

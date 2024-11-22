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

    public int unlockedGuns = 0; // ������ ���� 1 - ���� ���� , ���� 2 - ���� ���� + ��� � �.�.

    public gunModes[] obtainedGuns = new gunModes[4]; // ��� ������� ����� ������ �� ��� �������� (���� �� ������ � �������� ���-��)

    public static event Action<int> OnTakingNewGun; // ����������� � ����, ��� ���� �������, ��� �� ����� ����� ������ � ����������� ��
    public static event Action<int> OnSwithingToAnotherGunMode; // ����������� � ����, ��� ���� �������, ��� �� �������� �� ����� ������
    public event Action OnSwithingToNoGunMode; // ����������� � ����, ��� ���� �������, ��� �� ������ ������

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

    public void ResetLvlProgress(int gunNum) // ��� ���� ��� ����������
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

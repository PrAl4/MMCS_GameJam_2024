using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTipsBehaviour : MonoBehaviour
{
    GameDataScript gameData;
    SoundManager soundManager;

    private void Start()
    {
        gameData = GettingGameData.GetDataObj();
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameData.unlockedGuns >= 1)
        {
            soundManager.Play("ChangeWeapon");
            gameData.SetGunMode(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && gameData.unlockedGuns >= 2)
        {
            soundManager.Play("ChangeWeapon");
            gameData.SetGunMode(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && gameData.unlockedGuns >= 3)
        {
            soundManager.Play("ChangeWeapon");
            gameData.SetGunMode(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && gameData.unlockedGuns >= 4) 
        {
            soundManager.Play("ChangeWeapon");
            gameData.SetGunMode(4);
        }
    }
}

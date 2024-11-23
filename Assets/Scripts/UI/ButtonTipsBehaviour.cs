using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTipsBehaviour : MonoBehaviour
{
    GameData gameData;

    private void Start()
    {
        gameData = GettingGameData.GetDataObj();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameData.unlockedGuns >= 1)
        {
            gameData.SetGunMode(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && gameData.unlockedGuns >= 2)
        {
            gameData.SetGunMode(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && gameData.unlockedGuns >= 3)
        {
            gameData.SetGunMode(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && gameData.unlockedGuns >= 4) 
        {
            gameData.SetGunMode(4);
        }
    }
}

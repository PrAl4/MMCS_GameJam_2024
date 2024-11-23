using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFunctionality : MonoBehaviour
{
    GameData gameData;

    private int wheelCount = 1;

    private void Start()
    {
        gameData = GettingGameData.GetDataObj();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIShowManager.wheelIsActive && gameData.unlockedGuns >= 1)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                TwistWheelRight();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                TwistWheelLeft();
            }
        }

    }

    void TwistWheelRight()
    {
        wheelCount += 1;
        if (wheelCount > gameData.unlockedGuns)
            wheelCount = 1;
        gameData.SetGunMode(wheelCount);

        //soundManager.PlayButtonSound();

    }

    void TwistWheelLeft()
    {
        wheelCount -= 1;
        if (wheelCount < 1)
            wheelCount = gameData.unlockedGuns;

        gameData.SetGunMode(wheelCount);

        //soundManager.PlayButtonSound();
    }

}

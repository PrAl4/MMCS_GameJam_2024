using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GettingGameData
{

    static GameDataScript gameDataScript = null;

    public static GameDataScript GetDataObj() 
    {
        gameDataScript = Resources.Load<GameDataScript>("GameData");
        return gameDataScript;
    }
}

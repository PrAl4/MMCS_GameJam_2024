using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingGameData
{
    public static GameData GetDataObj() 
    {
        var gameDataAssets = Resources.FindObjectsOfTypeAll(typeof(GameData));
        if (gameDataAssets.Length > 0)
        {
            return gameDataAssets[0] as GameData;
        }
        return null;
    }
}

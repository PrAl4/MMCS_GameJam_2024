using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsData", menuName = "Settings Data", order = 51)]
public class SettingsData : ScriptableObject
{ 
    public float volume = 0.5f;
    public int _score;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadShaders : MonoBehaviour
{
    [SerializeField] Material _materialFirstLevel;
    [SerializeField] Material _materialSecondLevel;
    [SerializeField] Material _materialThirdLevel;
    [SerializeField] Material _materialFourthLevel;

    public void ReloadAll()
    {
        ReloadOneMaterial(_materialFirstLevel);
        ReloadOneMaterial(_materialSecondLevel);
        ReloadOneMaterial(_materialThirdLevel);
        ReloadOneMaterial(_materialFourthLevel);
    }

    public void ReloadOneMaterial(Material m) { m.SetFloat("_Distance", 0f); }
}

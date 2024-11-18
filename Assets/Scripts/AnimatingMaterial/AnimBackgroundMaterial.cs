using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMaterial : MonoBehaviour
{
    [SerializeField]
    Material mmaterial;

    public int numOfClouds;

    private void OnEnable()
    {
        TakingWeaponScript.takingWeapon += StartAniamtion;
    }

    private void OnDisable()
    {
        TakingWeaponScript.takingWeapon -= StartAniamtion;
    }

    void StartAniamtion(int num)
    {
        if (num == numOfClouds)
            StartCoroutine("Colorize");
    }

    IEnumerator Colorize()
    {
        for (float ft = 0.0f; ft <= 0.8f; ft += 0.01f)
        {
            mmaterial.SetFloat("_Distance", ft);
            yield return new WaitForSeconds(.01f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMaterial : MonoBehaviour
{
    [SerializeField]
    Material mmaterial;

    GameData gameData;

    public int numOfClouds;

    private void OnEnable()
    {
        GameData.OnTakingNewGun += StartAniamtion;
    }

    private void OnDisable()
    {
        GameData.OnTakingNewGun -= StartAniamtion;
    }

    private void Start()
    {
        gameData = GettingGameData.GetDataObj();
        if (numOfClouds <= gameData.unlockedGuns)
            mmaterial.SetFloat("_Distance", 0.7f);
        else 
            mmaterial.SetFloat("_Distance", 0.0f);
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

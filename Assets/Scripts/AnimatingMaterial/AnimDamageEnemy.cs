using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDamageEnemy : MonoBehaviour
{

    [SerializeField]
    Material mmaterial;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void StartAniamtion()
    {
        StartCoroutine("Damage");
    }

    IEnumerator Damage()
    {
        mmaterial.SetInt("_Damaged", 1);
        yield return new WaitForSeconds(.15f);
        mmaterial.SetInt("_Damaged", 0);
    }
}

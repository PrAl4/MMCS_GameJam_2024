using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    GameDataScript gameData;

    private Animator animator;

    private bool isAttack = false;
    private bool isJumping = false;
    private bool isRunning = false;

    private void OnEnable()
    {
        GameDataScript.OnSwithingToAnotherGunMode += changeAnimation;
        GameDataScript.OnTakingNewGun += changeAnimation;
        PlayerController.isJumping += changeJumpingState;
        PlayerController.isRunning += changeRunningState;
        PlayerController.isAttacking += changeAttackingState;
    }

    private void OnDisable()
    {
        GameDataScript.OnSwithingToAnotherGunMode -= changeAnimation;
        GameDataScript.OnTakingNewGun -= changeAnimation;
        PlayerController.isJumping -= changeJumpingState;
        PlayerController.isRunning -= changeRunningState;
        PlayerController.isAttacking -= changeAttackingState;
    }

    private void Start()
    {
        gameData = GettingGameData.GetDataObj();
        animator = GetComponent<Animator>();
        animator.SetInteger("WeaponKey", (int)gameData.curGunMode); // Без оружия
    }

    void changeAnimation(int weaponKey)  //0 - без, 1 - коса, 2 - щит, 3 - посох, 4 - лазер. Менять каждый раз при переключении оружия.
    {
        animator.SetInteger("WeaponKey", weaponKey);
    }

    void changeRunningState(bool state) 
    {
        isRunning = state;
        animator.SetBool("IsRuning", isRunning);
    }

    void changeJumpingState(bool state) 
    {
        isJumping = state;
        animator.SetBool("IsJumping", isJumping);
    }

    void changeAttackingState(bool state) 
    {
        isAttack = state;
        animator.SetBool("IsAttack", isAttack);
    }
}

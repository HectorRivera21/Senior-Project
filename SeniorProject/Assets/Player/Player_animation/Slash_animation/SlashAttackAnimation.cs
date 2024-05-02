using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SlashAttackAnimation : MonoBehaviour
{
    //Player animation states
    Animator _animator;
    // Player Animations
    string _currentState;
    const string NOTHING = "Nothing";
    const string PLAYER_SLASH_UP = "Player_slash_up";
    const string PLAYER_SLASH_LEFT = "Player_slash_left";
    const string PLAYER_SLASH_RIGHT = "Player_slash_right";
    const string PLAYER_SLASH_DOWN = "Player_slash_down";


    PlayerShoot playerShoot;

    PlayerSfx player_sounds;
    // Start is called before the first frame update
    void Start()
    {
        player_sounds = GetComponentInParent<PlayerSfx>();
        _animator = gameObject.GetComponent<Animator>();
        playerShoot = GetComponentInChildren<PlayerShoot>();
    }

    private void ChangeAnimationState(string newState){
        if(newState == _currentState){
            return;
        }
        _animator.Play(newState);
        _currentState = newState;
    }
    bool IsAnimationPlaying(Animator animator, string stateName){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f){
            return true;
        }
        else{
            return false;
        }
    }


    public void SlashUP(){
        player_sounds.PlayerSwoosh();
        Debug.Log("ATTACKING UP");
        // ChangeAnimationState(PLAYER_SLASH_UP);
        _animator.SetTrigger("attack_up");
        // playerShoot.Shoot();
    }
    public void SlashDown(){
        player_sounds.PlayerSwoosh();
        // ChangeAnimationState(PLAYER_SLASH_DOWN);
        _animator.SetTrigger("attack_down");
        // playerShoot.Shoot();
    }
    public void SlashLeft(){
         player_sounds.PlayerSwoosh();
        // ChangeAnimationState(PLAYER_SLASH_LEFT);
        _animator.SetTrigger("attack_left");
        // playerShoot.Shoot();
    }
    public void SlashRight(){
        player_sounds.PlayerSwoosh();
        // ChangeAnimationState(PLAYER_SLASH_RIGHT);
        _animator.SetTrigger("attack_right");
        // playerShoot.Shoot();

    }
    public void Nothing(){
        ChangeAnimationState(NOTHING);
    }
    public void ResetAnimation(){
        _animator.ResetTrigger("attack_up");
        _animator.ResetTrigger("attack_left");
        _animator.ResetTrigger("attack_right");
        _animator.ResetTrigger("attack_down");
    }
}
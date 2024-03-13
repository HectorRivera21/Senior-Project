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
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
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
        Debug.Log("ATTACKING UP");
        // ChangeAnimationState(PLAYER_SLASH_UP);
        _animator.SetTrigger("attack_up");
    }
    public void SlashDown(){
        // ChangeAnimationState(PLAYER_SLASH_DOWN);
        _animator.SetTrigger("attack_down");
    }
    public void SlashLeft(){
        // ChangeAnimationState(PLAYER_SLASH_LEFT);
        _animator.SetTrigger("attack_left");
    }
    public void SlashRight(){
        // ChangeAnimationState(PLAYER_SLASH_RIGHT);
        _animator.SetTrigger("attack_right");
        
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

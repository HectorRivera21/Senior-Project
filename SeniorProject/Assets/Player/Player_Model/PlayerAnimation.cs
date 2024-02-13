using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //physics
    public bool _disablePlayerMove;
    private bool _isLeft;
    private bool _isRight;
    private float _inputHorizontal;
    private float _playerSpeed;
    private float _playerMaxVel;
    private bool _isFliped;
    public Rigidbody2D _rb;
    // [SerializeField] private ;

    //Player animation states
    Animator _animator;
    string _currentState;
    const string PLAYER_IDLE = "Player_Idle";
    private bool _is_idle;
    const string PLAYER_RUN = "Player_Run";
    private void Start() {
        _animator = gameObject.GetComponent<Animator>();
        _isRight = true;
        _isLeft = false;
        _is_idle = false;
        ChangeAnimationState(PLAYER_IDLE);
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

    private void Update() {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        // Debug.Log(_inputHorizontal);
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && _is_idle == true){
            Debug.Log("moving");
            ChangeAnimationState(PLAYER_RUN);
        }
        else{
            _is_idle = true;
            Debug.Log("standing");
            ChangeAnimationState(PLAYER_IDLE);
        }
       
    }

    private void Flip(){
        if(_inputHorizontal > 0 && _isLeft == true){
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y,transform.localScale.z);
            _isRight = true;
            _isLeft = false;
        }
        else if(_inputHorizontal < 0 && _isRight == true){
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y,transform.localScale.z);
            _isRight = false;
            _isLeft = true;
        }
    }

}
 
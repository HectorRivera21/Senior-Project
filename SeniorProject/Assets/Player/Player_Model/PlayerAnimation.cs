using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    // AttackStricpt
    SlashAttackAnimation attackAni;
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
    // Player Animations
    string _currentState;
    const string PLAYER_IDLE = "Player_Idle";
    private bool _is_idle;
    const string PLAYER_RUN = "Player_Run";
    const string PLAYER_UPRUN = "Player_UpRun";
    const string PLAYER_DOWNRUN = "Player_Down";

    float attack_cooldown = 1f;

    string last_input = "";


    private void Start() {
        _animator = gameObject.GetComponent<Animator>();
        attackAni = gameObject.GetComponentInChildren<SlashAttackAnimation>();
        _isRight = true;
        _isLeft = false;
        _is_idle = false;
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
        if(Input.GetKey(KeyCode.W)){
            // Debug.Log("moving");
            ChangeAnimationState(PLAYER_UPRUN);
            last_input = "w";
        }
         // Debug.Log(_inputHorizontal);
        else if(Input.GetKey(KeyCode.S)){
            // Debug.Log("moving");
            ChangeAnimationState(PLAYER_DOWNRUN);
            last_input = "s";
        }
        else if(Input.GetKey(KeyCode.A)){
            // Debug.Log("moving");
            ChangeAnimationState(PLAYER_RUN);
            last_input = "a";
        } else if(Input.GetKey(KeyCode.D)){
            // Debug.Log("moving");
            ChangeAnimationState(PLAYER_RUN);
            last_input = "d";
        }
        else{
            _is_idle = true;
            // Debug.Log("standing");
            ChangeAnimationState(PLAYER_IDLE);
            // attackAni.Nothing();
        }

        if(Input.GetKeyUp(KeyCode.Space) && attack_cooldown < 0){
            PlayAttack(last_input);
            attack_cooldown = 1f;
        }
        else{
            attack_cooldown -= Time.deltaTime;
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

    void PlayAttack(string x ){
        if(x == "w"){
            attackAni.SlashUP();
        }
        else if(x == "s"){
            attackAni.SlashDown();
        }
        else if(x == "a"){
            attackAni.SlashRight();
        }
        else if(x == "d"){
            attackAni.SlashRight();
        }
    }

}
 
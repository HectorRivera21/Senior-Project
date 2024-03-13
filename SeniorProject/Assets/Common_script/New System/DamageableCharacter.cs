using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour , IDamageable
{
    float _health;
    bool _targetable = true;
    bool invicible = false;
    
    public bool canTurnInvicible = false;
    public float InvincibleTime = 1f;

    Rigidbody2D rb;
    Collider2D physicsCollider;

    bool is_alive = true;

    private float InvincibleTomeElapsed = 0f;

    public bool _invincidble = false;
    

    public float Health {
        set{
            _health = value;

            if(_health <= 0){
                is_alive = false;
                
            }
        }

        get{
            return _health;
        }
        
    }

    public bool Targetable{
        set{
            _targetable = value;
            physicsCollider.enabled = value;
        }
        get{
            return _targetable;
        }
    }

    public bool Invincible{
        get{
            return invicible;
        }
        set{
            _invincidble = value;
        }
    }

    // bool IDamageable.Targetable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<BoxCollider2D>();
    }

    public void OnHit(float damage, Vector2 knockback){
        Health -= damage;
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    public void OnObjectDestroyed(){
        Destroy(gameObject);
    }
}

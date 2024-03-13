using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_hurtBox : MonoBehaviour
{
    GameObject main;
    int e_health;
    // Start is called before the first frame update
    void Start()
    {
        e_health = gameObject.GetComponentInParent<check>().health;
        // Debug.Log("Starting e_health " + e_health);
    }

    // Update is called once per frame
    void Update()
    {
        e_health = gameObject.GetComponentInParent<check>().health;
    }

     private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other);
        if(other.name == "HitBox"){
            int damage = other.GetComponentInParent<PlayerAttr>().damage;
            gameObject.GetComponentInParent<check>().e_damage(damage);
            Debug.Log(other.name);
            Debug.Log("Enemey " + e_health);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    bool can_swing = true;
    float can_swing_time = 1;


    Collider2D hitbox;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate() {  

        can_swing_time -= Time.deltaTime;
        if(can_swing_time < 0){
            if(Input.GetKeyUp(KeyCode.Mouse0)){
                // play animation
                hitbox.enabled = true;
                hitbox.enabled = false;
                can_swing_time = 1;
            }
        }
       
       
    }
}

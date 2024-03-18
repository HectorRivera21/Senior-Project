using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boots : MonoBehaviour
{
    private DamianMovement player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamianMovement>();
    }
    public void IncreaseSpeed(){
        Debug.Log("adding speed");
        //player.move_speed += 5f;
    }
}

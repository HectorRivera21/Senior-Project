using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boots : MonoBehaviour
{
    private Movement player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    public void IncreaseSpeed(){
        Debug.Log("adding speed");
        //player.move_speed += 5f;
    }
}

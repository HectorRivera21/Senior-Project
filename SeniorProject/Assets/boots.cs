using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class boots : MonoBehaviour
{
    private DamianMovement player;
    private PlayerAttr playerAttr;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamianMovement>();
        playerAttr = player.GetComponent<PlayerAttr>();
    }
    public void IncreaseSpeed(){
        Debug.Log("adding speed");
        player.move_speed += 5f;
    }

    public void IncreaseHealth(){
        // Debug.Log("Adding health: ");
        playerAttr.health += 5;
        playerAttr.current_health += 5;
        Debug.Log("Adding health: " + playerAttr.current_health);
    }

    public void IncreaseDamage(){
        // Debug.Log("Adding health: ");
        playerAttr.damage += 1;
        Debug.Log("Adding health: " + playerAttr.damage);
    }
}

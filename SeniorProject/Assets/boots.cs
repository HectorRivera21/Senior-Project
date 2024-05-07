using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class boots : MonoBehaviour
{
    private DamianMovement player;
    private PlayerAttr playerAttr;
    PlayerHitBox playerHitBox;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamianMovement>();
        playerHitBox = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerHitBox>();
        playerAttr = player.GetComponent<PlayerAttr>();
    }
    public void IncreaseSpeed(){
        Debug.Log("adding speed");
        player.move_speed += 1f;
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
        Debug.Log("Adding Damage: " + playerAttr.damage);
    }

    public void IncreaseAttackSpeed(){
        // Debug.Log("Adding health: ");
        playerAttr.range_attack = true;
        playerAttr.How_many_bullets += 1;
        Debug.Log("Adding Attack Speed: " + playerHitBox.max_can_swing_time);
    }
    public void HeatlhGain(){
        playerAttr.health += 5;
        Debug.Log("Gaining health" + playerAttr.current_health);
    }
}

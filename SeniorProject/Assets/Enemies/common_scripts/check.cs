using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class check : MonoBehaviour
{
    public enemeis me;
    public int health;

    public ExpBar xpBar;

    PlayerAttr player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponentInParent<PlayerAttr>();
        health = me.health;
        xpBar = GameObject.Find("ExpBar").GetComponent<ExpBar>();
        //Debug.Log("Starting e_ health " + health);
    }

    void Update() {
        // health = me.health;
        if(health <= 0){
            exp();
            //Debug.Log("DESTROYING OBJ");
            gameObject.GetComponentInChildren<DropItem>().Drop_Item();
            player.gold += me.gold_drop;
            player.enemiesToKilled -= 1;
            player.enemiesKilled += 1;
            Destroy(gameObject);
        }
    }

    public void e_damage(int x){
        health -= x;
    }

    void exp(){
        xpBar.SetMaxExp(player.how_exp);
        player.exp += me.exp;
        xpBar.SetExp(player.exp);
        //Debug.Log( "EXP" + player.exp);
    }
}

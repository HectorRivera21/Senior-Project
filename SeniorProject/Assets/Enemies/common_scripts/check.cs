using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class check : MonoBehaviour
{
    public enemeis me;
    public int health;

    PlayerAttr player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponentInParent<PlayerAttr>();
        health = me.health;
        //Debug.Log("Starting e_ health " + health);
    }

    void Update() {
        // health = me.health;
        if(health <= 0){
            exp();
            //Debug.Log("DESTROYING OBJ");
            gameObject.GetComponentInChildren<DropItem>().Drop_Item();
            player.gold += me.gold_drop;
            Destroy(gameObject);
        }
    }

    public void e_damage(int x){
        health -= x;
    }

    void exp(){
        player.exp += me.exp;
        //Debug.Log( "EXP" + player.exp);
    }
}

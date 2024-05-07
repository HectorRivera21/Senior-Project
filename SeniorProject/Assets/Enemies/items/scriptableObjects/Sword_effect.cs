using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_effect : MonoBehaviour
{
    public items myItem;
    private GameObject target;
    Player_items player_Items;
    PlayerHitBox playerHitBox;

    private boots myBoots;
    public List<items> itemList = new List<items>();

    private void Awake(){
        // myItem = gameObject.GetComponent<items>();
        target = GameObject.FindGameObjectWithTag("Player");
        player_Items = target.GetComponent<Player_items>();
        myBoots = gameObject.GetComponent<boots>();
        playerHitBox = target.GetComponentInChildren<PlayerHitBox>();
        // Debug.Log("OBJ NAME : " + myItem.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other.name);
        if(other.name == target.name){
            Debug.Log("IT WORKS");
            Debug.Log(gameObject);
            myBoots.IncreaseDamage();
            //items newItem = itemList[0];
            //Inventory.instance.AddItem(Instantiate(newItem));
            Destroy(gameObject);
        }
        // target
    }
}

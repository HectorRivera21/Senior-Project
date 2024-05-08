using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemSlot : MonoBehaviour
{
    public Image icon;
    private items item;

    private boots myHeart;
    private boots myBoots;
    private boots mySword;
    private boots myPot;

    private GameObject target;

    Player_items player_Items;

    private PlayerAttr myPlayer;
    private DamianMovement player;
    public HealthBar HP;

    public void AddItem(items newItem){
        item = newItem;
        icon.sprite = newItem.art;
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamianMovement>();
        myPlayer = player.GetComponent<PlayerAttr>();
        HP = myPlayer.HP;
    }

    public void ClearSlot(){
        item = null;
        icon.sprite = null;
    }

    public void UseItem(){
        if(item == null) return;
        if(Input.GetKey(KeyCode.LeftAlt)){
            Debug.Log("trying to switch");
            Inventory.instance.SwitchHotbarInventory(item);
        }else{
            Debug.Log("Using " + item.itemName);
            switch(item.itemName){
            case "Heart of Healing":
                myPlayer.health += 5;
                myPlayer.current_health += 5;
                HP.SetMaxHealth(myPlayer.health);
                HP.SetHealth(myPlayer.current_health);
                Inventory.instance.RemoveItem(item);
                break;
            case "Boots Of Swiftness":
                player.move_speed += 5;
                Inventory.instance.RemoveItem(item);
                break;
            case "Sword of Power":
                myPlayer.damage += 1;
                Inventory.instance.RemoveItem(item);
                break;
            case "Potion of Healing":
                if((myPlayer.current_health + 5) >= myPlayer.health){
                    myPlayer.current_health = myPlayer.health;
                } else{
                    myPlayer.current_health += 5;
                }
                //HP.SetMaxHealth(myPlayer.health);
                //HP.SetHealth(myPlayer.current_health);
                Inventory.instance.RemoveItem(item);
                Debug.Log("Potion health" + myPlayer.current_health);
                break;
            default:
                Debug.Log("testing inventory");
                break;
            }      
        }
    }

    public void DestroySlot(){
        Destroy(gameObject);
    }
}

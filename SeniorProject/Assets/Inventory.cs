using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region singleton

    public static Inventory instance;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChange = delegate {};

    public List<items> inventoryList = new List<items>();

    public List<items> hotbarItemList = new List<items>();
    public HotBarController hotbarController;

    public void SwitchHotbarInventory(items item){
        foreach(items i in inventoryList){
            if(i == item){
                if(hotbarItemList.Count >= hotbarController.HotbarSlotSize){
                    Debug.Log("No more slots available in hotbar");
                } else {
                    hotbarItemList.Add(item);
                    inventoryList.Remove(item);
                    onItemChange.Invoke();
                }
                return;
            }
        }

        foreach(items i in hotbarItemList){
            if(i == item){
                hotbarItemList.Remove(item);
                inventoryList.Add(item);
                onItemChange.Invoke();
                return;
            }
        }
    }

    public void AddItem(items item){
        //inventoryList.Add(item);
        hotbarItemList.Add(item);
        onItemChange.Invoke();
    }

    public void RemoveItem(items item){
        if(inventoryList.Contains(item)){
            inventoryList.Remove(item);
        } else if (hotbarItemList.Contains(item)){
            hotbarItemList.Remove(item);
        }
        onItemChange.Invoke();
    }
}

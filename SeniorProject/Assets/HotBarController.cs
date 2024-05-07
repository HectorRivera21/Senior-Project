using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarController : MonoBehaviour
{
    public int HotbarSlotSize => gameObject.transform.childCount;
    private List<itemSlot> hotbarSlots = new List<itemSlot>();

    KeyCode[] hotbarKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};

    private void Start(){
        SetUpHotbarSlots();
        Inventory.instance.onItemChange += UpdateHotbarUI;
    }
    private void Update(){
        for(int i = 0; i < hotbarKeys.Length; i++){
            if(Input.GetKeyDown(hotbarKeys[i])){
                Debug.Log("Use item: " + i);
                hotbarSlots[i].UseItem();
                return;
            }
        }
    }

    private void UpdateHotbarUI(){
        int currentUsedSlotCount = Inventory.instance.hotbarItemList.Count;
        for(int i = 0; i < HotbarSlotSize; i++){
            if(i < currentUsedSlotCount){
                hotbarSlots[i].AddItem(Inventory.instance.hotbarItemList[i]);
            } else{
                hotbarSlots[i].ClearSlot();
            }
        }
    }

    private void SetUpHotbarSlots(){
        for(int i = 0; i < HotbarSlotSize; i++){
            itemSlot slot = gameObject.transform.GetChild(i).GetComponent<itemSlot>();
            hotbarSlots.Add(slot);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private bool inventoryOpen = false;
    public bool InventoryOpen => inventoryOpen;
    public GameObject inventoryParent;
    public GameObject inventoryTab;

    private List<itemSlot> itemSlotList = new List<itemSlot>();
    public GameObject itemSlotPrefab;
    public Transform inventoryItemTransform;

    private void Start(){
        Inventory.instance.onItemChange += UpdateInventoryUI;
        UpdateInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)){
            if(inventoryOpen){
                //close inventory
                CloseInventory();
            } else {
                //open inventory
                OpenInventory();
            }
        }
    }

    private void UpdateInventoryUI(){
        int currentItemCount = Inventory.instance.inventoryList.Count;

        if(currentItemCount > itemSlotList.Count){
            //add item slots
            AddItemSlots(currentItemCount);
        }

        for(int i = 0; i < itemSlotList.Count; i++){
            if(i < currentItemCount){
                //update current item in slot
                itemSlotList[i].AddItem(Inventory.instance.inventoryList[i]);
            } else {
                itemSlotList[i].DestroySlot();
                itemSlotList.RemoveAt(i);
            }
        }
    }

    private void AddItemSlots(int currentItemCount){
        int amount = currentItemCount - itemSlotList.Count;

        for(int i = 0; i < amount; i++){
            GameObject GO = Instantiate(itemSlotPrefab, inventoryItemTransform);
            itemSlot newSlot = GO.GetComponent<itemSlot>();
            itemSlotList.Add(newSlot);
        }
    }

    private void OpenInventory(){
        inventoryOpen = true;
        inventoryParent.SetActive(true);
    }

    private void CloseInventory(){
        inventoryOpen = false;
        inventoryParent.SetActive(false);
    }
}

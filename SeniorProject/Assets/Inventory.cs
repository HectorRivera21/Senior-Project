using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    private List<items> itemList;

    public Inventory(){
        itemList = new List<items>();

        //AddItem(new items {itemName = })

         Debug.Log("Inventory");
    }

    public void AddItem(items item){
        itemList.Add(item);
    }
}

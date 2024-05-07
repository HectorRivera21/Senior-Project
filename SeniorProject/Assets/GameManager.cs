using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<items> itemList = new List<items>();

    private void Update(){
        if(Input.GetKeyDown(KeyCode.X)){
            items newItem = itemList[Random.Range(0, itemList.Count)];
            Inventory.instance.AddItem(Instantiate(newItem));
        }
    }
}

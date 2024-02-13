using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_items : MonoBehaviour
{
    List<GameObject> playerItems;
    // Start is called before the first frame update
    public void AddItem(GameObject itemtoAdd){
        playerItems.Add(itemtoAdd);
        // foreach (GameObject i in playerItems){
        //     Debug.Log(i);
        // }
    }
}

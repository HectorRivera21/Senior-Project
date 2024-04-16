using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "items", menuName = "items" )]
public class items : ScriptableObject {
    // adding what items should have 
    public string itemName;
    public string description;
    public Sprite art;
    public int itemCost;
   

    

}

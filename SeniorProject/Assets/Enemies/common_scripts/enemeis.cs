using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemeis", menuName = "BadGuys")]
public class enemeis : ScriptableObject {
    public string e_name;
    public string description;
    public Sprite art;
    public int health;
    public int damage;

    public int exp;
    public int gold_drop;
    
    public void Print(){
        Debug.Log(e_name + " " + description + " ");
    }


}

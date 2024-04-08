using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerAttr : MonoBehaviour
{
    public int health = 10;

    public int current_health = 10;
    public int damage = 2;
    public int exp = 0;

    public int gold = 0;


    int how_exp = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(exp >= how_exp){
            LevelUp();
        }
    }

    void LevelUp(){
        int health_up = health/4;
        int percent_health = health/5;
        Debug.Log("LEVEL_UP");
        how_exp *= 2;
        exp = 0;
        health += health_up;
        if(current_health + percent_health >= health){
            current_health = health;
            Debug.Log("If New current health: " + current_health);
        }
        else{
            current_health += percent_health;
            Debug.Log("Else New current health: " + current_health);
        }
    }
}

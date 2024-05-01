using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemies : MonoBehaviour
{
    private RoomTemps temps;
    void Start()
    {
        temps = GameObject.FindGameObjectWithTag("Enemies").GetComponent<RoomTemps>();
        temps.enemies.Add(this.gameObject);
    }
}

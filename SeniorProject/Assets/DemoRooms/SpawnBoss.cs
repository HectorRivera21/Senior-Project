using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
     bool have_spawn =false;
    SpawnE spawnE;
    PlayerAttr playerAttr;
    DefeatedRoom defeatedRoom;
    DefeatedRoom[] scripts;
    // Start is called before the first frame update
    void Start()
    {
        playerAttr = GameObject.FindWithTag("Player").GetComponent<PlayerAttr>();
        scripts = FindObjectsOfType<DefeatedRoom>();
        defeatedRoom = GameObject.FindWithTag("Normal Door").GetComponent<DefeatedRoom>();
        spawnE = GetComponentInParent<SpawnE>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("SPAWN DA FOOLS");
        if(other.tag == "Player" && have_spawn == false){
            Debug.Log("SPAWN DA FOOLS In if");
            spawnE.BossSpawn();
            have_spawn = true;
        }
    }
}

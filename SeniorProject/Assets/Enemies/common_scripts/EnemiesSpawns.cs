using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawns : MonoBehaviour
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

    // Update is called once per frame
 
    IEnumerator SpawnEnemies()
    {
        Debug.Log("waiting");
        // float randomNumberx = Random.Range(-3f, 3f);
        // float randomNumbery = Random.Range(-3f, 3f);

        // Wait for 5 seconds
        yield return new WaitForSeconds(.5f);
        if(playerAttr.how_many_romms % 3 == 0 && playerAttr.how_many_romms != 0){
            spawnE.SpawnShop(new Vector3(0f,0f,0f),gameObject.transform.parent.position);
            playerAttr.how_many_romms +=1;
        }
        else{

        
        for(int i=0; i<5;i++){
            float randomNumberx = Random.Range(-2f, 2f);
            float randomNumbery = Random.Range(-2f, 2f);
            int e_number = Random.Range(0, 6);
            switch (e_number){
            case 0:
                spawnE.SpawnSlime1(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
                playerAttr.enemiesToKilled += 1;
                break;
            case 1:
                spawnE.SpawnSlime2(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
                playerAttr.enemiesToKilled += 1;
                break;
            case 2:
                spawnE.SpawnSlime3(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
                playerAttr.enemiesToKilled += 1;
                break;
            case 3:
                spawnE.SpawnGaurdain1(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
                playerAttr.enemiesToKilled += 1;
                break;
            case 4:
                spawnE.SpawnGaurdain2(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
                playerAttr.enemiesToKilled += 1;
                break;
            case 5:
                spawnE.SpawnGaurdain3(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
                playerAttr.enemiesToKilled += 1;
                break;
            default:
                Debug.Log("nada");
                break;
            }
            // spawnE.SpawnSlime1(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
        }
        // spawnE.SpawnSlime(new Vector3(randomNumberx,randomNumbery, 0f), gameObject.transform.parent.position);
        foreach (DefeatedRoom script in scripts)
        {
            // Access or modify properties or methods of each script
            script.SetChildrenCollidersToTrigger(false);
            script.has_changed = false;
        }
        playerAttr.how_many_romms +=1;
        Debug.Log("Rooms cleard: " + playerAttr.how_many_romms);
        Debug.Log("Done spawning");
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("SPAWN DA FOOLS");
        if(other.tag == "Player" && have_spawn == false){
            Debug.Log("SPAWN DA FOOLS In if");
            StartCoroutine(SpawnEnemies());
            have_spawn = true;
        }
    }

    
}

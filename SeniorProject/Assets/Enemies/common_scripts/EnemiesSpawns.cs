using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawns : MonoBehaviour
{

    bool have_spawn =false;
    SpawnE spawnE;
    PlayerAttr playerAttr;
    // Start is called before the first frame update
    void Start()
    {
        spawnE = GetComponentInParent<SpawnE>();
        playerAttr = GameObject.FindWithTag("Player").GetComponent<PlayerAttr>();
    //    Debug.Log(gameObject.name + " local spce:" + gameObject.transform.position); 
        //StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        Debug.Log("waiting");
        // float randomNumberx = Random.Range(-3f, 3f);
        // float randomNumbery = Random.Range(-3f, 3f);

        // Wait for 5 seconds
        yield return new WaitForSeconds(.5f);
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

        Debug.Log("Done spawning");
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

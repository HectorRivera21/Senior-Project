using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject spawnItem1;
    public GameObject spawnItem2;
    public GameObject spawnItem3;

    public PlayerAttr myPlayer;
    public Transform playerTransform;
    GameObject E_enemy;

    private GameObject playerClone;
    int irandom;

    int random = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(random);
        // Instantiate(spawnItem);

        E_enemy = gameObject;
        // Drop_Item();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop_Item(){
        random = Random.Range(0,100);
        irandom= Random.Range(0,4);
        // Debug.Log(random);
        if(random > 50){
            // Debug.Log("Drop item");
            switch(irandom){
            case 0:
                Instantiate(spawnItem1, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
                break;
            case 1:
                Instantiate(spawnItem2, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
                break;
            case 2:
                Instantiate(spawnItem3, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
                break;
            default:
                UnityEngine.Debug.Log("couldnt spawn items");
                break;
            }
            // Instantiate(spawnItem1, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
        }
    }

    public void Instant_Drop(){
        Vector3 spawnPosition = playerClone.transform.position + (Vector3.right * 3f);
        Instantiate(spawnItem1, spawnPosition, Quaternion.identity);
    }

    public void SetPlayerClone(GameObject clone)
    {
        playerClone = clone;
    }
}

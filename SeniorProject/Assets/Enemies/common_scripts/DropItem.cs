using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject spawnItem;

    public PlayerAttr myPlayer;
    public Transform playerTransform;
    GameObject E_enemy;

    private GameObject playerClone;

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
        // Debug.Log(random);
        if(random > 50){
            // Debug.Log("Drop item");
            Instantiate(spawnItem, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
        }
    }

    public void Instant_Drop(){
        Vector3 spawnPosition = playerClone.transform.position + (Vector3.right * 3f);
        Instantiate(spawnItem, spawnPosition, Quaternion.identity);
    }

    public void SetPlayerClone(GameObject clone)
    {
        playerClone = clone;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public GameObject spawnItem;
    public GameObject bootItem;
    public GameObject heartItem;
    public GameObject swordItem;
    public PlayerAttr myPlayer;
    public Transform playerTransform;
    GameObject E_enemy;

    private GameObject playerClone;
    int irandom;

    int random = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerAttr>();
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
                Instantiate(bootItem, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
                break;
            case 1:
                Instantiate(heartItem, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
                break;
            case 2:
                Instantiate(swordItem, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
                break;
            default:
                UnityEngine.Debug.Log("couldnt spawn items");
                break;
            }
            // Instantiate(spawnItem1, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
        }
    }

    // public void Instant_Drop1(){
    //     Vector3 spawnPosition = playerClone.transform.position + (Vector3.right * 3f);
    //     Instantiate(spawnItem1, spawnPosition, Quaternion.identity);
    // }
    public void Instant_Drop(string name){
        Vector3 spawnPosition = myPlayer.transform.position + (Vector3.right * 3f);
        switch(name){
        case "Boots Of Swiftness":
            Instantiate(bootItem, spawnPosition, transform.rotation);
            break;
        case "Heart of Healing":
            Instantiate(heartItem, spawnPosition, Quaternion.identity);
            break;
        case "Sword of Power":
            Instantiate(swordItem, spawnPosition, Quaternion.identity);
            break;
        default:
            UnityEngine.Debug.Log("testing shop");
            break;
        }
    }

    public void SetPlayerClone(GameObject clone)
    {
        playerClone = clone;
    }
}

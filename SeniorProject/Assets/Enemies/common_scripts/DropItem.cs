using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject spawnItem;
    GameObject E_enemy;

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
            Debug.Log("Drop item");
            Instantiate(spawnItem, new Vector2 (transform.position.x,transform.position.y), transform.rotation);
        }
    }
}

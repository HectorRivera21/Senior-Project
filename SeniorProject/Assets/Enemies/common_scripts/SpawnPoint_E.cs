using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_E : MonoBehaviour
{
    public GameObject Slime;
    public GameObject Gaurdian;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnSlime(Transform child){
        
        Vector3 spawnPos = new Vector3(child.position.x,child.position.y,-.5f);
        GameObject newObject = Instantiate(Slime, spawnPos, Quaternion.identity);
        Debug.Log("SPAWNING SLIME");
    }

    public void SpawnGaurdain(Transform child){
        Vector3 spawnPos = new Vector3(child.position.x,child.position.y,-.5f);
        GameObject newObject = Instantiate(Gaurdian, spawnPos, Quaternion.identity);
        Debug.Log("SPAWNING GAURDAIN");
    }
}

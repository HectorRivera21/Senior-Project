using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
    public GameObject slime;
     public GameObject Gaurdian;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnSlime(){
        Vector3 spawnPos = new Vector3(0,0,0);
        GameObject newObject = Instantiate(slime, spawnPos, Quaternion.identity);
        Debug.Log("SPAWNING SLIME");
    }

    public void SpawnGaurdain(){
        Vector3 spawnPos = new Vector3(0,0,0);
        GameObject newObject = Instantiate(Gaurdian, spawnPos, Quaternion.identity);
        Debug.Log("SPAWNING GAURDAIN");
    }
}

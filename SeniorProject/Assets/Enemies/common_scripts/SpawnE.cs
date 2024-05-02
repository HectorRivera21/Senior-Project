using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
    public GameObject slime1;
    public GameObject slime2;
    public GameObject slime3;
    public GameObject Guardian1;
    public GameObject Guardian2;
    public GameObject Guardian3;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnSlime1(Vector3 pos, Vector3 currentpos){
        pos += currentpos;
        Vector3 spawnPos = pos;
        GameObject newObject = Instantiate(slime1, spawnPos, Quaternion.identity);
        Debug.Log("slime1");
    }
    public void SpawnSlime2(Vector3 pos, Vector3 currentpos){
        pos += currentpos;
        Vector3 spawnPos = pos;
        GameObject newObject = Instantiate(slime2, spawnPos, Quaternion.identity);
        Debug.Log("slime2");
    }
    public void SpawnSlime3(Vector3 pos, Vector3 currentpos){
        pos += currentpos;
        Vector3 spawnPos = pos;
        GameObject newObject = Instantiate(slime3, spawnPos, Quaternion.identity);
        Debug.Log("slime3");
    }

    public void SpawnGaurdain1(Vector3 pos, Vector3 currentpos){
        pos += currentpos;
        Vector3 spawnPos = pos;
        GameObject newObject = Instantiate(Guardian1, spawnPos, Quaternion.identity);
        Debug.Log("Guardian1");
    }
    public void SpawnGaurdain2(Vector3 pos, Vector3 currentpos){
        pos += currentpos;
        Vector3 spawnPos = pos;
        GameObject newObject = Instantiate(Guardian2, spawnPos, Quaternion.identity);
        Debug.Log("Guardian2");
    }
    public void SpawnGaurdain3(Vector3 pos, Vector3 currentpos){
        pos += currentpos;
        Vector3 spawnPos = pos;
        GameObject newObject = Instantiate(Guardian3, spawnPos, Quaternion.identity);
        Debug.Log("Guardian3");
    }
}

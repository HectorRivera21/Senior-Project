using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

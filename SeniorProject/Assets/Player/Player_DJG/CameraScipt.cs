using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScipt : MonoBehaviour
{
    float curr_player_posx = -6;
    float curr_player_posy = 5;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_view_(){
        // Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + -10f, Camera.main.transform.position.y, Camera.main.transform.position.z);
    }
}

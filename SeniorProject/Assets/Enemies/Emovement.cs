using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emovement : MonoBehaviour
{
    public float speed;
    private Transform m_target;

    private void OnTriggerEnter2D(Collider2D other) {
        // m_target = GameObject.Find("PlayerTest").GetComponent<Transform>();
        if(other.name == "awareness_player"){
            m_target = GameObject.Find("PlayerTest").GetComponent<Transform>();
            Debug.Log(other.name);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.name == "awareness_player"){
            m_target = null;
            Debug.Log(other.name);
        }

        // Debug.Log(other);

    }
    // Start is called before the first frame update

    void Start()
    {
        m_target = GameObject.Find("PlayerTest").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target != null){
            transform.position = Vector2.MoveTowards(transform.position, m_target.position, speed * Time.deltaTime);
        }
        
    }
}

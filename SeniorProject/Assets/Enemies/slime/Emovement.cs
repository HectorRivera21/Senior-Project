using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emovement : MonoBehaviour
{
    public float speed;
    private Transform m_target;

    private void OnTriggerEnter2D(Collider2D other) {
        // m_target = GameObject.Find("PlayerTest").GetComponent<Transform>();
        if(other.name == "PlayerTest"){
            m_target = GameObject.Find("PlayerTest").GetComponent<Transform>();
            // Debug.Log(other.name);
        }
        
    }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if(other.name == "PlayerTest"){
    //         m_target = null;
    //         Debug.Log(other.name);
    //     }

    //     // Debug.Log(other);

    // }


    // Start is called before the first frame update

    void Start()
    {
        m_target = GameObject.Find("PlayerTest").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target != null){
            // transform.position = Vector2.MoveTowards(transform.position, m_target.position, speed * Time.deltaTime);


            // gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(m_target.position.x * 3 , m_target.position.y * 3);

            // Calculate the direction from enemy to player
            Vector2 direction = (m_target.position - transform.position).normalized;
            // Apply force in that direction
            gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        
    }
}

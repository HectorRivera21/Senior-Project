using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // public float speed;
    private Transform target;
    // private Vector2 move;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = target.transform.position - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;

    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(move* speed * Time.deltaTime);
    }
}

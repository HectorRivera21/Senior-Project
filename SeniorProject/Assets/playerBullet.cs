using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public int bulletDamage;

    public GameObject hitEffect;
    private Vector3 defaultSize = new Vector3(0.25f, 0.25f, 1.0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }


    void Update()
    {
        gameObject.transform.localScale = defaultSize;
        bulletDamage = 1;
    }

    // Update is called once per frame
    void DeathBullet()
    {
        Destroy(gameObject, 5);
    }

}

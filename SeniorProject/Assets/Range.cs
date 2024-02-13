using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    private Rigidbody2D rb;

    public float dist_to_shoot = 5f;
    public float dist_to_stop = 3f;
    public float fireRate = 1f;
    private float timeFire = 0;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(!target){
            GetTarget();
        }
        else{
            //
        }

        if(Vector2.Distance(target.position, transform.position) <= dist_to_stop){
            Shoot();
        }
    }

    private void FixedUpdate() {
        if(Vector2.Distance(target.position, transform.position) >= dist_to_stop){
             transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void GetTarget(){
        if(GameObject.FindGameObjectWithTag("Player")){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Shoot(){
        if(timeFire <= 0f){
            Debug.Log("Shoot");
            Instantiate(bullet, transform.position, transform.rotation);
            timeFire = fireRate;
        }
        else{
            timeFire -= Time.deltaTime;
            
        }
    }
}

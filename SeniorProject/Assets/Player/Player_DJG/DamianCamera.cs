using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamianCamera : MonoBehaviour
{
    public float follow_speed = 5f;
    public float offset = 1f;
    public Transform target;

    void Update() {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position,newPos,follow_speed*Time.deltaTime);    
    }
}
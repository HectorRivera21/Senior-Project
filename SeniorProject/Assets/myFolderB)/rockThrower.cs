using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockThrower : MonoBehaviour {
    public GameObject rockPrefab;
    public float throwForce = 10f;
    public float throwInterval = 3f;
    public float arcHeight = 2f;
    public float alertDistance = 5f; // Distance to start throwing rocks when player is within range

    private bool alerted = false;

    private void Start()
    {
        StartCoroutine(EnemyBehavior());
    }

    private IEnumerator EnemyBehavior()
    {
        while (true)
        {
            if (!alerted)
            {
                yield return null; // Sleep
            }
            else
            {
                ThrowRocks();
                yield return new WaitForSeconds(throwInterval);
            }
        }
    }

    private void ThrowRocks()
    {
        GameObject rock = Instantiate(rockPrefab, transform.position, Quaternion.identity);
        Vector2 throwDirection = CalculateArcDirection(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        rock.GetComponent<Rigidbody2D>().velocity = throwDirection * throwForce;

        alerted = false; // Reset alerted state after throwing rocks
    }

    private Vector2 CalculateArcDirection(Vector3 startPos, Vector3 targetPos)
    {
        Vector2 direction = (targetPos - startPos).normalized;
        float distance = Vector2.Distance(startPos, targetPos);
        float yOffset = startPos.y - targetPos.y;

        float angle = Mathf.Atan((yOffset + Mathf.Sqrt(Mathf.Pow(distance, 2) + Mathf.Pow(arcHeight, 2))) / distance);
        float totalTime = distance / (throwForce * Mathf.Cos(angle));

        float xVelocity = distance / totalTime;
        float yVelocity = Mathf.Sin(angle) * xVelocity;

        return direction * xVelocity + Vector2.up * yVelocity;
    }

    private void Update()
    {
        if (!alerted && GameObject.FindGameObjectWithTag("Player") != null && Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= alertDistance)
        {
            alerted = true;
        }
    }
}
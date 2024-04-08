using System.Collections;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition;

    // To ensure only one transition coroutine is running at a time
    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player") && !isTransitioning)
        {
            Debug.Log("Player entered trigger zone.");
            StartCoroutine(LoadTransition());
        }
    }

    IEnumerator LoadTransition()
    {
        Debug.Log("Starting transition coroutine.");
        isTransitioning = true;

        // Play Animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("End");

        isTransitioning = false;
        Debug.Log("Transition coroutine finished.");
    }

}

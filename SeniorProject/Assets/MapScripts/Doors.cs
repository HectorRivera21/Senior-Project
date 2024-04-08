using UnityEngine;

public class Doors : MonoBehaviour
{
    public float playerMovementOffset = 3f;
    public float cameraMovementOffset = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.CompareTag("Player"))
        {
            Vector3 playerOffset = Vector3.zero;
            Vector3 cameraOffset = Vector3.zero;

            // Check player's movement direction
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (Mathf.Abs(horizontalInput) > 0.1f && Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                playerOffset.x = Mathf.Sign(horizontalInput) * playerMovementOffset;
                cameraOffset.x = Mathf.Sign(horizontalInput) * cameraMovementOffset;
            }
            else if (Mathf.Abs(verticalInput) > 0.1f)
            {
                playerOffset.y = Mathf.Sign(verticalInput) * playerMovementOffset;
                cameraOffset.y = Mathf.Sign(verticalInput) * cameraMovementOffset;
            }

            player.transform.position += playerOffset;
            Camera.main.transform.position += cameraOffset;
        }
    }
}

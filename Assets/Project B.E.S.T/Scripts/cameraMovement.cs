using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform player;     // Reference to the player's transform
    public Vector2 offset;       // Optional offset (e.g., new Vector3(0, 0, -10))
    public float smoothSpeed = 0.125f;  // How smoothly the camera follows

    void LateUpdate()
    {
        if (player == null) return;

        Vector2 desiredPosition = player.position;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

using System.Collections;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public int requiredEngineers = 2; // Engineers needed to open the door
    public KeyCode openKey = KeyCode.E; // Key to open the door
    public Transform door; // Door reference
    public Vector3 doorOpenOffset; // Movement offset for opening door
    public float doorMoveSpeed = 2f; // Speed of door movement

    private int engineerCount = 0; // Engineers within range
    private bool isPlayerNearby = false; // Tracks if player is near
    private bool isDoorOpen = false; // Tracks if the door is open

    // Called when another 2D Collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player detection using CapsuleCollider2D
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
        // Engineer detection using BoxCollider2D
        else if (other.CompareTag("Engineer"))
        {
            engineerCount++;
        }
    }

    // Called when another 2D Collider exits the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        // Player exits detection zone
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
        // Engineer leaves detection zone
        else if (other.CompareTag("Engineer"))
        {
            engineerCount--;
        }
    }

    void Update()
    {
        // Player must be **close**, engineers must be **present**, and "E" must be pressed
        if (isPlayerNearby && engineerCount >= requiredEngineers && Input.GetKeyDown(openKey))
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (!isDoorOpen)
        {
            StartCoroutine(MoveDoor(door.position + doorOpenOffset));
            isDoorOpen = true;
        }
    }

     IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(door.position, targetPosition) > 0.01f)
        {
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorMoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

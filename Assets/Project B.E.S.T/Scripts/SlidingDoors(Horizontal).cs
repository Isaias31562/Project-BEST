using UnityEngine;

public class HorizontalSlidingDoor : MonoBehaviour
{
    public Transform leftHalf;
    public Transform rightHalf;
    public Vector3 leftOpenOffset;
    public Vector3 rightOpenOffset;
    public float speed = 2f;
    public CapsuleCollider2D triggerZone; // Assign in Inspector

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;
    private bool isOpen = false;
    private bool playerInside = false;

    void Start()
    {
        leftClosedPosition = leftHalf.position;
        rightClosedPosition = rightHalf.position;
    }

    void Update()
    {
        // Check if player is inside the trigger zone and presses 'E'
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }

        // Move door halves smoothly
        Vector3 targetLeft = isOpen ? leftClosedPosition + leftOpenOffset : leftClosedPosition;
        Vector3 targetRight = isOpen ? rightClosedPosition + rightOpenOffset : rightClosedPosition;

        leftHalf.position = Vector3.Lerp(leftHalf.position, targetLeft, Time.deltaTime * speed);
        rightHalf.position = Vector3.Lerp(rightHalf.position, targetRight, Time.deltaTime * speed);
    }

    void ToggleDoor()
    {
        isOpen = !isOpen;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}

using UnityEngine;

public class VerticalSlidingDoor : MonoBehaviour
{
    public Transform bottomHalf;
    public Transform topHalf;
    public Vector3 bottomOpenOffset;
    public Vector3 topOpenOffset;
    public float speed = 2f;
    public CapsuleCollider2D triggerZone; // Assign in Inspector

    private Vector3 bottomClosedPosition;
    private Vector3 topClosedPosition;
    private bool isOpen = false;
    private bool playerInside = false;

    void Start()
    {
        bottomClosedPosition = bottomHalf.position;
        topClosedPosition = topHalf.position;
    }

    void Update()
    {
        // Check if player is inside the trigger zone and presses 'E'
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDoor();
        }

        // Move door halves smoothly
        Vector3 targetBottom = isOpen ? bottomClosedPosition + bottomOpenOffset : bottomClosedPosition;
        Vector3 targetTop = isOpen ? topClosedPosition + topOpenOffset : topClosedPosition;

        bottomHalf.position = Vector3.Lerp(bottomHalf.position, targetBottom, Time.deltaTime * speed);
        topHalf.position = Vector3.Lerp(topHalf.position, targetTop, Time.deltaTime * speed);
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

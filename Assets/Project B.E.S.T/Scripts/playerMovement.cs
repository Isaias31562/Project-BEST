using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float Horizontal;
    float Vertical;
    public float runSpeed = 5f;
    float moveLimiter = 0.7f;
    Rigidbody2D Body;
    public Camera Camera;
    Vector2 mousePostion;

    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        if (Horizontal != 0 && Vertical != 0)
        {
            Horizontal *= moveLimiter;
            Vertical *= moveLimiter;
        }
        Body.linearVelocity = new Vector2(Horizontal * runSpeed, Vertical * runSpeed);
        // Mouse - body get the value between them.
        Vector2 lookDir = mousePostion - Body.position;
        //For Looking, shouldn't work with the cody but it is nice to have around.
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        // You can enable the code on the bottom to rotate. 
        Body.rotation = angle;
    }
    private void Move()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        mousePostion = Camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Body.linearVelocity = Vector2.zero;
            Body.angularVelocity = 0f;
        }
    }
}

using UnityEngine;

public class RedCrawlerAI : MonoBehaviour
{
    public Vector2 directionOfPlayer { get; private set; }
    [SerializeField]
    private float playerAwarnessDistance;
    private Rigidbody2D rb;
    private Transform _player;
    [SerializeField]
    private float Speed = 5f;

    public float chargeSpeed = 10f; // Speed of the charge
    public float chargeDuration = 5f; // Duration of the charge
    private bool isCharging = false; // Whether the player is currently charging
    private float chargeTimer = 0f; // Timer to track charge duration
    private Vector3 chargeDirection;
    public Transform target;

    public bool canCharge;


    private Vector2 targetDirection;
    public float _rotationSpeed = 100;



    //Start is called before the first frame update    void Start(){rb = GetComponent<Rigidbody2D>();}
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<playerMovement>().transform;
    }




    //Update is called once per frame

    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        if (enemyToPlayerVector.magnitude >= playerAwarnessDistance) 
        {
            canCharge = false;
        }
        if (canCharge == false)
        {
            UpdateTargetDirection();
            transform.position = Vector2.MoveTowards(transform.position, _player.position, Speed * Time.deltaTime);
            Vector2 playerDir = _player.position - this.transform.position;
            float angle = (Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg);
            float rotationSpeed = 1f;
            rb.rotation = Mathf.Lerp(rb.rotation, angle, rotationSpeed);
        }
        if (enemyToPlayerVector.magnitude <= playerAwarnessDistance)
        {
            canCharge = true;
        }
        if (canCharge == true)
        {
            StartCharge();
        }
        if (isCharging)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeDuration)
            {
                StopCharge();
            }
        }


    }
    void FixedUpdate()
    {
        // Apply movement during the charge
        if (isCharging)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * chargeSpeed,ForceMode2D.Impulse);
        }
    }

    void StartCharge()
    {
        isCharging = true;
        chargeTimer = 0f;
        chargeDirection = transform.forward; // Charge in the direction the player is facing
    }

    void StopCharge()
    {
        isCharging = false;
        rb.linearVelocity = Vector3.zero; // Stop any residual movement
        chargeTimer = 0f;
        return;
    }

    private void UpdateTargetDirection()
    {
        var offset = 90f;
        Vector2 direction = _player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

}

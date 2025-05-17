using Unity.Mathematics;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody rb;
    private EnemyChasePlayer playerAwarnessController;
    private Vector2 targetDirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAwarnessController = GetComponent<EnemyChasePlayer>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        setVelocity();
    }
    private void UpdateTargetDirection()
    {
        if (playerAwarnessController.isAware)
        {
            targetDirection = playerAwarnessController.directionOfPlayer;
        }
        else 
        {
            targetDirection = Vector2.zero;
        }
    }
    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }
        Quaternion targetRotate = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotate, _rotationSpeed * Time.deltaTime);
        rb.rotation = rotate;
    }
    private void setVelocity()
    {
        if (targetDirection == Vector2.zero)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = transform.up * Speed;
        }
    }
}

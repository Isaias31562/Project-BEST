using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


//Need a Rigidbody 2D, "Body Type" set to "dynamic" (this allows it to move)
//Collider of some sort (Capsule Collider 2D)
public class EnemyChasePlayer : MonoBehaviour
{

    public bool isAware { get; private set; } //private set means only this script can effect the value
    public Vector2 directionOfPlayer { get; private set; }
    [SerializeField]
    private float playerAwarnessDistance;
    private Rigidbody2D rb;
    private Transform _player;
    [SerializeField]
    private float Speed=5f;


    private Vector2 targetDirection;
    public float _rotationSpeed = 100;



    //Start is called before the first frame update    void Start(){rb = GetComponent<Rigidbody2D>();}
    [System.Obsolete]
    private void Awake()
    {
        _player = FindObjectOfType<playerMovement>().transform;
    }




    //Update is called once per frame

    void Update()
    {
        UpdateTargetDirection();
        transform.position = Vector2.MoveTowards(transform.position,_player.position, Speed * Time.deltaTime);
        Vector2 playerDir = _player.position - this.transform.position;
        float angle = (Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg);
        float rotationSpeed = 1f;
        rb.rotation = Mathf.Lerp(rb.rotation, angle, rotationSpeed);
    }

    private void UpdateTargetDirection()
    {
        var offset = 90f;
        Vector2 direction = _player.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg +180f;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }


}
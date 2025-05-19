using UnityEngine;

public class EngiScript : MonoBehaviour
{
    public int Hp = 5;
    [SerializeField]
    GameObject BloodPool;
    public Transform Location;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            takeDamage();
        }
    }
    void takeDamage()
    {
        Hp--;
        if (Hp < -0)
        {
            Instantiate(BloodPool,Location.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

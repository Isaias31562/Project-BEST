using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private UnityEngine.Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    public float DestroyTime = 3f;

    public Sprite FlashSprite;
    [Range(0, 5f)]
    public int FramesToFlash = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        StartCoroutine(DoFlash());
        Destroy(gameObject, DestroyTime);

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        UnityEngine.Vector3 direction = mousePos - transform.position;
        UnityEngine.Vector3 rotation = transform.position - mousePos;
        rb.velocity = new UnityEngine.Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = UnityEngine.Quaternion.Euler(0, 0, rot * 90);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DoFlash()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var originalSprite = renderer.sprite;
        renderer.sprite = FlashSprite;

        var framesFlashed = 0;
        while (framesFlashed < FramesToFlash)
        {
            framesFlashed++;
            yield return null;
        }

        //Wait for some frames

        renderer.sprite = originalSprite;

    }
}
using System.Collections;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletTransform;
    public Transform muzzle;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private bool Reloading;
    [SerializeField]
    private int magSize = 30;
    [SerializeField]
    private int currentAmmo=15;
    private float reloadTime = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {


        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }

        }

        if (currentAmmo > 0)
        {
            if (Input.GetMouseButton(0) && canFire)
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
                currentAmmo--;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            return;
        }

    }
    private void Reload()
    {
            currentAmmo = magSize;
    }
}
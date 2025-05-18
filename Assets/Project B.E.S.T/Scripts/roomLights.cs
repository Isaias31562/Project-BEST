using UnityEngine;

public class roomTriggers : MonoBehaviour
{
    //public GameObject player; Left over that I want to keep for troubleshooting -Michael
    public GameObject areaObject;
    public GameObject[] roomLights;
    public GameObject[] enemySpawner;
    //public float areaLength = 0; // distance between characterObject and areaObject   Left over code
    bool isPlayerInside = false;

    //public GameObject Players; left over code

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RunningRoomLight();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInside = true;
            return;
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInside = false;
            Debug.Log("Trigger");
        }
    }
    private void RunningRoomLight()
    {
        if (isPlayerInside == false)
        {
            foreach (GameObject light in roomLights)
            {
                light.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject light in roomLights)
            {
                light.SetActive(true);
            }
            foreach(GameObject spawner in enemySpawner)
            {
                spawner.SetActive(true);
            }
        }
    }
}


using Unity.VisualScripting;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public bool IsEnding;
    bool IsPlayerInRange=false;
    public GameObject[] enemySpawner;
    public GameObject Light;
    public GameObject finishLine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInRange=true && Input.GetKeyDown(KeyCode.E))
        {
            IsEnding = true;
            foreach (GameObject enemy in enemySpawner)
            {
                enemy.SetActive(true);
            }
            Light.SetActive(false);
            finishLine.SetActive(true);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            IsPlayerInRange = true;
        }
        
    }

}

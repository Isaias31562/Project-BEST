using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
	public int health;
	public int maxHealth = 10;
	public Slider slider;
	public GameObject playerBody;
    public Transform bulletTransform;

    //Start is called before the first frame update.
    void Start()
	{
		health = maxHealth;
		slider.maxValue = maxHealth;
		slider.value = health;
	}
	
	//Update is called once per frame.
	void Update()
	{
		
	}
	
	public void TakeDamage(int amount)
	{
		health -= amount;
		slider.value = health;
		
		if(health <= 0)
		{
            Instantiate(playerBody, bulletTransform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
	}
}
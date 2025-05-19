using UnityEngine;
using UnityEngine.UI;

public class DeathMenu2 : MonoBehaviour
{
    public HealthSlider healthSlider;
    public GameObject DeathPanel;
    public Button btnYes;
    public Button btnNo;

    void Start()
    {
        // Ensure the panel starts hidden
        DeathPanel.SetActive(false);
    }

    void Update()
    {
        if (healthSlider.health <= 0)
        {
            ShowGameOverScreen();
        }
    }

    void ShowGameOverScreen()
    {
        DeathPanel.SetActive(true);
        
    }
}
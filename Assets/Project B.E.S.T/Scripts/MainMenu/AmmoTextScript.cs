using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public shooting Checking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateAmmoCount();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoCount();
    }
    private void UpdateAmmoCount()
    {
        Text.text = $"{Checking.currentAmmo} / {Checking.magSize}";
    }
}

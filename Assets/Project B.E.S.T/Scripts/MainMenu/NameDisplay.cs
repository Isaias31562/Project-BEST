using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI NameHolder;
    void Start()
    {
        // Create a dictionary with unique keys and names as values
        Dictionary<int, string> namesDictionary = new Dictionary<int, string>
        {
            { 1, "Carlos" },
            { 2, "Guti" },
            { 3, "Juan" },
            { 4, "Michael" },
            { 5, "Ethen" },
            { 6, "George" },
            { 7, "Silver" },
            { 8, "Isaias" },
            { 9, "Teddy" },
            { 10, "Jarred" },
            { 11, "Silver" },
            { 12, "Daniel" },
            { 13, "Apollo" },
            { 14, "Eddie" },
            { 15, "Alice" },
            { 16, "Edwin" }
        };

        // Generate a random name
        string randomName = GetRandomName(namesDictionary);
        NameHolder.text = randomName;
    }

    string GetRandomName(Dictionary<int, string> dictionary)
    {
        // Get all keys from the dictionary
        List<int> keys = new List<int>(dictionary.Keys);

        // Generate a random index
        int randomIndex = Random.Range(0, keys.Count);

        // Use the random key to get a name
        return dictionary[keys[randomIndex]];
    }

}

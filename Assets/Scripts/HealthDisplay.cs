using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{

    private int health = 100;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health + "%";
        if (Input.GetKeyDown(KeyCode.L))
        {
            health--;
        }
    }
}

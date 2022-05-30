using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float hInput, vInput;
    Rigidbody playerRb;
    [SerializeField] float moveSpeed = 20f;

    // Variables Bateria
    float batteryCharge;
    float batteryRate = 0.5f;

    // Visualització Canvas
    public TextMeshProUGUI batteryText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        batteryCharge = 100.0f;    // Carregat 100%
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag=="pasarObstaculo"){
            //myRB.AddForce(Vector3.up*jumpSpeed);
            GameObject.Find("SceneManager").GetComponent<SceneManager>().pasaObstaculo();
            
        } 

    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal"); //D A eix x
        vInput = Input.GetAxis("Vertical"); //W S eix z
        playerRb.MovePosition(transform.position + (transform.right * hInput + transform.forward * vInput) * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
        {
            playerRb.MovePosition(transform.position + transform.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            playerRb.MovePosition(transform.position + transform.up * (-moveSpeed) * Time.deltaTime);
        }

        // Actualització de la bateria
        float ratioFrame = batteryRate * Time.deltaTime;

        batteryCharge -= ratioFrame;
        batteryText.text = "Battery: " + ((int)batteryCharge) + "%";
        
        //Debug.Log("Charge remaining: " + batteryCharge);

        if (batteryCharge <= 0)
        {
            // Aturar bitxo!
            // Menu reiniciar joc?
        }
    }
}

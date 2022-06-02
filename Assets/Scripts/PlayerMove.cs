using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float hInput, vInput, deltaX, deltaY;
    Rigidbody playerRb;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float rotateSpeed = 1f;

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

        if (Input.GetKey(KeyCode.Q)) //eix y puja
        {
            playerRb.MovePosition(transform.position + transform.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E)) //eix y baixa
        {
            playerRb.MovePosition(transform.position + transform.up * (-moveSpeed) * Time.deltaTime);
        }

        //rota dreta i esquerra sobre eix y
        deltaX = Input.GetAxis("Mouse X");
        Vector3 rotationAngle = Vector3.up * deltaX * rotateSpeed;
        Quaternion rotation = Quaternion.Euler(rotationAngle);
        playerRb.MoveRotation(playerRb.rotation * rotation);

        //per evitar que es segueixi movent quan col·lisiona
        if (haveInertia())
        {
            Invoke("stopPlayer", 2f);
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

    private bool haveInertia ()
    {
        if (Mathf.Abs(vInput) < 0.01f && Mathf.Abs(hInput) < 0.01f && Mathf.Abs(deltaX) < 0.01f && 
            !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E) && 
            Mathf.Abs(playerRb.velocity.x) > 0.01f && Mathf.Abs(playerRb.velocity.y) > 0.01f && Mathf.Abs(playerRb.velocity.z) > 0.01f)
        {
            return true;
        }
        return false;
    }

    private void stopPlayer()
    {
        playerRb.velocity = Vector3.zero;
    }
}

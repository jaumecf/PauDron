using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float hInput, vInput, deltaX;
    Rigidbody playerRb;
    [SerializeField]float moveSpeed = 20f;
    float rotateSpeed = 1f;
    private SoundManager soundManager;

    // Variables Bateria
    float batteryCharge;
    float batteryRate = 0.5f;

    // Visualització Canvas
    public TextMeshProUGUI batteryText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        batteryCharge = 100.0f;    // Carregat 100%
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayFX(SoundManager.FXSounds.ENCES_FX);

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            soundManager.PlayFX(SoundManager.FXSounds.ENDAVANT_FX);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            soundManager.PlayFX(SoundManager.FXSounds.ENRERA_FX);
        } 
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            soundManager.PlayFX(SoundManager.FXSounds.ENCES_FX);
        } 

        if (Input.GetKey(KeyCode.Q)) //eix y puja
        {
            playerRb.MovePosition(transform.position + transform.up * moveSpeed * Time.deltaTime);
            soundManager.asFX.pitch = 2f;
        }
        else if (Input.GetKey(KeyCode.E)) //eix y baixa
        {
            playerRb.MovePosition(transform.position + transform.up * (-moveSpeed) * Time.deltaTime);
            soundManager.asFX.pitch = 1f;
        } else
        {
            soundManager.asFX.pitch = 0.5f;
        }

        //rota dreta i esquerra sobre eix y
        deltaX = Input.GetAxis("Mouse X");
        Vector3 rotationAngle = Vector3.up * deltaX * rotateSpeed;
        Quaternion rotation = Quaternion.Euler(rotationAngle);
        playerRb.MoveRotation(playerRb.rotation * rotation);

        //per evitar que es segueixi movent quan col·lisiona
        if (hasInertia())
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

    private bool hasInertia ()
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

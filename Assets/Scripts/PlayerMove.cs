using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float hInput, vInput;
    Rigidbody playerRb;
    [SerializeField] float moveSpeed = 5f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
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
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusManagerRotate : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject marcador;
    private float rotateSpeed=15f;
    Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation=new Vector3(rotateSpeed,0,0);
        Quaternion angleRot=Quaternion.Euler(rotation*Time.deltaTime);
        rb.MoveRotation(rb.rotation*angleRot);
    }
}

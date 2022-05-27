using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject marcador;
    void Start()
    {
        //marcador = transform.GetChild(0).gameObject;
        //marcador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.M)){
            //marcador.SetActive(true);
        }
    }
}

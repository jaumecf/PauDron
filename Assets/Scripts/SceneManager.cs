using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    private GameObject[] marcador;
    private GameObject marcador2;
    private GameObject marcador3;
    private int obstacleActual=0;
    // Start is called before the first frame update
    void Start()
    {
        marcador=GameObject.FindGameObjectsWithTag("pasarObstaculo");  
        marcador[0].SetActive(true);  
        marcador[1].SetActive(false); 
        marcador[2].SetActive(false);   
    }

     public void pasaObstaculo(){
         marcador[obstacleActual].SetActive(false);
         obstacleActual++;
         marcador[obstacleActual].SetActive(true);
     }
    // Update is called once per frame
    void Update()
    {
        
    }
}

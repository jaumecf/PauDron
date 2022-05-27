using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotaManager : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody myRB;
    private float xThurst=100f;
    private float initialAngle=60f;
    private float jumpSpeed=300f;
    private bool isGrounded;
    private Vector3 dirMov;
    void Start()
    {
        myRB=GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(0,initialAngle,0));
        dirMov=new Vector3(xThurst,0,0);

        
    }
    void OnCollisionEnter(Collision col) {
        
        if(col.gameObject.tag=="Ground"){
            //myRB.AddForce(Vector3.up*jumpSpeed);
            Vector3 point = Quaternion.AngleAxis(initialAngle, Vector3.up) * dirMov;
            myRB.AddForce(point+Vector3.up*jumpSpeed*Random.Range(0.7f,1.5f));
        } 
        if(col.gameObject.tag=="xWall"){
            initialAngle+=180;
            if (initialAngle>360){
                initialAngle-=360;
            }
            Vector3 point = Quaternion.AngleAxis(initialAngle, Vector3.up) * dirMov;
            myRB.AddForce(point);
        } 

    }
    // Update is called once per frame
    void Update()
    {        
        

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed = 10f;
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    float h =0.0f;
    float v=0.0f;
    float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 void Update()
 {
     if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
         transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
     }
     if(Input.GetKey(KeyCode.UpArrow))
     {
         transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
     }

        h += horizontalSpeed * Input.GetAxis("Mouse X");
        v -= verticalSpeed * Input.GetAxis("Mouse Y");

       

        transform.eulerAngles = new Vector3(v, h, 0);

 }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    private float speed;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        Vector3 tilt = Input.acceleration;

        

       if (isFlat)
           tilt = Quaternion.Euler(180, 0, 0) * tilt;

        rigid.AddForce(Input.acceleration);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

    public GameObject Aircraft;
    float A_speed;

    float alfa_speed;
    private Vector3 Amount;
    private Vector3 V_norma;
    public Vector3 eulerAngleVelocity;
    Quaternion deltaRotation;

    // Use this for initialization
    void Start ()
    {
        A_speed = 0f;
        alfa_speed = 3f;
        Amount = new Vector3(1, 0, 0);
        V_norma = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        

        Aircraft.transform.Translate(Vector3.forward * Time.deltaTime * A_speed);


        if (A_speed < 300f && Input.GetKey(KeyCode.LeftShift))
        {
            A_speed += alfa_speed;
        }

        if(A_speed >= 0 && Input.GetKey(KeyCode.Space))
        {
            A_speed -= alfa_speed;
        }

        if(A_speed < 0)
        {
            A_speed = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Aircraft.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * 20 + Amount * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Aircraft.GetComponent<Rigidbody>().AddRelativeTorque(Vector3.left * 20 + Amount * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Aircraft.GetComponent<Rigidbody>().AddRelativeTorque((Vector3.forward) * 10 + Amount * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log((Vector3.back) * 10 + Amount * Time.deltaTime);
            Aircraft.GetComponent<Rigidbody>().AddRelativeTorque((Vector3.back) * 10 + Amount * Time.deltaTime);
        }


        if (!Input.anyKey /*&& Aircraft.transform.rotation.z != 0*/)
        {
            Aircraft.GetComponent<Rigidbody>().angularDrag = 0.8f;
        }
    }




}

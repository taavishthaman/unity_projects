using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotThrust = 100f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation() {
        if(Input.GetKey(KeyCode.A)) {
             // 0 0 1
            ApplyRotation(rotThrust);
        }
        else if(Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; //Freezing rotation so that we can manually rotate
        transform.Rotate(rotationThisFrame * Vector3.forward * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so that the physics engine can take over
    }
}

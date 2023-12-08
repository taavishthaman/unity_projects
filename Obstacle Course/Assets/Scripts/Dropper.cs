using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer renderer;
    [SerializeField] private float timeToWait = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToWait) {
            renderer.enabled = true;
            rb.useGravity = true;
        }
    }
}

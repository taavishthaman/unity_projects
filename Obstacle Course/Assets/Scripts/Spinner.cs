using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float xAngle = 0f;
    [SerializeField] private float yAngle = 1f;
    [SerializeField] private float zAngle = 0f;

    [SerializeField] private float rotSpeed = 100f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle * Time.deltaTime * rotSpeed,yAngle * Time.deltaTime * rotSpeed,zAngle * Time.deltaTime * rotSpeed);
    }
}

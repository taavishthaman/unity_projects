using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame, update is frame dependant 
    //so be careful, use Time.deltaTime. Time.deltaTime will make
    //our logic framerate independant
    void Update()
    {
        MovePlayer();
    }

    //Define functions below start and update
    void PrintInstructions() {
        Debug.Log("Welcome to the Game!");
        Debug.Log("Move player with W,A,S and D or arrow keys!");
        Debug.Log("Do not hit the walls!");
    }

    void MovePlayer() {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        //Get Component of type Mesh Renderer
        if(other.gameObject.tag == "Player") {
            GetComponent<MeshRenderer>().material.color = Color.grey;
            gameObject.tag = "Hit";
        }
        
    }
}

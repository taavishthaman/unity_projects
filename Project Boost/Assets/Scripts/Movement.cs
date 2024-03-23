using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if(Input.GetKey(KeyCode.Space)) {
            StartThrusting();
        } else {
            StopThrusting();
        }
    }

    void StartThrusting() {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if(!audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngine);
        }
        if(!mainThrusterParticles.isPlaying) {
            mainThrusterParticles.Play();
        }
    }

    void StopThrusting() {
        audioSource.Stop();
        mainThrusterParticles.Stop();
    }

    void ProcessRotation() {
        if(Input.GetKey(KeyCode.A)) {
             // 0 0 1
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D)) {
            RotateRight();
        } else {
            StopRotating();
        }
    }

    void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; //Freezing rotation so that we can manually rotate
        transform.Rotate(rotationThisFrame * Vector3.forward * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so that the physics engine can take over
    }

    void RotateLeft() {
        ApplyRotation(rotThrust);
        if(!rightThrusterParticles.isPlaying) {
            rightThrusterParticles.Play();
        }
    }

    void RotateRight() {
        ApplyRotation(-rotThrust);
        if(!leftThrusterParticles.isPlaying) {
            leftThrusterParticles.Play();
        }
    }

    void StopRotating() {
        rightThrusterParticles.Stop();
        leftThrusterParticles.Stop();
    }
}

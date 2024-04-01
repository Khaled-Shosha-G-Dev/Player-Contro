using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class PlayerControler : MonoBehaviour
{
                                            // Force (forward & backward) & (right & left)
    private float horizontalInput ;
    private float verticalInput ;
    private Rigidbody rb;
    [SerializeField] private float hoursePower ;
    [SerializeField] private float turnSpeed ;

                                            //Center of Mass to Car 
    [SerializeField] private GameObject centerOfMass;

                                            // speed
    [HideInInspector] public float speed;

                                            //Sounds
    [SerializeField] private AudioClip startTheCar;
    [SerializeField] private AudioClip carMovesUp;
    [SerializeField] private AudioClip carMoving;
    [SerializeField] private AudioClip carSteady;
    [SerializeField] private AudioClip carMovesDown;
    [SerializeField] private AudioClip carCollision;
    [SerializeField] private AudioSource carSounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
        carSounds=GetComponent<AudioSource>();
        carSounds.PlayOneShot(startTheCar,1f);
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        MovingCar();
        CarSpeed();
    }
    void MovingCar()
    {
        //user input 

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //move the vehicle forward

        //transform.Translate(Vector3.forward*Time.deltaTime*Speed*verticalInput);//== transform.Translate(0,0,1);
        rb.AddRelativeForce(Vector3.forward *  hoursePower * verticalInput);

        //turn the vihcle right
        if(speed>.5)
            transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
    }
    void CarSpeed()
    {
       speed = rb.velocity.magnitude * 3.6f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacl"))
            carSounds.PlayOneShot(carCollision,1f);

    }

}

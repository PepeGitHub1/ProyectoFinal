using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerForce : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Vector3 playerDirection;

    [SerializeField][Range(1f, 2000f)]private float movementForce = 10f;

    public Rigidbody MyRigidbody { get => myRigidbody; set => myRigidbody = value; }
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }

    [SerializeField][Range(1f, 200f)]private float maxSpeed = 5f;


    private void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) playerDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector3.right;
    }

    private void FixedUpdate()
    {
        if(playerDirection != Vector3.zero && MyRigidbody.velocity.magnitude < MaxSpeed)
        {
            MyRigidbody.AddForce(transform.TransformDirection(playerDirection) * movementForce,ForceMode.Force);
        }
    }
}

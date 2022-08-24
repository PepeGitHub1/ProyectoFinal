using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerForce : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public Rigidbody MyRigidbody { get => myRigidbody; set => myRigidbody = value; }

    //-------------------------------------------VARIABLES MOVIMIENTO---------------------------------------
    private Vector3 playerDirection;
    [SerializeField][Range(1f, 2000f)] private float movementForce = 10f;
    public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    [SerializeField][Range(1f, 200f)] private float maxSpeed = 5f;

    //-------------------------------------------VARIABLES SALTO---------------------------------------

    [SerializeField][Range(1f, 2000f)] private float jumpForce = 50f;
    private bool inDelayJump = false;
    private float delayNextJump = 1f;
    private bool canJump = true;
    public bool CanJump { get => canJump; set => canJump = value; }

    //-------------------------------------------VARIABLES ROTACIÓN---------------------------------------
    private float cameraAxisX;


    private void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        Rotation();

        playerDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) playerDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) playerDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) playerDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) playerDirection += Vector3.right;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        if (playerDirection != Vector3.zero && MyRigidbody.velocity.magnitude < MaxSpeed)
        {
            MyRigidbody.AddForce(transform.TransformDirection(playerDirection) * movementForce, ForceMode.Force);
        }

        if (!canJump && !inDelayJump)
        {
            MyRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            inDelayJump = true;
            Invoke("DelayNextJump", delayNextJump);
        }
    }


        private void DelayNextJump()
    {
        inDelayJump = false;
        canJump = true;
    }

        public void Rotation()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }
}

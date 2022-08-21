using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerForce : MonoBehaviour
{
    [SerializeField][Range(5f, 2000f)] private float speed = 5f;
    [SerializeField][Range(5f, 2000f)] private float forceJump = 10f;

    // [SerializeField]
    // [Range(5f, 2000f)] private float maxSpeed = 5f;
    private Vector3 direction;

    private Rigidbody playerRB;

    private float distanceToGround;





    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

    }


    void Update()
    {
        Jump();


    }

    private void FixedUpdate()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));


        playerRB.AddForce(direction * speed, ForceMode.Impulse);

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("Estoy saltando");
            playerRB.AddForce(Vector3.up * forceJump, ForceMode.Impulse);


        }
    }
    private bool IsGrounded()
    {
        return Physics.BoxCast(transform.position, new Vector3(0.4f,0f,0.4f), Vector3.down,Quaternion.identity,distanceToGround + 0.5f);
    }
}

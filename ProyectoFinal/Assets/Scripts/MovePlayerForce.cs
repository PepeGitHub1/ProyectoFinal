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

    [SerializeField][Range(1f, 10f)] private float rayDistance = 5f;
    public Transform endPoint;
    public bool ground = true;


    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Jump();
        IsGrounded();

    }

    private void FixedUpdate()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));


        playerRB.AddForce(direction * speed, ForceMode.Impulse);

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && ground)
        {
            Debug.Log("Estoy saltando");
            playerRB.AddForce(Vector3.up * forceJump, ForceMode.Impulse);


        }
    }

    private void IsGrounded()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, endPoint.position, out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                Debug.Log("Tocando piso");
                ground = true;
            }
            else
            {
                ground = false;
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, endPoint.position);
    }

}

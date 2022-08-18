using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCC : MonoBehaviour
{
    public float speed = 5;
    private CharacterController playerCC;


    private float gravity = -9.81f;
    private Vector3 velocity;

    public float jumpForce =10f;
    // Start is called before the first frame update
    void Start()
    {
        playerCC = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {

        //--------------movimiento----------------
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerCC.Move(direction*speed*Time.deltaTime);

        if(direction != Vector3.zero)
        {
            transform.forward = direction;
        }

        //------------------gravedad--------------
        velocity.y += gravity * Time.deltaTime;
        playerCC.Move(velocity * Time.deltaTime);

        if(playerCC.isGrounded)
        {
            velocity.y = 0f;
        }

        //-----------------salto-----------------

        if(Input.GetButtonDown("Jump") && playerCC.isGrounded)
        {
            velocity.y += jumpForce;
        }
    }
}

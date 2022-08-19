using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCC : MonoBehaviour
{
    public float speed = 5;
    private CharacterController playerCC;


    private float gravity = -9.81f;
    private Vector3 velocity;

    private Transform groundCheck;
    public float groundDistance = 0.2f;
    public bool isGrounded = true;
    private LayerMask Ground;

    public float JumpHeight = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerCC = GetComponent<CharacterController>();
        groundCheck = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        //------------------gravedad--------------
        velocity.y += gravity * Time.deltaTime;
        playerCC.Move(velocity * Time.deltaTime);

        //------------------Crear metodo is grounded y reiniciar variable velocity----------

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, Ground, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }


        //--------------movimiento----------------
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerCC.Move(direction*speed*Time.deltaTime);

        if(direction != Vector3.zero)
        {
            transform.forward = direction;
        }





        //-----------------salto-----------------

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
    }
}

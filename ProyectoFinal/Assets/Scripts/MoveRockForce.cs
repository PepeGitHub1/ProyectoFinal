using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRockForce : MonoBehaviour
{
    private Rigidbody rockRb;
    [SerializeField][Range(20f,2000f)]private float forceMove = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rockRb = GetComponent<Rigidbody>();
        Invoke(methodName: "DestroyGameObject",5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rockRb.AddForce(Vector3.back*forceMove,ForceMode.Force);
    }

    private void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    

}

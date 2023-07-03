using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1, jumpForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 direction = transform.position;
        direction.z += Vertical/10;
        direction.x += Horizontal/10;
        direction = transform.TransformDirection(direction) * speed;
        rb.MovePosition(direction);
    }
}

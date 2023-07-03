using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;
    public float speed = 1, jumpForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }
}

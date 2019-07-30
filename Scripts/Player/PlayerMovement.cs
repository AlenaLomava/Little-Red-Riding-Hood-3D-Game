using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float turnSmoothing = 15f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float speedDampTime = 0.1f;

    private Animator anim;
    private Rigidbody playerRigidbody;
    private Vector3 movement;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        MovementManagement(h, v);
        Animating(h, v);
    }

    void MovementManagement(float h, float v)
    { 
        movement.Set(h, 0f, v);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement, Vector3.up), 0.15f);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
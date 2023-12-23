using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    private CharacterController charController;
    private bool isJumping = false;
    private bool isFlying = false;

    public float Speed = 6.0f;
    public float JumpStrength = 10.0f;
    public float Gravity = -9.8f;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float DeltaX = Input.GetAxis("Horizontal") * Speed;
        float DeltaZ = Input.GetAxis("Vertical") * Speed;
        Vector3 Movement = new Vector3(DeltaX, 0, DeltaZ);
        Movement = Vector3.ClampMagnitude(Movement, Speed);

        Movement.y = Gravity;
        
        Movement *= Time.deltaTime;
        Movement = transform.TransformDirection(Movement);
        charController.Move(Movement);
    }
}

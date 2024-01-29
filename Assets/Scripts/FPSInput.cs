using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    private CharacterController charController;

    public const float baseSpeed = 6f;
    private float speed = 6f;
    public float gravity = -9.8f;

    void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDisable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float DeltaX = Input.GetAxis("Horizontal") * speed;
        float DeltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 Movement = new Vector3(DeltaX, 0, DeltaZ);
        Movement = Vector3.ClampMagnitude(Movement, speed);

        Movement.y = gravity;
        
        Movement *= Time.deltaTime;
        Movement = transform.TransformDirection(Movement);
        charController.Move(Movement);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}

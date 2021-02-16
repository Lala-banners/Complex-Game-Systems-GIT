using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float gravity = -9.81f;
    float turnSmoothVelocity;
    [SerializeField] private Vector3 playerVelocity;
    private Vector3 moveDir;
    private float speed = 5f;
    public KeyInputs keyInputs;

    [System.Serializable]
    public struct KeyInputs
    {
        public float horizontal; //horizontal movement value
        public float vertical; //vertical movement value
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Direction();

        float oldGravity = moveDir.y;
        moveDir = Quaternion.Euler(0f, cam.eulerAngles.y, 0f) * moveDir;

        float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnSmoothVelocity, turnSmoothTime);
        transform.eulerAngles = new Vector3(0f, smoothAngle, 0f);

        moveDir.x *= speed;
        moveDir.y = oldGravity;
        moveDir.z *= speed;

        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }

    private void Move()
    {
        Vector3 direction = new Vector3(keyInputs.horizontal, 0f, keyInputs.vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg
                                                                        + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                                            ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            float movementSpeed = speed;

            controller.Move(moveDir * movementSpeed * Time.deltaTime);
        }
    }

    private void Direction()
    {
        float horizontal = 0; //reset movement values
        float vertical = 0;

        //take key input and check if it matches any of these movement types in the dictionary
        //if a match is found, increase that direction
        if (Input.GetKey(Keybinds.keys["Forward"]))
        {
            vertical++;
        }
        if (Input.GetKey(Keybinds.keys["Backwards"]))
        {
            vertical--;
        }
        if (Input.GetKey(Keybinds.keys["Right"]))
        {
            horizontal++;
        }
        if (Input.GetKey(Keybinds.keys["Left"]))
        {
            horizontal--;
        }

        moveDir = new Vector3(horizontal, 0f, vertical).normalized;
    }
}

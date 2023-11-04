using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    Rigidbody playerRB;

    [SerializeField] float SpeedMultiplier = 1f;
    [SerializeField] float speedMultiplierAngle = 0.5f;
    [SerializeField] float speedRollMultiplierAngle = 0.05f;

    float verticalMove;
    float horizontalMove;
    float mouseInputX;
    float mouseInputY;
    float rollInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Get Keyboard Inputs
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");
    }

    private void FixedUpdate()
    {
        //Forwards + Backwards Movement
        playerRB.AddForce(playerRB.transform.TransformDirection(Vector3.right) * SpeedMultiplier * horizontalMove, ForceMode.VelocityChange);
        //Left + Right Movement
        playerRB.AddForce(playerRB.transform.TransformDirection(Vector3.forward) * SpeedMultiplier * verticalMove, ForceMode.VelocityChange);
        // Rotation
        playerRB.AddTorque(playerRB.transform.right * speedMultiplierAngle * mouseInputY * -1, ForceMode.VelocityChange);
        playerRB.AddTorque(playerRB.transform.up * speedMultiplierAngle * mouseInputX, ForceMode.VelocityChange);
        playerRB.AddTorque(playerRB.transform.forward * speedRollMultiplierAngle * rollInput, ForceMode.VelocityChange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;
    CharacterController playerController;
    Animator playerAnim;
    Camera playerCamera;
    bool movementInputAllowed = true;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
    
        if(!movementInputAllowed)
            return;

        playerController.SimpleMove(Quaternion.LookRotation(playerCamera.transform.forward) * MovementInput() * speed * Time.deltaTime);
    }

    Vector3 MovementInput()
    {
        Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        playerAnim.SetFloat("MovementSpeed", movementVector.magnitude);
        playerAnim.SetFloat("HorizontalMovement", movementVector.x);
        playerAnim.SetFloat("VerticalMovement", movementVector.z);

        return movementVector;
    }
}

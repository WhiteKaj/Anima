using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;
    CharacterController playerController;
    Camera playerCamera;
    bool movementInputAllowed = true;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
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
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 dirVec;
    private Quaternion lookRotation;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private IInteractable interactable;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        dirVec = new Vector3(moveVec.x, 0f, moveVec.y);
        playerRb.velocity = dirVec * moveSpeed;
        playerAnim.SetBool("IsRunning", true);

        if(dirVec !=  Vector3.zero)
        {
            lookRotation = Quaternion.LookRotation(dirVec, Vector3.up);
        }

        if(context.canceled)
        {
            playerAnim.SetBool("IsRunning", false);
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (interactable != null && context.performed)
        {
            interactable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            interactable = other.gameObject.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(interactable == null)
        {
            if (other.gameObject.layer == 7)
            {
                interactable = other.gameObject.GetComponent<IInteractable>();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            interactable = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody playerRb;
    private IInteractable interactable;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        Vector3 dirVec = new Vector3(moveVec.x, 0f, moveVec.y);
        playerRb.velocity = dirVec * moveSpeed;
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

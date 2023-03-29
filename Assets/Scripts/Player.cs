using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask layerMask;
    private bool isWalking;
    private Vector3 lastInteractDir;
    public bool IsWalking { get => isWalking; }

    void Update()
    {
        HandleMovements();
        HandleInteractions();
    }
    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        float intractionDistance = 2f;

        if (moveDir != Vector3.zero)
            lastInteractDir = moveDir;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, intractionDistance, layerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }

    private void HandleMovements()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = Time.deltaTime * moveSpeed;
        float playerHeight = 2f;
        float playerRadius = .7f;
        bool canMove = !Physics.CapsuleCast(transform.position,
                        transform.position + Vector3.up * playerHeight,
                        playerRadius,
                        moveDir, moveDistance);
        if (!canMove)
        {
            // move Dir x
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position,
                        transform.position + Vector3.up * playerHeight,
                        playerRadius,
                        moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                // move z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position,
                            transform.position + Vector3.up * playerHeight,
                            playerRadius,
                            moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    // cannot move
                }
            }
        }

        if (canMove)
            transform.position += moveDir * moveDistance;

        isWalking = moveDir != Vector3.zero;
        float rotationSpeed = 10f;
        if (moveDir != Vector3.zero)
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player1.Enable();
    }
    public Vector2 GetMovementVector()
    {
        // Gives the Vector2 in normalize form
        Vector2 inputVector = playerInputAction.Player1.Move.ReadValue<Vector2>();
        return inputVector;
    }
}

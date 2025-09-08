using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    private CharacterController _Controller;
    public float PlayerSpeed = 2f;
    public InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
        gameObject.TryGetComponent(out _Controller);
    }

    public override void FixedUpdateNetwork()
    {
        InputSystem.Update();
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        _Controller.Move(move * Runner.DeltaTime * PlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }
}

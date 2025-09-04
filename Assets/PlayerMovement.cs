using Fusion;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private CharacterController characterController;
    public float PlayerSpeed = 2f;

    private void Start()
    {
        gameObject.TryGetComponent(out characterController);
    }

    public override void FixedUpdateNetwork()
    {
        Vector3 move = new Vector3(0,0,0) * Runner.DeltaTime * PlayerSpeed;
        characterController.Move(move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }
}

using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        //bool foo = inputActions.Player.Action.ReadValue<float>() > 0;
        bool foo = inputActions.Player.Action.triggered;
        Debug.Log("WTF " + foo);
        if (Object.HasInputAuthority && foo == true)
        { 
            Debug.Log("Nya UwU");
            RPC_CallTrafficLight();
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_CallTrafficLight()
    {
        ObjectManager.singleton.trafficLight.ChangeColor();
    }
}

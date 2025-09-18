using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class HelloRPC : NetworkBehaviour
{
    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_SayOwO(string msg, RpcInfo info = default)
    {
        Debug.Log(info.Source + " Says: " + msg);
    }

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            RPC_SayOwO("OWO");
        }    
    }
}

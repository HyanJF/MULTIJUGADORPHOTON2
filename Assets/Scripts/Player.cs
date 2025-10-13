using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private InputActions inputActions;
    private bool eggPain = false;
    private bool fire = false;

    private void Start()
    {
        inputActions = new InputActions();
        inputActions.Player.Enable();
    }

    public void Update()
    {
        if (!eggPain)
        {
            eggPain = inputActions.Player.Action.triggered;
        }

        if (!fire)
        {
            fire = inputActions.Player.Shoot.triggered;
        }
    }

    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        if (Object.HasInputAuthority && eggPain == true)
        {
            eggPain = false;
            Debug.Log("Nya UwU");
            RPC_CallTrafficLight();
        }

        if (Object.HasInputAuthority && fire == true)
        {
            fire = false;
            Debug.Log("Plomeado");
            Rpc_ShoootAShot();
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_CallTrafficLight()
    {
        ObjectManager.singleton.trafficLight.ChangeColor();
    }

    #region Pewpew
    public GameObject bulletPrefab;
    public Transform shootPos;

    public GameObject particles;

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    private void Rpc_ShoootAShot()
    {
        var bullet = Runner.Spawn(bulletPrefab, shootPos.position, shootPos.rotation, Object.InputAuthority);
        
        if (bullet.TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(bullet.transform.forward * 3, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("HEY PA EL RIGIDBODY");
        }
        Rpc_PlayShootEffect();
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void Rpc_PlayShootEffect()
    {
        Instantiate(particles, shootPos.position, shootPos.rotation);
    }
    #endregion
}

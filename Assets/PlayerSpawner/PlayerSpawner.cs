using UnityEngine;
using Fusion;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject playerPrefab;
    public void PlayerJoined(PlayerRef player)
    {
        //Runner tiene el componente similar al local player
        if (player == Runner.LocalPlayer)
        {
            Runner.Spawn(playerPrefab, new Vector3(0,1,0), Quaternion.identity, player);
        }
    }

}

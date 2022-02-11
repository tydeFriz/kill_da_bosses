using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace GameNetwork
{
    public class Player : NetworkBehaviour
    {
        public NetworkVariable<int> LastUsedId = new NetworkVariable<int>(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.Everyone,
            ReadPermission = NetworkVariablePermission.Everyone
        });
        public NetworkVariable<int> Id = new NetworkVariable<int>(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });

        public NetworkVariableVector2 Position = new NetworkVariableVector2(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });

        public NetworkVariable<float> MovementSpeed = new NetworkVariable<float>(new NetworkVariableSettings
        {
            WritePermission = NetworkVariablePermission.ServerOnly,
            ReadPermission = NetworkVariablePermission.Everyone
        });

        private BoxCollider2D boxCollider;

        public override void NetworkStart()
        {
            InitPlayer();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        public void InitPlayer()
        {
            LastUsedId.Value = LastUsedId.Value + 1;
            if (NetworkManager.Singleton.IsServer)
            {
                Id.Value = LastUsedId.Value;
                MovementSpeed.Value = 3.0f;
            }
            else
            {
                SubmitInitRequestServerRpc();
            }
            
        }

        public void Move()
        {
            //todo
        }

        [ServerRpc]
        void SubmitInitRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Id.Value = LastUsedId.Value;
            MovementSpeed.Value = 3.0f;
        }
    
    }

}

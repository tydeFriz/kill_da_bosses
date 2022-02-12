using Unity.Netcode;
using UnityEngine;

namespace Friz
{
    public class Player : NetworkBehaviour
    {
         [SerializeField]
        private float movementSpeed = 4.0f;

        [SerializeField]
        private NetworkVariable<Vector2> movementDirection = new NetworkVariable<Vector2>();

        private Vector2 oldMovementDirection;

        private void Update()
        {
            if( IsServer )
            {
                UpdateServer();
            }
            if( IsClient && IsOwner )
            {
                updateClient();
            }
        }

        private void UpdateServer()
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y)
                                + Vector2.ClampMagnitude(movementDirection.Value, 1.0f) * Time.deltaTime * movementSpeed;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            transform.localScale = new Vector3(
                movementDirection.Value.x > 0 ? 1 : -1,
                transform.localScale.y,
                transform.localScale.z
            );
        }

        private void updateClient()
        {
            Vector2 newMovementDirection = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );

            if( oldMovementDirection == newMovementDirection ){
                return;
            }
            oldMovementDirection = newMovementDirection;

            UpdateClientDirectionServerRpc(newMovementDirection);
        }

        [ServerRpc]
        public void UpdateClientDirectionServerRpc(Vector2 newMovementDirection)
        {
            movementDirection.Value = newMovementDirection;
        }

    }

}

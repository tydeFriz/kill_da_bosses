using UnityEngine;

namespace Friz
{

    public class CameraController : MonoBehaviour
    {
        private GameObject player;

        private Vector3 offset = new Vector3(0, 0, -10);

        public void AttachToPlayer(GameObject Player)
        {
            player = Player;
        }

        void Update()
        {
            if( player is null )
                return;
            transform.position = player.transform.position + offset;
        }
    }

}


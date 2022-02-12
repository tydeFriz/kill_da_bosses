using Unity.Netcode;
using UnityEngine;

namespace Friz
{
    
    public class ConnectionUIManager : MonoBehaviour
    {
        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            if (NetworkManager.Singleton.IsClient)
            {
                StatusLabels();
            }
            else
            {
                StartButtons();
            }

            GUILayout.EndArea();
        }

        static void StartButtons()
        {
            if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        }

        static void StatusLabels()
        {
            var mode = NetworkManager.Singleton.IsHost ? "Host" : "Client";

            GUILayout.Label("Transport: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Mode: " + mode);
        }

    }

}

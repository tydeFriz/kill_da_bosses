using System;
using MLAPI;
using UnityEngine;

namespace GameNetwork
{
    public class NetworkPlayerMovement : NetworkBehaviour
    {

        private Vector2 moveDelta;

        void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            moveDelta = Vector2.ClampMagnitude(new Vector2(x, 0) + new Vector2(0, y), 1);
            //float moveSpeed = Player.MovementSpeed.Value;
            float moveSpeed = 2.5f;

            if( moveDelta.x > 0 ){
                transform.localScale = new Vector2(0.5f, 0.75f);
            }
            else if( moveDelta.x < 0 ){
                transform.localScale = new Vector2(-0.5f, 0.75f);
            }
            
            transform.Translate(moveDelta * Time.deltaTime * moveSpeed);
        }
    }
}
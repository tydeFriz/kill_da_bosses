using Unity.Netcode;
using UnityEngine;

namespace Friz.Buttons
{
    public class PlayerSpriteButton : Button
    {
        public Sprite sprite;

        protected override void onPress(Collider2D collider)
        {
            if( state.Value ){
                //return;
            }
            if( IsServer ){
                state.Value = true;
            }
            
            SpriteRenderer playerRenderer = collider.gameObject.GetComponent<SpriteRenderer>();
            playerRenderer.sprite = sprite;
        }

        protected override void onExit(Collider2D collider){
            if( IsServer ){
                state.Value = false; 
            }
        }

        public override void release()
        {
            if( !state.Value ){
                return;
            }

            if( IsServer ){
                state.Value = false;              
            }
        }

    }

}

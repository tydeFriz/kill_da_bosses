using Unity.Netcode;
using UnityEngine;

namespace Friz
{

    public class Button : NetworkBehaviour
    {
        [SerializeField]
        protected NetworkVariable<bool> state = new NetworkVariable<bool>();

        public Sprite ButtonUp;
        public Sprite ButtonDown;

        void Start()
        {
            if( IsServer ){
                state.Value = false;
            }
        }

        void FixedUpdate()
        {
            updateVisualState();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            onPress(collider);
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            onExit(collider);
        }

        protected virtual void onPress(Collider2D collider){}

        protected virtual void onExit(Collider2D collider){}

        public virtual void release(){}

        private void updateVisualState() {
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.sprite = state.Value ? ButtonDown : ButtonUp;
        }

    }

}

using UnityEngine;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit
{
    class InteractingTrigger : MonoBehaviour
    {
        [SerializeField] private BasePlayerCharacter _player;
        [SerializeField] private CircleCollider2D _triggerCollider;

        private const string ITEM_LAYER_NAME = "Item";

        private LayerMask _interactableLayer;

        // Use this for initialization
        void Start()
        {
            if (!_player)
            {
                _player = GetComponentInParent<BasePlayerCharacter>();
            }
            if (!_triggerCollider)
            {
                _triggerCollider = GetComponent<CircleCollider2D>();
            }

            _interactableLayer = LayerMask.NameToLayer(ITEM_LAYER_NAME);
            _triggerCollider.radius = _player.Parameters.InteractDistance;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _interactableLayer)
            {
                var item = collision.GetComponent<BaseItem>();
                if (item)
                {
                    _player.Interact.InteractWithObjects();
                }
            }
        }
    }
}
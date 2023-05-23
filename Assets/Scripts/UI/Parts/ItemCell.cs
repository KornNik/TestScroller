using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;
using UnityEngine.EventSystems;

namespace SideScroller.UI.Parts
{
    class ItemCell : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        [SerializeField] protected Text _itemName;
        [SerializeField] protected Image _itemImage;
        [SerializeField] protected Sprite _emptySpriteIcon;

        [SerializeField] protected BaseItem _item;

        protected CharacterEquipmentUI _equipmentUI;
        protected CharacterInventoryUI _inventoryUI;

        protected bool _isEmpty = true;

        #endregion


        #region Properties

        public bool IsEmpty => _isEmpty;
        public BaseItem Item => _item;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _equipmentUI = FindObjectOfType<CharacterEquipmentUI>();
            _inventoryUI = FindObjectOfType<CharacterInventoryUI>();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        { 
        }

        #endregion


        #region Methods

        public void FillCellInfo(BaseItem item)
        {
            SetItem(item);
            SetName(item.name);
            SetImage(item.ItemSpriteRenderer.sprite);
            _isEmpty = false;
        }

        private void SetItem(BaseItem item)
        {
            _item = item;
        }
        private void SetImage(Sprite itemImage)
        {
            _itemImage.sprite = itemImage;
        }
        private void SetName(string name)
        {
            _itemName.text = name;
        }

        public void EmptyCell()
        {
            _item = null;
            _itemImage.sprite = _emptySpriteIcon;
            _itemName.text = " ";
            _isEmpty = true;
        }

        #endregion


        #region IPointerClickHandler

        public virtual void OnPointerClick(PointerEventData pointerEventData)
        {
            if(_item is BaseItem)
            {
                _inventoryUI.InventoryItemClick?.Invoke(_item);
            }
        }

        #endregion
    }
}

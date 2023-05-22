using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;
using UnityEngine.EventSystems;

namespace SideScroller.UI.Parts
{
    class ItemCell : MonoBehaviour, IPointerClickHandler, IListenerScreen
    {
        #region Fields

        [SerializeField] protected Text _itemName;
        [SerializeField] protected Image _itemImage;
        [SerializeField] protected Sprite _emptySpriteIcon;

        [SerializeField] protected BaseItem _item;

        protected CharacterMenu _characterMenu;
        protected bool _isEmpty = true;

        #endregion


        #region Properties

        public bool IsEmpty => _isEmpty;
        public BaseItem Item => _item;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            ScreenInterface.GetInstance().AddObserver(Types.ScreenTypes.InventoryMenu, this);
        }

        private void OnDisable()
        {
            ScreenInterface.GetInstance().RemoveObserver(Types.ScreenTypes.InventoryMenu, this);
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
                _characterMenu.InventoryUI.InventoryItemClick?.Invoke(_item);
            }
        }

        #endregion

        #region IListnerScreen

        public void ShowScreen()
        {
            if (_characterMenu == null)
            {
                _characterMenu = ScreenInterface.GetInstance().CurrentWindow as CharacterMenu;
            }
        }

        public void HideScreen()
        {
            
        }

        #endregion
    }
}

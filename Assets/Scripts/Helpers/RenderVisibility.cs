using UnityEngine;

namespace SideScroller.Helpers
{
    static class RenderVisibility
    {
        #region Methods

        public static void SpriteRenderVisibilityChange(Transform transformObject, SpriteRenderer spriteRenderer, bool status)
        {
            var tempSprite = spriteRenderer;
            if (tempSprite)
            {
                tempSprite.enabled = status;
                if (transformObject.childCount <= 0) return;
                foreach (Transform item in transformObject)
                {
                    tempSprite = item.GetComponentInChildren<SpriteRenderer>();
                    if (tempSprite)
                    {
                        tempSprite.enabled = status;
                    }
                }
            }
        }
        public static void SpriteRenderVisibilityChange(Transform unitModel, bool status)
        {
            var tempSpriteRenderer = unitModel.GetComponent<SpriteRenderer>();
            if (tempSpriteRenderer)
            {
                tempSpriteRenderer.enabled = status;
            }
            if (unitModel.childCount <= 0) return;
            foreach (Transform item in unitModel)
            {
                tempSpriteRenderer = item.GetComponentInChildren<SpriteRenderer>();
                if (tempSpriteRenderer)
                {
                    tempSpriteRenderer.enabled = status;
                }
            }
        }

        #endregion
    }
}

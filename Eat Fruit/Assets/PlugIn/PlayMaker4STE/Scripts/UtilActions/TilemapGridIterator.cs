#if PLAYMAKER && SUPER_TILEMAP_EDITOR
using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using HutongGames.PlayMaker.Actions;

namespace CreativeSpore.SuperTilemapEditor.PlayMakerActions
{
    [ActionCategory("STE: Utility")]
    [Tooltip("Iterate through the cells in a tilemap, storing the current cell position in a variable.")]
    //[HelpUrl("")]
    public class TilemapGridIterator : TilemapActionBase
    {
        [Tooltip("Set to true to only iterate through all the visible tiles")]
        public FsmBool onlyVisibleTiles;

        [HutongGames.PlayMaker.ActionSection("Output")]

        [UIHint(UIHint.Variable)]
        [Tooltip("The current cell position.")]
        public FsmVector2 storePosition;

        [UIHint(UIHint.Variable)]
        [Tooltip("Current Grid X position")]
        public FsmInt gridX;

        [UIHint(UIHint.Variable)]
        [Tooltip("Current Grid Y position")]
        public FsmInt gridY;

        [HutongGames.PlayMaker.ActionSection("Events")]
        [Tooltip("Event to send each iteration.")]
        public FsmEvent iterationNextElement;

        [HutongGames.PlayMaker.ActionSection("Tilemap Position")]
        [ObjectType(typeof(ePositionType))]
        [Tooltip(CommonTooltips.k_PositionType)]
        public FsmEnum positionType;

        private STETilemap m_tilemap;

        public override void Reset()
        {
            base.Reset();
            onlyVisibleTiles = null;
            positionType = null;
            storePosition = null;
            gridX = null;
            gridY = null;
        }

        public override void OnEnter()
        {
            int minGridX, maxGridX, minGridY, maxGridY;

            if (!m_tilemap)
            {
                var go = Fsm.GetOwnerDefaultTarget(gameObject);
                if (UpdateCache(go))
                {
                    m_tilemap = cachedComponent as STETilemap;
                    minGridX = m_tilemap.MinGridX;
                    minGridY = m_tilemap.MinGridY;
                    if (onlyVisibleTiles.Value)
                    {
                        Vector2 min = m_tilemap.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Vector2.zero));
                        minGridX = TilemapUtils.GetGridX(m_tilemap, min);
                        minGridY = TilemapUtils.GetGridY(m_tilemap, min);
                    }
                    gridX.Value = minGridX - 1; //NOTE: OnEnter will add 1 the first time
                    gridY.Value = minGridY;
                    storePosition.Value = (ePositionType)positionType.Value == ePositionType.LocalPosition ?
                    (Vector2)TilemapUtils.GetGridWorldPos(m_tilemap, gridX.Value, gridY.Value)
                    :
                    new Vector2(gridX.Value, gridY.Value);
                }
            }

            minGridX = m_tilemap.MinGridX;
            maxGridX = m_tilemap.MaxGridX;
            minGridY = m_tilemap.MinGridY;
            maxGridY = m_tilemap.MaxGridY;
            if (onlyVisibleTiles.Value)
            {
                Vector2 min = m_tilemap.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Vector2.zero));
                Vector2 max = m_tilemap.transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight)));
                minGridX = TilemapUtils.GetGridX(m_tilemap, min);
                maxGridX = TilemapUtils.GetGridX(m_tilemap, max);
                minGridY = TilemapUtils.GetGridY(m_tilemap, min);
                maxGridY = TilemapUtils.GetGridY(m_tilemap, max);
            }


            if (gridX.Value < maxGridX) ++gridX.Value;
            else if (gridY.Value < maxGridY)
            {
                ++gridY.Value;
                gridX.Value = minGridX;
            }
            else
            {
                Finish();
                return;
            }

            storePosition.Value = (ePositionType)positionType.Value == ePositionType.LocalPosition?
                (Vector2)TilemapUtils.GetGridWorldPos(m_tilemap, gridX.Value, gridY.Value)
                :
                new Vector2(gridX.Value, gridY.Value);

            Fsm.Event(iterationNextElement);
        }

    }
}
#endif

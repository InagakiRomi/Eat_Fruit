#if PLAYMAKER && SUPER_TILEMAP_EDITOR
using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;
using HutongGames.PlayMaker.Actions;

namespace CreativeSpore.SuperTilemapEditor.PlayMakerActions
{
    [ActionCategory("STE: Tilemap")]
    [Tooltip("Sets the tile data at some position in a tilemap")]
    //[HelpUrl("")]
    public class SetTileData : PositionalActionBase
    {
        [HutongGames.PlayMaker.ActionSection("Input")]
        
        [Tooltip("The tile id found. Will be -1 if no tile is found.")]
        public FsmInt tileId;

        [Tooltip("The brush id found. Will be -1 if no tile is found.")]
        public FsmInt brushId;

        [Tooltip("The flags for this tile.")]
        [ObjectType(typeof(eTileFlags))]
        public FsmEnum tileFlags;

        public override void Reset()
        {
            base.Reset();
            positionType = null;
            position = null;
            tileId = null;
            brushId = null;
            tileFlags = null;
        }

        public override void OnEnter()
        {
            Debug.Log("SetTile action!");
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (UpdateCache(go))
            {
                STETilemap tilemap = cachedComponent as STETilemap;
                if ((ePositionType)positionType.Value == ePositionType.LocalPosition)
                {
                    tilemap.SetTile(position.Value, tileId.Value, brushId.Value, (eTileFlags)tileFlags.Value);
                }
                else// if ((ePositionType)positionType.Value == ePositionType.GridPosition)
                {
                    tilemap.SetTile((int)position.Value.x, (int)position.Value.y, tileId.Value, brushId.Value, (eTileFlags)tileFlags.Value);
                }
                tilemap.UpdateMesh();
            }

            Finish();
        }

    }
}
#endif

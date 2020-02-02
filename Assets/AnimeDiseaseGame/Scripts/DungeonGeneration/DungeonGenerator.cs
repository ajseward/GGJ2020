using System;
using System.Collections.Generic;
using System.Linq;
using GameJamStarterKit;
using UnityEngine;

namespace AnimeDiseaseGame
{
    public class DungeonGenerator : SingletonBehaviour<DungeonGenerator>
    {
        public List<DungeonRoot> DungeonTiles = new List<DungeonRoot>();
        
        [HideInInspector]
        public List<DungeonRoot> ActiveTiles = new List<DungeonRoot>();
        public DungeonRoot RootTile;
        private TileType _regressDirection;

        private void Start()
        {
        }

        public void WipeMap()
        {
            var queue = new Queue<DungeonRoot>();
            ActiveTiles.ForEach(queue.Enqueue);

            while (queue.Count > 0)
            {
                var tile = queue.Dequeue();

                tile.Remove();
            }
        }

        private DungeonRoot GenerateStartTile()
        {
            var go = Instantiate(RootTile.gameObject, Vector3.zero, Quaternion.identity);
            RootTile = go.GetComponent<DungeonRoot>();
            
            if (!RootTile.UpExit)
                return null;
            
            _regressDirection = TileType.Down;
            return GenerateTile(TileType.Up, RootTile.UpExit);

        }

        public DungeonRoot GenerateTile(TileType direction, Transform position)
        {
            if (position.childCount > 0)
                return null;
            var enterance = DungeonUtility.GetOppositeTile(direction);
            var tiles = DungeonTiles.Where(dt => dt.HasExit(enterance));
            if (enterance != _regressDirection)    
            {
                tiles = tiles.Where(dt => !dt.HasExit(_regressDirection));
            }

            foreach (TileType tileType in Enum.GetValues(typeof(TileType)))
            {
                if (SweepDirection(position, tileType))
                {
                    tiles = tiles.Where(dt => !dt.HasExit(tileType));
                }
            }

            if (!tiles.Any())
                return null;
            
            var tile = tiles.RandomItem();

            var go = Instantiate(tile.gameObject, position, true);

            var dungeonRoot = go.GetComponent<DungeonRoot>();
            dungeonRoot.MoveToSide(direction, position);
            return dungeonRoot;
        }

        private bool SweepDirection(Transform origin, TileType direction)
        {
            Vector2 dir;
            switch (direction)
            {
                default:
                case TileType.None:
                    return false;
                case TileType.Up:
                    dir = Vector2.up;
                    break;
                case TileType.Left:
                    dir = Vector2.left;
                    break;
                case TileType.Right:
                    dir = Vector2.right;
                    break;
                case TileType.Down:
                    dir = Vector2.down;
                    break;
            }
            var hits = Physics2D.BoxCastNonAlloc(origin.position, Vector2.one / 2f, 0f, dir, new RaycastHit2D[2], 10f);

            return hits > 1;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameJamStarterKit;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace AnimeDiseaseGame
{
    public class DungeonGenerator : SingletonBehaviour<DungeonGenerator>
    {
        public List<DungeonRoot> DungeonTiles = new List<DungeonRoot>();
        public DungeonRoot RootTile;

        private void Start()
        {
            GenerateStartTile();
            /*for (var i = 0; i < 10; ++i)
            {
                var queue = new Queue<Transform>();
                queue.Enqueue(RootTile.transform);
                while (queue.Count > 0)
                {
                    var t = queue.Dequeue();
                    foreach (Transform child in t)
                    {
                        queue.Enqueue(child);
                    }
                    
                    var tile = t.GetComponent<DungeonRoot>();
                    if (tile == null)
                        continue;

                    foreach (TileType tileType in Enum.GetValues(typeof(TileType)))
                    {
                        if (tileType == TileType.None)
                            continue;
                        
                        if (tile.HasExit(tileType))
                        {
                            GenerateTile(tileType, tile.GetExit(tileType));
                            yield return null;
                        }
                    }
                }
            }*/
        }

        private void GenerateStartTile()
        {
            var go = Instantiate(RootTile.gameObject, Vector3.zero, Quaternion.identity);
            RootTile = go.GetComponent<DungeonRoot>();
            if (RootTile.UpExit)
            {
                GenerateTile(TileType.Up, RootTile.UpExit);
            }

            if (RootTile.DownExit)
            {
                GenerateTile(TileType.Down, RootTile.DownExit);
            }

            if (RootTile.LeftExit)
            {
                GenerateTile(TileType.Left, RootTile.LeftExit);
            }

            if (RootTile.RightExit)
            {
                GenerateTile(TileType.Right, RootTile.RightExit);
            }
        }

        public DungeonRoot GenerateTile(TileType direction, Transform position)
        {
            if (position.childCount > 0)
                return null;
            
            var oppositeDir = DungeonUtility.GetOppositeTile(direction);
            
            var tiles = DungeonTiles.Where(dt => dt.HasExit(DungeonUtility.GetOppositeTile(direction)));

            foreach (TileType tileType in Enum.GetValues(typeof(TileType)))
            {
                if (SweepDirection(position, tileType))
                {
                    tiles = tiles.Where(dt => !dt.HasExit(tileType));
                }
            }
            
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
            var hits = Physics2D.BoxCastNonAlloc(origin.position, Vector2.one / 2f, 0f, dir, new RaycastHit2D[1], 10f);

            return hits > 0;
        }
    }
}
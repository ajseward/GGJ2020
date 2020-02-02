using UnityEngine;

namespace AnimeDiseaseGame
{
    public class DungeonRoot : MonoBehaviour
    {
        public Transform UpExit;
        public Transform LeftExit;
        public Transform RightExit;
        public Transform DownExit;

        public TileType GetTileType()
        {
            var tileType = TileType.None;

            if (UpExit != null)
                tileType |= TileType.Up;

            if (LeftExit != null)
                tileType |= TileType.Left;

            if (RightExit != null)
                tileType |= TileType.Right;

            if (DownExit != null)
                tileType |= TileType.Down;

            return tileType;
        }

        public int ExitCount()
        {
            var i = 0;
            if (UpExit != null)
                ++i;
            if (DownExit != null)
                ++i;
            if (LeftExit != null)
                ++i;
            if (RightExit != null)
                ++i;
            return i;
        }

        public void MoveToSide(TileType side, Transform otherSide)
        {
            Transform mySide;
            switch (side)
            {
                default:
                case TileType.None:
                    Debug.LogError("Tried to attach to TileType.None!");
                    return;
                
                case TileType.Up:
                    mySide = DownExit;
                    break;
                case TileType.Left:
                    mySide = RightExit;
                    break;
                case TileType.Right:
                    mySide = LeftExit;
                    break;
                case TileType.Down:
                    mySide = UpExit;
                    break;
            }

            var offset = mySide.localPosition;
            transform.SetPositionAndRotation(otherSide.position - offset, transform.rotation);
        }

        public Transform GetExit(TileType direction)
        {
            switch (direction)
            {
                default:
                case TileType.None:
                    return null;
                case TileType.Up:
                    return UpExit;
                
                case TileType.Left:
                    return LeftExit;
                
                case TileType.Right:
                    return RightExit;
                
                case TileType.Down:
                    return DownExit;
            }
        }

        public bool HasExit(TileType tileType)
        {
            return GetTileType().HasFlag(tileType);
        }

        public void Remove()
        {
            Destroy(gameObject);
        }
    }
}
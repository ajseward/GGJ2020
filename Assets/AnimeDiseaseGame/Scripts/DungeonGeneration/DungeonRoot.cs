using System.Linq;
using GameJamStarterKit;
using GameJamStarterKit.HealthSystem;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.HasComponent<CharacterControl>())
            {
                var collider = GetComponent<Collider2D>();
                var hits = Physics2D.BoxCastAll(collider.offset + (Vector2)transform.position, collider.GetSize(), 0f, Vector2.up);
                if (hits.Any(hit => hit.transform.gameObject.HasComponent<Boss>()))
                {
                    var bgm = BGMController.Instance;
                    bgm.PlaySong("Boss");
                }
                else if (hits.Any(hit => hit.transform.gameObject.HasComponent<Enemy>()))
                {
                    var bgm = BGMController.Instance;
                    bgm.PlaySong("Combat");
                }
                foreach (var hit in hits)
                {
                    if (hit.transform.gameObject.HasComponent<CharacterControl>())
                        continue;
                    var enemy = hit.transform.gameObject.GetComponent<Enemy>();
                    if (enemy != null && !enemy.IsAwake)
                    {
                        enemy.WakeUp();
                        var health = enemy.GetComponent<HealthComponent>();
                        GameController.Instance.ActiveEnemies += 1;
                        health.OnHealthEmpty.AddListener(() =>
                        {
                            GameController.Instance.ActiveEnemies -= 1;
                            if (GameController.Instance.ActiveEnemies <= 0)
                            {
                                var bgm = BGMController.Instance;
                                bgm.PlaySong("Calm");
                            }
                        });
                    }
                }
            }
        }
    }
}
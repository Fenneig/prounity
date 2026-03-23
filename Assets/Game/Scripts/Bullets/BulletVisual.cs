using System;
using Game.Utils;
using Game.Visual;
using UnityEngine;

namespace Game.Bullets
{
    public class BulletVisual : MonoBehaviour
    {
        [SerializeField] private Transform _vfxContainer;
        [SerializeField] private GameObject _blueTeamVfx;
        [SerializeField] private GameObject _redTeamVfx;
        
        private GameObject _explosionVfx;
        private VfxPool _vfxPool;

        public void Construct(VfxPool vfxPool)
        {
            _vfxPool = vfxPool;
        }

        public void Initialize(BulletConfig config, TeamType team)
        {
            _explosionVfx = config.ExplosionVFX;
            SetupVfx(team);
        }

        public void EndLife(BulletEndReason reason)
        {
            if (reason == BulletEndReason.Hit)
                _vfxPool.Get(_explosionVfx, transform.position, _explosionVfx.transform.rotation);
        }

        private void SetupVfx(TeamType team)
        {
            switch (team)
            {
                case TeamType.Enemy:
                    _blueTeamVfx.SetActive(false);
                    _redTeamVfx.SetActive(true);
                    break;
                case TeamType.Player:
                    _blueTeamVfx.SetActive(true);
                    _redTeamVfx.SetActive(false);
                    break;
                case TeamType.None:
                    throw new Exception($"Bullet team type cannot be {team}");
                default:
                    throw new ArgumentOutOfRangeException(nameof(team), team, null);
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids.Bridge
{
    internal sealed class BridgeTest : MonoBehaviour
    {
        private List<Enemy> _enemys = new List<Enemy>();

        private void Start()
        {
            _enemys.Add(new Enemy(new MagicalAttack(), new Infantry()));
            _enemys.Add(new Enemy(new MagicalAttack(), new Fly()));
            _enemys.Add(new Enemy(new MagicalAttack(), new Swim()));
            _enemys.Add(new Enemy(new SimpleAttack(), new Infantry()));
            _enemys.Add(new Enemy(new SimpleAttack(), new Fly()));
            _enemys.Add(new Enemy(new SimpleAttack(), new Swim()));
            _enemys.Add(new Enemy(new FireAttack(), new Infantry()));
            _enemys.Add(new Enemy(new FireAttack(), new Fly()));
            _enemys.Add(new Enemy(new FireAttack(), new Swim()));
        }
    }
}

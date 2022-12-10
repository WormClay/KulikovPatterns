using TMPro;
using UnityEngine;
namespace Asteroids
{
    public sealed class ListenerDie
    {
        private TMP_Text _text;
        public ListenerDie ()
        {
            _text = GameObject.Find("DieInfo").GetComponent<TextMeshProUGUI>();
        }
        public void Add(IDie value)
        {
            value.EnemyDied += OnEnemyDied;
        }
        public void Remove(IDie value)
        {
            value.EnemyDied -= OnEnemyDied;
        }
        private void OnEnemyDied(Enemy enemy)
        {
            Remove(enemy);
            if (enemy.IsKilled) 
            {
                //Debug.Log("IDie - " + enemy);
                _text.text += $"Die: {enemy}\n";
            }
        }
    }
}

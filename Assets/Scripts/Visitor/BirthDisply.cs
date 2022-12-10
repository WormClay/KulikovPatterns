using TMPro;
using UnityEngine;
namespace Asteroids
{
    public sealed class BirthDisply: IEnemyVisitor
    {
        private TMP_Text _text;
        public BirthDisply()
        {
            _text = GameObject.Find("BirthInfo").GetComponent<TextMeshProUGUI>();
        }
        public void Visit(Asteroid birth)
        {
            Show(birth);
            //Do something else
        }
        public void Visit(EnemyShip birth)
        {
            Show(birth);
            //Do nothing else :))
        }
        private void Show(Enemy enemy)
        {
            _text.text += $"Birth: {enemy}\n";
        }
    }
}
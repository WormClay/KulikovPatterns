using TMPro;
using UnityEngine;

namespace Asteroids
{
    public sealed class UIHealth
    {
        private TMP_Text _textHelth;

        public UIHealth(float hp)
        {
            _textHelth = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
            SetHelth(hp);
        }

        public void SetHelth(float hp)
        {
            _textHelth.text = $"Helth: {hp}";
        }
    }
}

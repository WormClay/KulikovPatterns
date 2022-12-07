using TMPro;
using UnityEngine;
namespace Asteroids
{
    internal sealed class PanelOne : BaseUI
    {
        [SerializeField] private TMP_Text _text;
        public override void Execute()
        {
            _text.text = nameof(PanelOne);
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}
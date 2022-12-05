using TMPro;
using UnityEngine;

namespace Asteroids.UnitFactory
{
    public sealed class MagView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textHelth;

        public void SetTextHealth(int textHealth) 
        {
            _textHelth.text = textHealth.ToString();
        }
    } 
}

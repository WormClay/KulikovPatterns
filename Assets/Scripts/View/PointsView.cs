using TMPro;
using UnityEngine;
namespace Asteroids
{
    public class PointsView
    {
        private TMP_Text _textPoints;

        public PointsView(long points)
        {
            _textPoints = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
            SetPoints(points.ToString());
        }

        public void SetPoints(string points)
        {
            _textPoints.text = $"Points: {points}";
        }
    }
}

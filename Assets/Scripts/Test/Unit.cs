using UnityEngine;
namespace Test
{
    public class Unit
    {
        private Model _model;
        private View _view;
        public Unit(string name, View prefab)
        {
            _model = new Model(name);
            _view = Object.Instantiate(prefab);
            _view.EventDestroy += OnDestroyView;
        }
        public void OnDestroyView()
        {
            _view.EventDestroy -= OnDestroyView;
            //Узнали что подохли
        }
    }
}

using System;
using System.Collections.Generic;
namespace Asteroids.UnitFactory
{
    [Serializable]
    public sealed class PropertySave
    {
        public string type;
        public int health;
    }

    [Serializable]
    public sealed class UnitSave
    {
        public PropertySave unit;
    }

    [Serializable]
    public sealed class ListSave
    {
        public List<UnitSave> list;
    }
}


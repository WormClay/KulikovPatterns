using System;

namespace Asteroids
{
    [Serializable]
    public class DictionaryIntString : UnitySerializedDictionary<int, string> { }

    [Serializable]
    public class DictionaryIntInt : UnitySerializedDictionary<int, int> { }
}
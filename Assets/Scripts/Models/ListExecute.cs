using System.Collections.Generic;

namespace Asteroids
{
    public sealed class ListExecute
    {
        public List<IExecute> ListObject { get; private set; }
        public ListExecute()
        {
            ListObject = new List<IExecute>();
        }

        public void Add(IExecute element)
        {
            ListObject.Add(element);
        }
    }
}
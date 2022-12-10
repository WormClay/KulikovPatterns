namespace Test
{
    public sealed class Model
    {
        public string Name { get; private set; }
        public Model(string name)
        {
            Name = name;
        }
    }
}
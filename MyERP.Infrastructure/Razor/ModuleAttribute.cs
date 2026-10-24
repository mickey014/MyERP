namespace MyERP.Infrastructure.Razor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ModuleAttribute : Attribute
    {
        public string Name { get; }

        public ModuleAttribute(string name)
        {
            Name = name;
        }
    }
}

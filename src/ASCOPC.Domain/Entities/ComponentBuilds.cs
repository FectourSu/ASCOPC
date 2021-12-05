namespace ASCOPC.Domain.Entities
{
    public class ComponentBuilds
    {
        public ComponentBuilds()
        {
        }

        public ComponentBuilds(Builds build, Component components)
        {
            Components = components;
            ComponentId = components.Id;

            Build = build;
            BuildId = build.Id;
        }
        public int BuildId { get; set; }
        public int ComponentId { get; set; }
        public virtual Builds Build { get; set; }
        public virtual Component Components { get; set; }
    }
}

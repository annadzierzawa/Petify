namespace Petify.Domain.Access
{
    public class Action
    {
        public Action() { }
        public Action(int id, string name) { Id = id;  Name = name; }
        public Action(string name) { Name = name; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

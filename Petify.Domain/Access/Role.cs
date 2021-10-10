namespace Petify.Domain.Access
{
    public class Role
    {
        public Role() { }
        public Role(int id, string name) { Id = id; Name = name; }
        public Role(string name) { Name = name; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

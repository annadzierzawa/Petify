namespace Petify.Domain.Access
{
    public class RoleAction
    {
        public int RoleId { get; set; }
        public int ActionId { get; set; }
        public string Level { get; set; }

        public virtual Role Role { get; set; }
        public virtual Action Action { get; set; }
    }
}

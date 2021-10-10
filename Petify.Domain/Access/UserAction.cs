namespace Petify.Domain.Access
{
    public class UserAction
    {
        public string UserId { get; set; }
        public int ActionId { get; set; }
        public string Level { get; set; }

        public virtual User User { get; set; }
        public virtual Action Action { get; set; }
    }
}

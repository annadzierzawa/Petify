namespace Petify.Domain.Access
{
    public class UserPermission
    {
        public string UserId { get; set; }
        public int ActionId { get; set; }
        public string Level { get; set; }
    }
}

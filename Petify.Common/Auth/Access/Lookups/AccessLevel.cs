namespace Petify.Common.Auth.Access.Lookups
{
    public class AccessLevel
    {
        public AccessLevel(string id)
        {
            Id = id;
        }

        public static AccessLevel Full => new AccessLevel("F");

        public static AccessLevel Restricted => new AccessLevel("R");

        public static AccessLevel None => new AccessLevel("N");

        public string Id { get; }
    }
}

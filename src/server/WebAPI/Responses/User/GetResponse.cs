using System;

namespace WebAPI.Responses.User
{
    public class GetResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short StateCode { get; set; }
        public short StatusCode { get; set; }
    }
}

using System;

namespace WebAPI.Responses
{
    public class CreateResponse : IResponse
    {
        public Guid Id { get; set; }
    }
}
using System;

namespace Lucca.Contracts
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Currency_ISO { get; set; }
    }
}
using System;

namespace Entities.Dtos.Individuals
{
    public class IndividualDto : BaseDto
    { 
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

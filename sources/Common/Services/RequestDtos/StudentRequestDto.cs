namespace Services.RequestDtos
{
    public record StudentRequestDto
    {
        public string? Id { get; set; }
        public required string FirstName { get; set; }
        public string? Username { get; set; }
        public required string LastName { get; set; }
        public required string NicNumber { get; set; }
        public string? ImageUrl { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Address { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Sys_Deactivated { get; set; } = false;
    }
}

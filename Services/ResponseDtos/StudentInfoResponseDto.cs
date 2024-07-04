﻿namespace Services.ResponseDtos
{
    public record StudentInfoResponseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
        public string? ImageUrl { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Id { get; set; }
        public string? NicNumber { get; set; }
        public string? Address { get; set; }
    }
}

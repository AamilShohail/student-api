namespace Services.ResponseDtos
{
    public record ResponseDto<T>
    {
        public bool Succeeded { get; set; }
        public string? ResponseMessage { get; set; }
        public T? Data { get; set; }
    }
}

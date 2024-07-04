using Services.RequestDtos;
using Services.ResponseDtos;

namespace Services.StudentServices
{
    public interface IStudentManager
    {
        Task<ResponseDto<StudentInfoResponseDto>> UpsertAsync(StudentRequestDto requestDto);
        Task<ResponseDto<List<StudentInfoResponseDto>>> GetStudentsAsync();
    }
}
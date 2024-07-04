using Microsoft.Data.SqlClient;
using Services.RequestDtos;
using Services.ResponseDtos;

namespace Services.StudentServices
{
    public partial class StudentManager : IStudentManager
    {
        public async Task<ResponseDto<StudentInfoResponseDto>> UpsertAsync(StudentRequestDto requestDto)
        {
            var student = await GetOrCreateStudentAsync(requestDto);
            var result = await SaveStudentAsync(student, requestDto);

            return new()
            {
                Data = (await dbAccessProvider.GetEntityResults<StudentInfoResponseDto>("Get_Students", parameters: new SqlParameter("@StudentId", student.Id)))?.Data?.FirstOrDefault(),
                Succeeded = result.Succeeded,
                ResponseMessage = result.Errors?.FirstOrDefault()?.Description
            };
        }
        public async Task<ResponseDto<List<StudentInfoResponseDto>>> GetStudentsAsync() => new()
        {
            Data = (await dbAccessProvider.GetEntityResults<StudentInfoResponseDto>("Get_Students"))?.Data,
            Succeeded = true
        };
    }
}

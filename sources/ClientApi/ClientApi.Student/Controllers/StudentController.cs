using Microsoft.AspNetCore.Mvc;
using Services.RequestDtos;
using Services.ResponseDtos;
using Services.StudentServices;

namespace ClientApi.Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentManager studentManager) : ControllerBase
    {
        [HttpPost]
        public async Task<ResponseDto<StudentInfoResponseDto>> PostStudent(StudentRequestDto requestDto) => await studentManager.UpsertAsync(requestDto);
        [HttpGet]
        public async Task<ResponseDto<List<StudentInfoResponseDto>>> GeyStudents() => await studentManager.GetStudentsAsync();
    }
}

using Database.Entities;
using Database.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Services.RequestDtos;

namespace Services.StudentServices
{
    public partial class StudentManager(UserManager<Student> userManager, IDbAccessProvider dbAccessProvider)
    {
        private async Task<Student> GetOrCreateStudentAsync(StudentRequestDto requestDto)
        {
            var user = await userManager.FindByIdAsync(requestDto.Id ?? string.Empty);
            return user is null ? CreateStudent(requestDto) : UpdateStudent(requestDto, user);
        }
        private static Student CreateStudent(StudentRequestDto student) => new()
        {
            UserName = student.Username,
            Email = student.Email,
            FirstName = student.FirstName,
            LastName = student.LastName,
            PhoneNumber = student.PhoneNumber,
            NicNumber = student.NicNumber,
            Address = student.Address,
            DateOfBirth = student.DateOfBirth,
        };
        private static Student UpdateStudent(StudentRequestDto studentDto, Student student)
        {
            student.UpdatedDate = DateTime.UtcNow;
            student.UserName = studentDto.Username;
            student.Email = studentDto.Email;
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Sys_Deactivated = studentDto.Sys_Deactivated;
            student.PhoneNumber = studentDto.PhoneNumber;
            student.Address = studentDto.Address;
            student.NicNumber = studentDto.NicNumber;
            student.DateOfBirth = studentDto.DateOfBirth;

            return student;
        }
        private async Task<IdentityResult> SaveStudentAsync(Student student, StudentRequestDto studentDto)
        {
            var user = await userManager.FindByIdAsync(studentDto.Id ?? string.Empty);
            return user is null
                ? await userManager.CreateAsync(student)
                : await userManager.UpdateAsync(student);
        }
    }
}

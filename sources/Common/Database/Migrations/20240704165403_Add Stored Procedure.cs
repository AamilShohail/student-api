using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var getStudents = @"EXEC('
                                            CREATE OR ALTER PROC Get_Students
                                            (
                                                @StudentId NVARCHAR(100) = NULL
                                            )
                                            AS 
                                            BEGIN
                                                SELECT	[User].FirstName,
                                                        [User].LastName,
                                                        [User].UserName,
                                                        [User].Email,
                                                        [User].PhoneNumber,
			                                            [User].ImageUrl,
			                                            [User].NicNumber,
			                                            [User].DateOfBirth,
			                                            [User].[Address],
			                                            Username = [User].UserName,
                                                        Id = [User].Id
                                                FROM	AspNetUsers [User]
                                                WHERE	[User].Sys_Deactivated = 0
                                                        AND ([User].Id = @StudentId OR @StudentId IS NULL)
                                                FOR JSON PATH;
                                            END
                                         ')";
            migrationBuilder.Sql(getStudents);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropStudents = "DROP PROC Get_Students";
            migrationBuilder.Sql(dropStudents);
        }
    }
}

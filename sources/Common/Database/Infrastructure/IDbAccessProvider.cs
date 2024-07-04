using Microsoft.Data.SqlClient;

namespace Database.Infrastructure
{
    public interface IDbAccessProvider
    {
        Task<DbAccessProvider.ResponseDto<List<T>>?> GetEntityResults<T>(string procedure, params SqlParameter[]? parameters);
    }
}
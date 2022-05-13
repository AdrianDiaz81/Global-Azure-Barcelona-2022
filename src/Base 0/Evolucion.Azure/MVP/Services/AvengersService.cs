using Microsoft.Extensions.Options;
using MVP.Model;
using MVP.Services.Options;
using System.Data.SqlClient;

namespace MVP.Services
{
    public class AvengersService : IAvengersService
    {
        private readonly SqlServerOptions _sqlOptionsMonitor;

        public AvengersService(IOptionsMonitor<SqlServerOptions> sqlOptionsMonitor) => _sqlOptionsMonitor = sqlOptionsMonitor.CurrentValue;
         

        public async Task<bool> DeleteAsync(string avengerId, CancellationToken cancellationToken = default)
        {

            var query = $"DELETE FROM dbo.{_sqlOptionsMonitor.AvengersTableName} WHERE Id = @AvengerId";
            using var conn = new SqlConnection(_sqlOptionsMonitor.ConnectionString);
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AvengerId", avengerId);            
            var result = await cmd.ExecuteNonQueryAsync(cancellationToken);

            return (result > 0);
        }

        public async Task<AvengersListDto> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var results = new List<AvengersDto>();            
            var query = $"SELECT * FROM dbo.{_sqlOptionsMonitor.AvengersTableName}";
            using var conn = new SqlConnection(_sqlOptionsMonitor.ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(query, conn);
            

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (!reader.HasRows) return null;

            while (await reader.ReadAsync(cancellationToken))
            {
                results.Add(new AvengersDto
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    UrlPhoto = reader.GetString(2),
                    Description = reader.GetString(3)
                });
            }
            reader.Close();
            
            return new AvengersListDto {  Result = results };
        }

        public async Task<AvengersDto> GetByIdAsync(string avengerId, CancellationToken cancellationToken = default)
        {            
            var query = $"SELECT * FROM dbo.{_sqlOptionsMonitor.AvengersTableName} WHERE Id = @AvengerId";
            using var conn = new SqlConnection(_sqlOptionsMonitor.ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AvengerId", avengerId);

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);

            if (!reader.HasRows) return null;

            await reader.ReadAsync(cancellationToken);

           var results = new AvengersDto
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                UrlPhoto = reader.GetString(2),
                Description = reader.GetString(3)
            };

            return results;
            
        }

        public async Task<bool> InsertAsync(AvengersDto avengers, CancellationToken cancellationToken = default)
        {
            var query = $"INSERT INTO dbo.{_sqlOptionsMonitor.AvengersTableName} (Id,Name, Description, UrlPhoto) VALUES (@AvengerId, @Name, @Description, @UrlPhoto)";
            using var conn = new SqlConnection(_sqlOptionsMonitor.ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AvengerId", avengers.Id);
            cmd.Parameters.AddWithValue("@Name", avengers.Name);
            cmd.Parameters.AddWithValue("@Description", avengers.Description);
            cmd.Parameters.AddWithValue("@UrlPhoto", avengers.UrlPhoto);

            var result = await cmd.ExecuteNonQueryAsync(cancellationToken);


            return (result > 0);
        }

        public async Task<bool> UpdateAsync(AvengersDto avengers, CancellationToken cancellationToken = default)
        {
            var query = $"UPDATE dbo.{_sqlOptionsMonitor.AvengersTableName} SET Name = @Name, Description = @Description, UrlPhoto = @UrlPhoto  WHERE Id = @AvengerId";
            using var conn = new SqlConnection(_sqlOptionsMonitor.ConnectionString);
            conn.Open();

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AvengerId",avengers.Id);
            cmd.Parameters.AddWithValue("@Name", avengers.Name);
            cmd.Parameters.AddWithValue("@Description", avengers.Description);
            cmd.Parameters.AddWithValue("@UrlPhoto", avengers.UrlPhoto);

           var result= await cmd.ExecuteNonQueryAsync(cancellationToken);
            

            return (result>0);
        }
    }
}

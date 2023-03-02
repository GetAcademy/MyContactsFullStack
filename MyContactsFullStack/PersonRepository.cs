using System.Data.SqlClient;
using Dapper;
using MyContactsFullStack.Model;

namespace MyContactsFullStack
{
    internal class PersonRepository
    {
        private readonly SqlConnection _sqlConnection;

        public PersonRepository(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            const string sql = "SELECT Id, Name, Email FROM Person";
            return await _sqlConnection.QueryAsync<Person>(sql);
        }

        public async Task<Person?> ReadById(Guid id)
        {
            const string sql = "SELECT Id, Name, Email FROM Person WHERE Id = @Id";
            var people = await _sqlConnection.QueryAsync<Person>(sql, new { Id = id });
            return people.SingleOrDefault();
        }

        public async Task<int> Create(Person person)
        {
            const string sql = "INSERT INTO Person VALUES (@Id, @Name, @Email)";
            var rowsAffected = await _sqlConnection.ExecuteAsync(sql, person);
            return rowsAffected;
        }

        public async Task<int> Update(Person person)
        {
            const string sql = @"UPDATE Person 
                SET Name = @Name, 
                    Email = @Email 
                WHERE Id = @Id";
            var rowsAffected = await _sqlConnection.ExecuteAsync(sql, person);
            return rowsAffected;
        }

        public async Task<int> Delete(Person person)
        {
            const string sql = @"DELETE FROM Person WHERE Id = @Id";
            var rowsAffected = await _sqlConnection.ExecuteAsync(sql, person);
            return rowsAffected;
        }

        public async Task<int> Delete(Guid id)
        {
            const string sql = @"DELETE FROM Person WHERE Id = @Id";
            var rowsAffected = await _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected;
        }
    }
}

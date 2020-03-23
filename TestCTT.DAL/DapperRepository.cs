using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TestCTT.Domain;

namespace TestCTT.DAL
{
    public static class DapperORM
    {
        #region generica
        private static string connectionString = @"Server=localhost;Database=ctt_test;Uid=root;Pwd=root";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using (MySqlConnection sql = new MySqlConnection(connectionString))
            {
                sql.Open();
                sql.Execute(procedureName, param, commandType: System.Data.CommandType.Text);
            }

        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param)
        {
            using (MySqlConnection sql = new MySqlConnection(connectionString))
            {
                sql.Open();
                return sql.Query<T>(procedureName, param, commandType: System.Data.CommandType.Text);
            }

        }
        #endregion

        public static IEnumerable<User> GetAllUsers()
        {
            string sqlUserSelectById = "SELECT * FROM user";

            return ReturnList<User>(sqlUserSelectById, null);
        }

        public static User GetUserById(int id)
        {
            string sqlUserSelectById = "SELECT * FROM user WHERE id = @Id;";

            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return ReturnList<User>(sqlUserSelectById, param).FirstOrDefault();
        }

        public static void AddUser(User u)
        {
            try
            {
                string sqlUserInsert = "INSERT INTO user (id,nome) Values (@Id, @Nome);";

                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", u.id);
                param.Add("@Nome", u.nome);
                ExecuteWithoutReturn(sqlUserInsert, param);
                return;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}

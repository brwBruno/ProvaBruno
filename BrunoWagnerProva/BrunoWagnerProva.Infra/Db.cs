﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BrunoWagnerProva.Infra
{
    public static class Db
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["BrunoWagnerProva"].ConnectionString;
        private static readonly string _providerName = ConfigurationManager.ConnectionStrings["BrunoWagnerProva"].ProviderName;
        private static readonly DbProviderFactory _factory = DbProviderFactories.GetFactory(_providerName);

        public static string IdentifyProvider
        {
            get
            {
                switch (_providerName)
                {
                    // Microsoft Access não tem suporte a esse tipo de comando
                    case "System.Data.OleDb": return "@";
                    case "System.Data.SqlClient": return "@";
                    case "System.Data.OracleClient": return ":";
                    case "MySql.Data.MySqlClient": return "?";

                    default:
                        return "@";
                }
            }
        }

        public static string PegarConnectionString()
        {
            return _connectionString;
        }

        public static int Adicionar(string sql, Dictionary<string, object> parms = null, bool identitySelect = true)
        {
            sql = string.Format(sql, IdentifyProvider);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.SetParameters(parms); // Extension method
                    command.CommandText = identitySelect ? sql.AppendIdentitySelect() : sql; // Extension method

                    connection.Open();

                    int id = 0;

                    if (identitySelect)
                        id = Convert.ToInt32(command.ExecuteScalar());
                    else
                        command.ExecuteNonQuery();

                    return id;
                }
            }
        }

        public static void Atualizar(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, IdentifyProvider);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
            }
        }

        public static void Deletar(string sql, Dictionary<string, object> parms = null)
        {
            Atualizar(sql, parms);
        }

        public static List<T> SelecionarTodos<T>(string sql, Func<IDataReader, T> Criar, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, IdentifyProvider);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var obj = Criar(reader);
                        list.Add(obj);
                    }

                    command.Parameters.Clear();

                    return list;
                }
            }
        }

        public static T Selecionar<T>(string sql, Func<IDataReader, T> Criar, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, IdentifyProvider);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    T t = default(T);

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                        t = Criar(reader);

                    command.Parameters.Clear();

                    return t;
                }
            }
        }

        public static string AppendIdentitySelect(this string sql)
        {
            switch (_providerName)
            {
                // Microsoft Access não tem suporte a esse tipo de comando
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                case "Firebird.Data.FbClient": return sql + ";GENERATOR(x=>x.identity)";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }

        private static void SetParameters(this DbCommand command, Dictionary<string, object> parms)
        {
            if (parms != null)
            {
                foreach (var item in parms)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = item.Key;
                    dbParameter.Value = item.Value;

                    command.Parameters.Add(dbParameter);
                }

            }
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DapperClassHelper
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = "Server={0};Integrated Security=SSPI";
        private readonly string _connectionStringWithDb = "Server={0};DataBase={1};Integrated Security=SSPI";

        private string _sqlServer;

        private readonly string _getSqlServerDb = "SELECT name AS DbName FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbSqlServer.Text))
            {
                MessageBox.Show("Pls input Sql Server");
                return;
            }

            cbDbs.Items.Clear();

            _sqlServer = tbSqlServer.Text;

            this.GetDatabaseNames();
        }

        private void GetDatabaseNames()
        {
            try
            {
                using (var conn = this.GetConnection())
                {
                    var dbs =
                        conn.Query<Db>(_getSqlServerDb).ToList();

                    if (dbs.Count > 0)
                    {
                        cbDbs.DisplayMember = "DbName";
                        cbDbs.ValueMember = "DbName";

                        foreach (var db in dbs)
                        {
                            cbDbs.Items.Add(db);
                        }

                        cbDbs.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ..." + ex.ToString());
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(string.Format(this._connectionString, _sqlServer));
        }

        private SqlConnection GetConnectionWithDb()
        {
            var db = cbDbs.Items[cbDbs.SelectedIndex] as Db;
            
            return new SqlConnection(string.Format(this._connectionStringWithDb, _sqlServer, db.DbName));
        }

        private void btnGetClass_Click(object sender, EventArgs e)
        {
            if (cbDbs.Items.Count == 0)
            {
                MessageBox.Show("Pls Connection First");
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbCommandText.Text))
            {
                MessageBox.Show("Pls input commandText");
                return;
            }

            var className = string.IsNullOrWhiteSpace(tbClassName.Text) ? "Info" : tbClassName.Text;
            var classText = this.GetClassTextByCommandText(tbCommandText.Text, className);

            tbClass.Text = classText;
        }

        private readonly Dictionary<Type, string> TypeAliases = new Dictionary<Type, string> {
              { typeof(int), "int" },
              { typeof(short), "short" },
              { typeof(byte), "byte" },
              { typeof(byte[]), "byte[]" },
              { typeof(long), "long" },
              { typeof(double), "double" },
              { typeof(decimal), "decimal" },
              { typeof(float), "float" },
              { typeof(bool), "bool" },
              { typeof(string), "string" }
         };

        private static readonly HashSet<Type> NullableTypes = new HashSet<Type> {
              typeof(int),
              typeof(short),
              typeof(long),
              typeof(double),
              typeof(decimal),
              typeof(float),
              typeof(bool),
              typeof(DateTime)
         };

        public string GetClassTextByCommandText(string sql, string className)
        {
            var result = string.Empty;
            SqlConnection conn = null;
            try
            {
                conn = this.GetConnectionWithDb();

                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();

                result = GetColumnsByExecuteReader(reader, className);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error .." + ex.ToString());
            }
            finally
            {
                conn?.Close();
            }

            return result;
        }

        //public static string DumpSpClass(this IDbConnection connection, string spName, string className = "Info")
        //{
        //    if (connection.State != ConnectionState.Open)
        //    {
        //        connection.Open();
        //    }

        //    var cmd = connection.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = spName;
        //    var reader = cmd.ExecuteReader();

        //    var result = GetColumnsByExecuteReader(reader, className);

        //    return result;
        //}

        //public static string DumpSpClass(this IDbConnection connection, string spName, string className = "Info", params string[] paramArray)
        //{
        //    if (connection.State != ConnectionState.Open)
        //    {
        //        connection.Open();
        //    }

        //    var cmd = connection.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = spName;

        //    for (int i = 0; i < (int)paramArray.Length; i++)
        //    {
        //        var parameters = cmd.Parameters;
        //        string arrSParam = paramArray[i];
        //        int num = i + 1;
        //        i = num;
        //        parameters.Add(new SqlParameter(arrSParam, paramArray[num]));
        //    }

        //    var reader = cmd.ExecuteReader();

        //    var result = GetColumnsByExecuteReader(reader, className);

        //    return result;
        //}

        //public static string DumpSpClass(this IDbConnection connection, string spName, NameValueCollection fields, string className = "Info")
        //{
        //    if (connection.State != ConnectionState.Open)
        //    {
        //        connection.Open();
        //    }

        //    var cmd = connection.CreateCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = spName;

        //    if (fields != null)
        //    {
        //        for (int i = 0; i < fields.Count; i++)
        //        {
        //            cmd.Parameters.Add(new SqlParameter(fields.Keys[i].ToString(), fields[i]));
        //        }
        //    }

        //    var reader = cmd.ExecuteReader();

        //    var result = GetColumnsByExecuteReader(reader, className);

        //    return result;
        //}

        private string GetColumnsByExecuteReader(IDataReader reader, string className)
        {
            var builder = new StringBuilder();
            do
            {
                if (reader.FieldCount <= 1) continue;

                builder.AppendFormat("public class {0}{1}", className, Environment.NewLine);
                builder.AppendLine("{");
                var schema = reader.GetSchemaTable();

                foreach (DataRow row in schema.Rows)
                {
                    var type = (Type)row["DataType"];
                    var name = TypeAliases.ContainsKey(type) ? TypeAliases[type] : type.Name;
                    var isNullable = (bool)row["AllowDBNull"] && NullableTypes.Contains(type);
                    var collumnName = (string)row["ColumnName"];

                    builder.AppendLine(string.Format("\tpublic {0}{1} {2} {{ get; set; }}", name, isNullable ? "?" : string.Empty, collumnName));
                    builder.AppendLine();
                }

                builder.AppendLine("}");
                builder.AppendLine();
            } while (reader.NextResult());

            return builder.ToString();
        }
    }

    internal class Db
    {
        public string DbName { get; set; }
    }
}

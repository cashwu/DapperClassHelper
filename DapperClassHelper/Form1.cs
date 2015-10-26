using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DapperClassHelper
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = "Server={0};Integrated Security=SSPI";
        private string _sqlServer;
        private SqlConnection _connection;

        private readonly string _getSqlServerDb = "SELECT name AS DbName FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbSqlServer.Text))
            {
                MessageBox.Show("Not Sql Server");  
                return;
            }

            cbDbs.Items.Clear();

            _sqlServer = tbSqlServer.Text;

            this.GetDatabaseNames();
        }

        private void GetDatabaseNames()
        {
            this.GetConnection();

            try
            {
                using (var conn = this._connection)
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

        private SqlCommand GetCommand(string sql)
        {
            return this.GetCommand(sql, CommandType.Text);
        }

        private SqlCommand GetCommand(string sql, CommandType comType)
        {
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sql,
                CommandType = comType
            };

            sqlCommand.Connection = this._connection;

            return sqlCommand;
        }

        private void GetConnection()
        {
            this._connection = new SqlConnection(string.Format(this._connectionString, _sqlServer));
        }
    }

    internal class Db
    {
        public string DbName { get; set; }  
    }
}

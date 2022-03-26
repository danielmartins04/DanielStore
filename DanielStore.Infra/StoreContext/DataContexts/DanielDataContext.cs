using System;
using System.Data;
using System.Data.SqlClient;
using DanielStore.Shared;

namespace DanielStore.Infra.StoreContext.DataContexts
{
    public class DanielDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DanielDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.IO;
using SQLite;
using pruebaCliente.Models;
using pruebaCliente.Services;

namespace pruebaCliente.Services
{
    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(Path.Combine(config.DirDB, "pruebaCliente.db3"), false);
            connection.CreateTable<Connection>();

        }

        public Connection GetConnection()
        {
            if (connection.Table<Connection>().ToList().Count > 0)
            {
                return connection.Table<Connection>().FirstOrDefault(c => c.Id.Equals(0));
            }
            return new Connection();
        }

        public void InsertConnection(Connection con)
        {
            if (connection.Table<Connection>().ToList().Count > 0)
            {
                connection.Delete(connection.Table<Connection>().FirstOrDefault(c => c.Id.Equals(0)));
            }
            connection.Insert(con);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}

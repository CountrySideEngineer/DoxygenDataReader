using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Doxygen.DB.Connection
{
    internal interface IDBConnector<Reader> : IDisposable
    {
        Reader ExecuteQuery(string query);
        Reader ExecuteQuery(string query, Dictionary<string, object> parameters);

        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string query, Dictionary<string, object> parameters);

        void Initialize();

        string SetupConnectionStrign();

        void Disconnect();

        void BeginTransaction();
        void Commit();
        void RollBack();
    }
}

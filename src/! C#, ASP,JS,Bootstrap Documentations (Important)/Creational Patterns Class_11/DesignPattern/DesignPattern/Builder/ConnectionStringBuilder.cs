using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DesignPattern.Builder
{
    internal class ConnectionStringBuilder
    {
        private ConnectionString _connectionString;

        public ConnectionStringBuilder(string server)
        {
            _connectionString = new ConnectionString();
            _connectionString.ConnectionStrinItem.Append($"Server={server};"); 
        }

        public void AddUsernamePassword(string username, string password)
        {
            _connectionString.ConnectionStrinItem.Append($"User={username}, pass={password};");
        }

        public void AddTrustedConnection()
        {

        }

        public void AddTrustedCertificate(string trst)
        {
            _connectionString.ConnectionStrinItem.Append($" TrustServer={trst};");
        }

        public ConnectionString GetConnectionString()
        {
            return _connectionString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Snake.Data
{
    /// <summary>
    /// Singleton DatabaseManager handles all CRUD operations
    /// on the database server.
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Static instance variable which contains the DatabaseManager.
        /// </summary>
        private static DatabaseManager _instance = null;

        /// <summary>
        /// Lock object used to lock this Singleton to a single thread.
        /// </summary>
        private static readonly object _padlock = new object();

        /// <summary>
        /// ConnectionID to the Microsoft SQL Management Server.
        /// </summary>
        private SqlConnection _connection = new SqlConnection("");

        /// <summary>
        /// Returns the Singleton DatabaseManager Instance.
        /// </summary>
        public static DatabaseManager DatabaseManagerInstance
        {
            get
            {
                //Without a lock this singleton is not thread safe
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseManager();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Dictionary of ConnectionId, Player containing all
        /// connected clients.
        /// </summary>
        private Dictionary<String, Player> _connectedClients = new Dictionary<String, Player>();

        /// <summary>
        /// Attempts to login based on given username and password.
        /// </summary>
        /// <param name="clientConnectionId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string clientConnectionId, string username, string password)
        {
            string query = $"SELECT * FROM players WHERE name='{username}' AND encryptedPassword='{password}'";
            using(SqlCommand cmd = new SqlCommand(query, _connection))
            {
                _connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player p = new Player((string)reader[0], (int)reader[1], (Boolean)reader[3], (int) reader[5]);
                        _connectedClients.Add(clientConnectionId, p);
                        _connection.Close();
                        return 0; //Login successful
                    }
                }
            }
            return 1; //Login or Password is invalid.
        }

        /// <summary>
        /// Determines if a given username is taken by another player.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean UsernameExists(string name)
        {
            string query = $"SELECT * FROM players WHERE name='{name}'";
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                _connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if a given email is taken by another player.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Boolean EmailExists(string email)
        {
            string query = $"SELECT * FROM players WHERE email='{email}'";
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                _connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Registers a Player using the given account information.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public int Register(string name, string password, string email)
        {
            if (!UsernameExists(name))
            {
                return 1; //Username is taken
            } else if (!EmailExists(email))
            {

                return 2; //Email is taken
            }
            string query = $"INSERT INTO players(name, encryptedPassword, email) VALUES({name}, {password}, {email})";
            using(SqlCommand cmd = new SqlCommand(query, _connection))
            {
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
            return 0; //Registered Successfully
        }
    }
}

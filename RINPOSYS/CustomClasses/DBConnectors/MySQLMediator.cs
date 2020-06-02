using MySql.Data.MySqlClient;
using RINPOSYS.CustomClasses.RFIDReads;
using System.Collections.Generic;
using System.Data;

namespace RINPOSYS.CustomClasses.DBConnectors
{
    /// <summary>
    /// Manages all MySQL Database interactions.
    /// </summary>
    class MySQLMediator
    {
        /// <summary>
        /// String with all raw parameters, used to connect to MySQL Database
        /// </summary>
        private readonly string ConnStr;

        /// <summary>
        /// String with all parameters, with password disguised, only being used for logging
        /// </summary>
        public readonly string ConnStrNoPassword;

        /// <summary>
        /// Represents Host 
        /// </summary>
        public string Server { get; }

        /// <summary>
        /// Represents Port used
        /// </summary>
        public string Port { get; }

        /// <summary>
        /// Database to connect to
        /// </summary>
        public string Database { get; }

        /// <summary>
        /// User Login credential
        /// </summary>
        public string User { get; }

        /// <summary>
        /// User Password credential
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Table used
        /// </summary>
        public string Table { get; }

        /// <summary>
        /// MySQLManager Contructor
        /// Initializes all values needed for MySQL Database interactions
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="table"></param>
        public MySQLMediator(string connStr, string table)
        {
            ConnStr = connStr;

            string[] connStrArr = connStr.Split(';');
            Server = connStrArr[0].Split('=')[1];
            Port = connStrArr[1].Split('=')[1];
            Database = connStrArr[2].Split('=')[1];
            User = connStrArr[3].Split('=')[1];
            Password = connStrArr[4].Split('=')[1];

            Table = table;

            ConnStrNoPassword = TransformRawConnStr();
        }

        /// <summary>
        /// Transforms raw connection string into connection string with password disguised.
        /// </summary>
        /// <returns>
        /// Returns a new Connection string with password disguised
        /// </returns>
        private string TransformRawConnStr()
        {
            /// Get password from ConnStr
            string pass = ConnStr.Substring(ConnStr.LastIndexOf('=') + 1, ConnStr.Length - ConnStr.LastIndexOf('=') - 1);

            string newPassTransformed = "";

            /// Fill the disguised password with *
            for (int i = 0; i < pass.Length; i++)
            {
                newPassTransformed += '*';
            }

            /// New ConnStr without password
            string newStr = ConnStr.Substring(0, ConnStr.Length - ConnStr.IndexOf('=') - 2);

            /// Return new ConnStr without password concatenated with disguised password
            return newStr + newPassTransformed;
        }

        /// <summary>
        /// Method that verifies with connection with MySQL Database is possible with the parameters being used
        /// </summary>
        public void TestConnection()
        {
            /// Simple test query 
            string Command = "SELECT id FROM " + Table + ";";

            /// Use connection to DB, and when finished, dispose the MySqlConnection object
            using (MySqlConnection mConnection = new MySqlConnection(ConnStr))
            {
                /// Do connection to DB
                mConnection.Open();
                
                /// Create the SelectCommand.
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Table + " LIMIT 1;", mConnection);

                /// Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                /// Read the data until all data is read
                while (dataReader.Read()) { }

                /// Close Data Reader
                dataReader.Close();

                /// Stop connection to DB
                mConnection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="notes"></param>
        public void InsertTags(List<Tag> tags, string notes)
        {
            /// Initialize statement
            string Command = "INSERT INTO " + Table + " (id, datetime, pos_x, pos_y, notes) VALUES (@id, @timestamp, @pos_x, @pos_y, @notes);";

            /// Use connection to DB, and when finished, dispose the MySqlConnection object
            using (MySqlConnection mConnection = new MySqlConnection(ConnStr))
            {
                /// Do connection to DB
                mConnection.Open();

                /// Use transaction, and when finished, dispose the MySqlTransaction object
                using (MySqlTransaction trans = mConnection.BeginTransaction())
                {
                    /// Use the MySQL command, with the connection and transaction. When finished, dispose the MySqlCommand 
                    using (MySqlCommand myCmd = new MySqlCommand(Command, mConnection, trans))
                    {
                        myCmd.CommandType = CommandType.Text;

                        foreach (Tag t in tags)
                        {
                            myCmd.Parameters.Clear();

                            /// Apply the tag values into the parameters of the statement initialized on the string vareable "Command"
                            myCmd.Parameters.AddWithValue("@id", t.ID);
                            myCmd.Parameters.AddWithValue("@timestamp", t.TimeStampDateTime);
                            myCmd.Parameters.AddWithValue("@pos_x", t.PositionX);
                            myCmd.Parameters.AddWithValue("@pos_y", t.PositionY);
                            myCmd.Parameters.AddWithValue("@notes", notes);

                            /// Execute statement
                            myCmd.ExecuteNonQuery();
                        }

                        /// Commit changes
                        trans.Commit();
                    }
                }

                /// Stop connection to DB
                mConnection.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Framework;

namespace DAO
{
    public class BDDHandler
    {
        public void CreateFile()
        {
            SQLiteConnection.CreateFile("matador.sql");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE DrawList(id INTEGER PRIMARY KEY AUTOINCREMENT, id_game INTEGER REFERENCES Game(id), operand1 INTEGER, operand2 INTEGER, operand3 INTEGER, operand4 INTEGER, operand5 INTEGER, result INTEGER); CREATE TABLE Game(id INTEGER PRIMARY KEY AUTOINCREMENT, end DATETIME, begin DATETIME, id_gamer INTEGER REFERENCES Gamer(id)); CREATE TABLE Gamer(id INTEGER PRIMARY KEY AUTOINCREMENT, pseudo TEXT); CREATE TABLE Solution(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), solution TEXT); CREATE TABLE Stroke(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), operand1 INTEGER, operator CHAR, operand2 INTEGER)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void WriteGame(Game game, string TypeOfInsert)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();

            //TypeOfInsert = WhichCommandInsert(TypeOfInsert);
            
        }

        public List<string> WhichCommandInsert(string TypeOfInsert)
        {
            List<string> CommandInsert = new List<string>();
            string sql = "insert into highscores (name, score) values ('Me', 9001)";
            CommandInsert.Add(sql);
            return CommandInsert;
        }

        public void InsertIntoGamer(string pseudo)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Gamer (pseudo) VALUES (\"" + pseudo +"\");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public int SelectIdGamer(string pseudo)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM gamer where pseudo =\"" + pseudo + "\";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return Convert.ToInt32(reader["id"].ToString());
            }
            return 0; //pas de résultat
        }

        public void InsertIntoGame(DateTime endDate, DateTime beginDate, int idGamer)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Game (end, begin, id_gamer) VALUES (\"" + endDate + "\", \"" + beginDate+ "\", " + idGamer + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public int SelectIdGame(string pseudo)
        {
            int idGamer = SelectIdGame(pseudo);
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM game where id_gamer =\"" + idGamer + "\";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return Convert.ToInt32(reader["id"].ToString());
            }
            return 0; //pas de résultat
        }


        public void InsertIntoSolution( string solution, int idDraw)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Solution (id_draw, solution) VALUES (\"" + solution + "\", "  + idDraw + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public string SelectSolutionByIdDraw(string id_draw)
        {
            int idGamer = SelectIdGame(id_draw);
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT solution FROM SOLUTION where id_draw =\"" + id_draw + "\";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader["solution"].ToString();
            }
            return ""; //pas de résultat
        }

        public void InsertIntoDrawList(int idGame, int operand1, int operand2, int operand3, int operand4, int operand5, int result)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO DrawList (id_game, operand1, operand2,operand3,operand4,operand5,result) VALUES (" + idGame + ", " + operand1 + ", " + operand2 + ", " + operand3 + ", " + operand4 + ", " + operand5 + ", " + result + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public int SelectDrawListIdGame(int operand1, int operand2, int operand3, int operand4, int operand5, int result)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id_game FROM drawlist where operand1 =" + operand1 + " AND operand2 =" + operand2 + " AND operand3 =" + operand3 + " AND operand4 =" + operand4 + " AND operand5 =" + operand5 + " AND result =" + result + " ;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return Convert.ToInt32(reader["id_game"].ToString());
            }
            return 0; //pas de résultat
        }

        public void InsertIntoStroke(int idDraw, int operand1, char operator1, int operand2)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Stroke (id_draw,operand1,operator,operand2) VALUES (\"" + idDraw + "\", \"" + operand1 + "\", \"" + operator1 + "\", \"" + operand2 + "\");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


    }
}

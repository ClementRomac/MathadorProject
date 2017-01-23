using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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

            // string sql = "CREATE TABLE DrawList (id INTEGER PRIMARY KEY AUTOINCREMENT, id_game INTEGER REFERENCES Game (id), operand1 INTEGER, operand2 INTEGER, operand3 INTEGER, operand4 INTEGER, operand5 INTEGER, result INTEGER)";
            string sql = "CREATE TABLE DrawList(id INTEGER PRIMARY KEY AUTOINCREMENT, id_game INTEGER REFERENCES Game(id), operand1 INTEGER, operand2 INTEGER, operand3 INTEGER, operand4 INTEGER, operand5 INTEGER, result INTEGER); CREATE TABLE Game(id INTEGER PRIMARY KEY AUTOINCREMENT, end DATE, begin DATE, id_gamer INTEGER REFERENCES Gamer(id)); CREATE TABLE Gamer(id INTEGER PRIMARY KEY AUTOINCREMENT, pseduo TEXT); CREATE TABLE Solution(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), solution TEXT); CREATE TABLE Stroke(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), operand1 INTEGER, operator TEXT, operand2 INTEGER)";
            ;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            //CreateFile("Matador.sql");
            /*
            sql = "insert into highscores (name, score) values ('Me', 9001)";
            sql = "insert into highscores (name, score) values ('Me', 3000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();*/
        }

      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Framework;
using System.IO;

namespace DAO
{
    public class BDDHandler
    {
        public BDDHandler()
        {
            if (!File.Exists("matador.sql"))
            {
                CreateFile();
            }
        }
        public void CreateFile()
        {
            SQLiteConnection.CreateFile("matador.sql");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE DrawList(id INTEGER PRIMARY KEY AUTOINCREMENT, id_game INTEGER REFERENCES Game(id), operand1 INTEGER, operand2 INTEGER, operand3 INTEGER, operand4 INTEGER, operand5 INTEGER, result INTEGER); CREATE TABLE Game(id INTEGER PRIMARY KEY AUTOINCREMENT, end DATETIME, begin DATETIME, game_type INTEGER, id_gamer INTEGER REFERENCES Gamer(id)); CREATE TABLE Gamer(id INTEGER PRIMARY KEY AUTOINCREMENT, pseudo TEXT); CREATE TABLE Solution(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), solution TEXT); CREATE TABLE Stroke(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), operand1 INTEGER, operator CHAR, operand2 INTEGER)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        //Todo :
        public void WriteGame (Game game)
        {
            InsertIntoGamer(game.Pseudo);
            int id_gamer = SelectIdGamer();

            InsertIntoGame(game.FinishTime, game.BeginTime, id_gamer, (int)game.gameType);
            int id_game = SelectIdGame();

            foreach( DrawResolution drawresolution in game.Historical)
            {
                Draw currentDraw = drawresolution.Draw;
                InsertIntoDrawList(id_game,
                    currentDraw.Numbers[0],
                    currentDraw.Numbers[1],
                    currentDraw.Numbers[2],
                    currentDraw.Numbers[3],
                    currentDraw.Numbers[4],
                    currentDraw.Goal
                    );
                int idCurrentDraw = SelectIddrawList();
                foreach(Stroke stroke in drawresolution.Strokes)
                {
                    InsertIntoStroke(idCurrentDraw, stroke.FirstOperand, stroke.Operator.ToReadableChar(), stroke.SecondOperand);
            
                }
                
            }
            //insert into all 
        }

        public List<Game> GetAllGames()
        {
            List<List<string>> allGamer = new List<List<string>>();
            List<List<string>> allGame = new List<List<string>>();
            List<List<int>> allDraw = new List<List<int>>();
            List<List<string>> allStroke = new List<List<string>>();
            List<Game> getAllData = new List<Game>();
            
            allGamer = SelectAllGamer();
            foreach(List<string> gamer in allGamer)//Pour chaque user
            {
                allGame = SelectAllGame(gamer[0]);// pour chaque jeu de chaque user
                foreach(List<string> game in allGame)// pour chaque Draw de chaque jeu  de chaque user
                {
                    allDraw = SelectAllDrawResolution(game[0]);
                    Game tmpGame = new Game(gamer[1], (GameType)Convert.ToInt32(game[5]));
                    foreach (List<int> draw in allDraw)//pour tous les strokes  pour chaque Draw de chaque jeu  de chaque user
                    {
                        allStroke = SelectAllStroke(draw[0]);
                        //Création object temporaire que l'on ajoute dans la liste
                        Draw tmpDraw = new Draw(draw.GetRange(1 ,5), draw[7]  );
                        tmpGame.AddDrawResolution(tmpDraw);
                        foreach (List<string> stroke in allStroke)
                        {
                            Stroke tmpStroke = new Stroke(
                                Convert.ToInt32(stroke[2]) ,
                                Convert.ToInt32(stroke[4]),
                                stroke[3][0]
                                );
                            tmpGame.AddStroke(tmpStroke);
                        }
                    }
                    getAllData.Add(tmpGame);
                }
            }
            return getAllData;
        }

        public void InsertIntoGame(DateTime endDate, DateTime beginDate, int idGamer, int type_game)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Game (end, begin, game_type, id_gamer) VALUES (\"" + endDate + "\", \"" + beginDate + "\", " + type_game + " , " + idGamer + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            try
            {
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                SQLiteConnection.ClearAllPools();
            }
            catch(Exception ex) { }
        }

        public int SelectIdGame()
        {
            int result = 0;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM game  ORDER BY id DESC;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result= Convert.ToInt32(reader["id"].ToString());
            }
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result; //pas de résultat
        }

        public List<List<string>> SelectAllGamer()
        {
            List<List<string>> allGamer = new List<List<string>>();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM gamer;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.AddRange(new string[2] { reader["id"].ToString(), reader["pseudo"].ToString() });
                allGamer.Add(tmp);

                //return Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allGamer;
        }

        public void InsertIntoGamer(string pseudo)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Gamer (pseudo) VALUES (\"" + pseudo +"\");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
        }

        public int SelectIdGamer()
        {
            int result = 0;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM gamer ORDER BY id DESC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result =  Convert.ToInt32(reader["id"].ToString());
            }
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result; //pas de résultat
        }

        public List<List<string>> SelectAllGame(string id_gamer)
        {
            List<List<string>> allGame = new List<List<string>>();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM gamer WHERE id = " +Convert.ToInt32(id_gamer) +";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.AddRange(new string[6] { reader["id"].ToString(),
                    reader["end"].ToString(),
                    reader["begin"].ToString(),
                    reader["game_type"].ToString(),
                    reader["id_gamer"].ToString(),
                    reader["game_type"].ToString(),});
                allGame.Add(tmp);

                //return Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allGame;
        }

        public void InsertIntoSolution( string solution, int idDraw)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Solution (id_draw, solution) VALUES (\"" + solution + "\", "  + idDraw + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
        }


        public string SelectSolutionByIdDraw(string id_draw)
        {
            string result = "";
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT solution FROM SOLUTION where id_draw =\"" + id_draw + "\";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result =  reader["solution"].ToString();
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result; //pas de résultat
        }

        public void InsertIntoDrawList(int idGame, int operand1, int operand2, int operand3, int operand4, int operand5, int result)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO DrawList (id_game, operand1, operand2,operand3,operand4,operand5,result) VALUES (" + idGame + ", " + operand1 + ", " + operand2 + ", " + operand3 + ", " + operand4 + ", " + operand5 + ", " + result + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();

        }

        public int SelectIddrawList()
        {
            int result = 0;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM drawlist ORDER BY id DESC;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result =  Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result; //pas de résultat
        }

        public List<List<int>> SelectAllDrawResolution(string id_game)
        {
            List<List<int>> allDraw = new List<List<int>>();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM drawresolution WHERE id_game = " + Convert.ToInt32(id_game) + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<int> tmp = new List<int>();
                tmp.AddRange(new int[8] { Convert.ToInt32(reader["id"]),
                    Convert.ToInt32(reader["id_game"]),
                    Convert.ToInt32(reader["operand1"]),
                    Convert.ToInt32(reader["operand2"]),
                    Convert.ToInt32(reader["operand3"]),
                    Convert.ToInt32(reader["operand4"]),
                    Convert.ToInt32(reader["operand5"]),
                    Convert.ToInt32(reader["result"]) });
                allDraw.Add(tmp);

                //return Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allDraw;
        }

        public void InsertIntoStroke(int idDraw, int operand1, char operator1, int operand2)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO Stroke (id_draw,operand1,operator,operand2) VALUES (\"" + idDraw + "\", \"" + operand1 + "\", \"" + operator1 + "\", \"" + operand2 + "\");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
        }

        public List<List<string>> SelectAllStroke(int id_draw)
        {
            List<List<string>> allStroke = new List<List<string>>();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM Stroke WHERE id_draw = " + Convert.ToInt32(id_draw) + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.AddRange(new string[5] { reader["id"].ToString(),
                    reader["id_draw"].ToString(),
                    reader["operand1"].ToString(),
                    reader["operator"].ToString(),
                    reader["operand2"].ToString() });
                allStroke.Add(tmp);

                //return Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allStroke;
        }

    }
}

using System;
using System.Collections.Generic;
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
                CreateBDDFile();
            }
        }
        public void CreateBDDFile()
        {
            SQLiteConnection.CreateFile("matador.sql");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();

            string sql = "CREATE TABLE DrawList(id INTEGER PRIMARY KEY AUTOINCREMENT, id_game INTEGER REFERENCES Game(id), operand1 INTEGER, operand2 INTEGER, operand3 INTEGER, operand4 INTEGER, operand5 INTEGER, result INTEGER, points INTEGER); CREATE TABLE Game(id INTEGER PRIMARY KEY AUTOINCREMENT, end DATETIME, begin DATETIME, game_type INTEGER, id_gamer INTEGER REFERENCES Gamer(id)); CREATE TABLE Gamer(id INTEGER PRIMARY KEY AUTOINCREMENT, pseudo TEXT); CREATE TABLE Solution(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), solution TEXT); CREATE TABLE Stroke(id INTEGER PRIMARY KEY AUTOINCREMENT, id_draw INTEGER REFERENCES DrawList(id), operand1 INTEGER, operator CHAR, operand2 INTEGER)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public void WriteGame (Game game)
        {
            InsertIntoGamer(game.Pseudo);
            int id_gamer = SelectLastGamerId();

            InsertIntoGame(game.FinishTime, game.BeginTime, id_gamer, (int)game.gameType);
            int id_game = SelectLastGameId();

            foreach( DrawResolution drawresolution in game.Historical)
            {
                Draw currentDraw = drawresolution.Draw;
                InsertIntoDrawList(id_game,
                    currentDraw.Numbers[0],
                    currentDraw.Numbers[1],
                    currentDraw.Numbers[2],
                    currentDraw.Numbers[3],
                    currentDraw.Numbers[4],
                    currentDraw.Goal,
                    drawresolution.SavedCurrentPoints
                );

                int idCurrentDraw = SelectLastDrawListId();
                foreach(Stroke stroke in drawresolution.Strokes)
                {
                    InsertIntoStroke(idCurrentDraw, stroke.FirstOperand, stroke.Operator.ToReadableChar(), stroke.SecondOperand);
            
                }                
            }
        }

        public List<Game> GetAllGames()
        {
            List<List<string>> allGamers = new List<List<string>>();
            List<List<string>> allGames = new List<List<string>>();
            List<List<int>> allDraws = new List<List<int>>();
            List<List<string>> allStrokes = new List<List<string>>();
            List<Game> gamesList = new List<Game>();
            
            allGamers = SelectAllGamers();
            foreach(List<string> gamer in allGamers)//Pour chaque user
            {
                allGames = SelectAllGames(gamer[0]);// pour chaque jeu de chaque user
                foreach(List<string> game in allGames)// pour chaque Draw de chaque jeu  de chaque user
                {
                    allDraws = SelectAllDrawResolutions(game[0]);
                    Game tmpGame = new Game(gamer[1], (GameType)Convert.ToInt32(game[4]));
                    tmpGame.BeginTime = DateTime.Parse(game[2]);
                    tmpGame.FinishTime = DateTime.Parse(game[1]);

                    foreach (List<int> draw in allDraws)//pour tous les strokes  pour chaque Draw de chaque jeu  de chaque user
                    {
                        allStrokes = SelectAllStrokes(draw[0]);
                        //Création object temporaire que l'on ajoute dans la liste
                        Draw tmpDraw = new Draw(draw.GetRange(1 ,5), draw[7]  );
                        tmpGame.AddDrawResolution(tmpDraw);
                        tmpGame.SetCurrentDrawResolutionSavedPoints(draw[8]);
                        foreach (List<string> stroke in allStrokes)
                        {
                            Stroke tmpStroke = new Stroke(
                                Convert.ToInt32(stroke[2]) ,
                                Convert.ToInt32(stroke[4]),
                                stroke[3][0]
                            );

                            tmpGame.AddStroke(tmpStroke);
                        }
                    }

                    gamesList.Add(tmpGame);
                }
            }

            return gamesList;
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

        public int SelectLastGameId()
        {
            int result = 0;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM game  ORDER BY id DESC LIMIT 1;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result= Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result;
        }

        public List<List<string>> SelectAllGamers()
        {
            List<List<string>> allGamers = new List<List<string>>();
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
                allGamers.Add(tmp);
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allGamers;
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

        public int SelectLastGamerId()
        {
            int result = 0;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM gamer ORDER BY id DESC LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result =  Convert.ToInt32(reader["id"].ToString());
            }
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result;
        }

        public List<List<string>> SelectAllGames(string id_gamer)
        {
            List<List<string>> allGames = new List<List<string>>();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM game WHERE id_gamer = " +Convert.ToInt32(id_gamer) +";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<string> tmp = new List<string>();
                tmp.AddRange(new string[5] { reader["id"].ToString(),
                    reader.GetString(1),//end
                    reader.GetString(2),//begin
                    reader["id_gamer"].ToString(),
                    reader["game_type"].ToString()
                });

                allGames.Add(tmp);
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allGames;
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
            return result;
        }

        public void InsertIntoDrawList(int idGame, int operand1, int operand2, int operand3, int operand4, int operand5, int result, int points)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "INSERT INTO DrawList (id_game, operand1, operand2,operand3,operand4,operand5,result,points) VALUES (" + idGame + ", " + operand1 + ", " + operand2 + ", " + operand3 + ", " + operand4 + ", " + operand5 + ", " + result + ", " + points + ");";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();

        }

        public int SelectLastDrawListId()
        {
            int result = 0;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT id FROM drawlist ORDER BY id DESC LIMIT 1;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result =  Convert.ToInt32(reader["id"].ToString());
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return result;
        }

        public List<List<int>> SelectAllDrawResolutions(string id_game)
        {
            List<List<int>> allDraws = new List<List<int>>();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=matador.sql;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM drawList WHERE id_game = " + Convert.ToInt32(id_game) + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<int> tmp = new List<int>();
                tmp.AddRange(new int[9] { Convert.ToInt32(reader["id"]),
                    Convert.ToInt32(reader["id_game"]),
                    Convert.ToInt32(reader["operand1"]),
                    Convert.ToInt32(reader["operand2"]),
                    Convert.ToInt32(reader["operand3"]),
                    Convert.ToInt32(reader["operand4"]),
                    Convert.ToInt32(reader["operand5"]),
                    Convert.ToInt32(reader["result"]),
                    Convert.ToInt32(reader["points"])
                });

                allDraws.Add(tmp);
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allDraws;
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

        public List<List<string>> SelectAllStrokes(int id_draw)
        {
            List<List<string>> allStrokes = new List<List<string>>();
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
                    reader["operand2"].ToString()
                });

                allStrokes.Add(tmp);
            }

            m_dbConnection.Close();
            SQLiteConnection.ClearAllPools();
            return allStrokes;
        }

    }
}

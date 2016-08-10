using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using Mono.Data.Sqlite;

public class TriviaQA {

	public List<TriviaQuestion> TriviaQuestions { get; set; }

    public TriviaQA()
    {
        TriviaQuestions = new List<TriviaQuestion>();
    }
    public bool IsCorrectAnswer(int id, char guess)
    {
        TriviaQuestion q = TriviaQuestions.Where(x => x.Id == id).FirstOrDefault();
        if (q!= null && q.Answer == guess)
            return true;
        return false;
    }

    public TriviaQuestion GetRandomTriviaQuestion()
    {
        TriviaQuestion q = new TriviaQuestion() ;
        if (TriviaQuestions.Count > 0)
        {
            q = TriviaQuestions[0];
            TriviaQuestions = TriviaQuestions.Where(x => x.Id != q.Id).ToList();
        }
        return q;
    }

  

    public void GetTriviaQuestions()
    {
		string connectionString = "URI=file:" + Application.dataPath + "/TRIVIA_MAZE.sqlite";

		using (SqliteConnection connection = new SqliteConnection (connectionString)) {
			connection.Open ();

			using (SqliteCommand command = connection.CreateCommand ()) {
				command.CommandText = "SELECT * FROM QUESTIONS";

				using (SqliteDataReader reader = command.ExecuteReader ()) {
					while (reader.Read ()) {
                        TriviaQuestion q = new TriviaQuestion();
                        q.Id = int.Parse(reader["ID"].ToString());
                        q.Question = reader["QUESTION"].ToString();
                        q.Answer = char.Parse(reader["ANSWER"].ToString());
                        q.AnswerA = reader["ANS_A"].ToString();
                        q.AnswerB = reader["ANS_B"].ToString();
                        q.AnswerC = reader["ANS_C"].ToString();
                        q.AnswerD = reader["ANS_D"].ToString();
                        TriviaQuestions.Add(q);
                    }

					reader.Close ();
				}
			}

			connection.Close ();
		}
    }

    public class TriviaQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public char Answer { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }

    }
}


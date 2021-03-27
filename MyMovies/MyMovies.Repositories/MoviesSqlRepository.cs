using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyMovies.Repositories
{
    public class MoviesSqlRepository : IMoviesRepository
    {
        public void Create(Movie movie)
        {

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyMoviesSql;Trusted_Connection=True;"))
            {

                cnn.Open();

                var cmd = new SqlCommand("InsertMovie", cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageUrl);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@Description", movie.Description);

                cmd.ExecuteNonQuery();
               
            }

        }

        public List<Movie> GetAll()
        {

            var result = new List<Movie>();

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyMoviesSql;Trusted_Connection=True;"))
            {

                cnn.Open();

                var query = "select * from movies";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    var movie = new Movie();

                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.ImageUrl = reader.GetString(2);
                    movie.Duration = reader.GetInt32(3);
                    movie.Description = reader.GetString(4);

                    result.Add(movie);
                }
            }

            return result;
        }

        public Movie GetById(int id)
        {

            Movie result = null;

            using (var cnn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=MyMoviesSql;Trusted_Connection=True;"))
            {

                cnn.Open();

                var query = $"select * from movies where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = new Movie();
                    result.Id = reader.GetInt32(0);
                    result.Title = reader.GetString(1);
                    result.ImageUrl = reader.GetString(2);
                    result.Duration = reader.GetInt32(3);
                    result.Description = reader.GetString(4);

                }
            }

            return result;
        }
    }
}

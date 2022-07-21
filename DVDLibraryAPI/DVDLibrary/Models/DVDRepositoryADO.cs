using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web;
using DVDLibrary.Factory;

namespace DVDLibrary.Models
{
    public class DVDRepositoryADO : IDVDRepository
    {

        private string _connectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

        public void Create(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                SqlCommand cmd = new SqlCommand("usp_DVDCreate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DVDId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();

                cmd.ExecuteNonQuery();

                dvd.DVDId = (int)param.Value;
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("usp_DVDDelete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DVDId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("usp_DVDSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                using (SqlDataReader _dir = cmd.ExecuteReader())
                {
                    while (_dir.Read())
                    {
                        DVD currRow = new DVD();
                        currRow.DVDId = (int)_dir["DVDId"];
                        currRow.Title = _dir["Title"].ToString();
                        currRow.ReleaseYear = (int)_dir["ReleaseYear"];
                        currRow.Director = _dir["Director"].ToString();
                        currRow.Rating = _dir["Rating"].ToString();
                        currRow.Notes = _dir["Notes"].ToString();
                        dvds.Add(currRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByDirector(string director)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "usp_DVDGetByDirector"
                };

                cmd.Parameters.AddWithValue("@Director", director);

                conn.Open();
                using (SqlDataReader _dir = cmd.ExecuteReader())
                {
                    while (_dir.Read())
                    {
                        DVD dvd = new DVD {
                            DVDId = (int)_dir["DVDId"],
                            Title = _dir["Title"].ToString(),
                            ReleaseYear = (int)_dir["ReleaseYear"],
                            Director = _dir["Director"].ToString(),
                            Rating = _dir["Rating"].ToString(),
                            Notes = _dir["Notes"].ToString()
                        };
                        dvds.Add(dvd);
                    }
                }
            }
            return dvds;
        }

        public DVD GetById(int id)
        {
            DVD dvd = new DVD();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("usp_DVDSelectById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DVDId", id);
                conn.Open();
                using (SqlDataReader _dir = cmd.ExecuteReader())
                {
                    while (_dir.Read())
                    {
                        dvd.DVDId = (int)_dir["DVDId"];
                        dvd.Title = _dir["Title"].ToString();
                        dvd.ReleaseYear = (int)_dir["ReleaseYear"];
                        dvd.Director = _dir["Director"].ToString();
                        dvd.Rating = _dir["Rating"].ToString();
                        dvd.Notes = _dir["Notes"].ToString();
                    }
                }
            }
            return dvd;
        }

        public List<DVD> GetByRating(string rating)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("usp_DVDGetByRating", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rating", rating);
                conn.Open();

                using (SqlDataReader _dir = cmd.ExecuteReader())
                {
                    while (_dir.Read())
                    {
                        DVD currRow = new DVD();
                        currRow.DVDId = (int)_dir["DVDId"];
                        currRow.Title = _dir["Title"].ToString();
                        currRow.ReleaseYear = (int)_dir["ReleaseYear"];
                        currRow.Director = _dir["Director"].ToString();
                        currRow.Rating = _dir["Rating"].ToString();
                        currRow.Notes = _dir["Notes"].ToString();
                        dvds.Add(currRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByReleaseYear(int year)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("usp_DVDGetByReleaseYear", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReleaseYear", year);
                conn.Open();

                using (SqlDataReader _dir = cmd.ExecuteReader())
                {
                    while (_dir.Read())
                    {
                        DVD currRow = new DVD();
                        currRow.DVDId = (int)_dir["DVDId"];
                        currRow.Title = _dir["Title"].ToString();
                        currRow.ReleaseYear = (int)_dir["ReleaseYear"];
                        currRow.Director = _dir["Director"].ToString();
                        currRow.Rating = _dir["Rating"].ToString();
                        currRow.Notes = _dir["Notes"].ToString();
                        dvds.Add(currRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByTitle(string title)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                SqlCommand cmd = new SqlCommand("usp_DVDGetByTitle", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);
                conn.Open();

                using (SqlDataReader _dir = cmd.ExecuteReader())
                {
                    while (_dir.Read())
                    {
                        DVD currRow = new DVD();
                        currRow.DVDId = (int)_dir["DVDId"];
                        currRow.Title = _dir["Title"].ToString();
                        currRow.ReleaseYear = (int)_dir["ReleaseYear"];
                        currRow.Director = _dir["Director"].ToString();
                        currRow.Rating = _dir["Rating"].ToString();
                        currRow.Notes = _dir["Notes"].ToString();
                        dvds.Add(currRow);
                    }
                }
            }
            return dvds;
        }

        public void Update(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                SqlCommand cmd = new SqlCommand("usp_DVDUpdate", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
        //    public List<DVD> GetAllDvds()
        //    {
        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = _connectionString;
        //            return conn.Query<DVD>("usp_DVDSelectAll", commandType: CommandType.StoredProcedure);
        //        }
        //    }
        //    public IEnumerable<DVD> GetRatings()
        //    {
        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = _connectionString;

        //            return conn.Query<DVD>("RatingSelectAll", commandType: CommandType.StoredProcedure);
        //        }
        //    }

        //    public DVD GetDVDById(int dvdId)
        //    {
        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = _connectionString;

        //            DynamicParameters parameters = new DynamicParameters();
        //            parameters.Add("@DVDId", dvdId);
        //            return conn.Query<DVD>("DVDSelectById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

        //        }
        //    }
        //public void DVDDelete(int id)
        //{
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = _connectionString;

        //        // create parameter object
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@DVDId", id);

        //        conn.Execute("DVDDelete", parameters, commandType: CommandType.StoredProcedure);
        //    }
        //}

        //    public void DVDInsert(DVD dvd)
        //    {
        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = _connectionString;

        //            // create parameter object
        //            DynamicParameters parameters = new DynamicParameters();

        //            // declare output parameter
        //            parameters.Add("@DVDId", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //            parameters.Add("@Title", dvd.Title);
        //            parameters.Add("@Director", dvd.Director);
        //            parameters.Add("@ReleaseDate", dvd.ReleaseDate);
        //            parameters.Add("@Rating", dvd.Rating);

        //            conn.Execute("DVDInsert", parameters, commandType: CommandType.StoredProcedure);

        //            dvd.DVDId = parameters.Get<int>("@DVDId");
        //        }
        //    }
        //    public void DVDEdit(DVD dvd)
        //    {
        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = _connectionString;

        //            // create parameter object
        //            DynamicParameters parameters = new DynamicParameters();

        //            // declare output parameter
        //            parameters.Add("@DVDId", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //            parameters.Add("@Title", dvd.Title);
        //            parameters.Add("@Director", dvd.Director);
        //            parameters.Add("@ReleaseDate", dvd.ReleaseDate);
        //            parameters.Add("@Rating", dvd.Rating);

        //            conn.Execute("DVDUpdate", parameters, commandType: CommandType.StoredProcedure);
        //        }
        //    }

        //}
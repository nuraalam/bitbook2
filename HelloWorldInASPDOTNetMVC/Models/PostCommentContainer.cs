using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelloWorldInASPDOTNetMVC.Models
{
    public class PostCommentContainer
    {
        public void SavePost(PostComment aPost)
        {
            string connectionStrings = @"Server=BITM-401-PC21\SQLEXPRESS;Database=UniversityDB;Integrated security=True";
            SqlConnection aConnection = new SqlConnection(connectionStrings);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("Insert INTO Table_Comment values('" + aPost.PostDate + "','" + aPost.Message + "','"+aPost.PostId+"')", aConnection);
            aCommand.ExecuteNonQuery();
            aConnection.Close();
        }


        public List<PostComment> GetAllPost(Post post)
        {
            List<PostComment> Posts = new List<PostComment>();

            string connectionStrings = @"Server=BITM-401-PC21\SQLEXPRESS;Database=UniversityDB;Integrated security=True";
            SqlConnection aConnection = new SqlConnection(connectionStrings);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("SELECT*FROM Table_Comment WHERE PostId="+post.PostId, aConnection);
            SqlDataReader reader = aCommand.ExecuteReader();

            while (reader.Read())
            {
                PostComment aPost = new PostComment();
                aPost.PostDate = Convert.ToDateTime(reader[0]);
                aPost.Message = reader[1].ToString();
                Posts.Add(aPost);
            }


            aConnection.Close();

            return Posts;
        }
    }
}
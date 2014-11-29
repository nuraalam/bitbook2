using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HelloWorldInASPDOTNetMVC.Controllers;
using Microsoft.Ajax.Utilities;

namespace HelloWorldInASPDOTNetMVC.Models
{
    public class PostContainer
    {
        public void SavePost(Post aPost)
        {
            string connectionStrings = @"Server=BITM-401-PC21\SQLEXPRESS;Database=UniversityDB;Integrated security=True";
            SqlConnection aConnection = new SqlConnection(connectionStrings);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("Insert INTO Table_Post values('"+aPost.PostDate+"','" + aPost.Message + "')", aConnection);
            aCommand.ExecuteNonQuery();
            aConnection.Close();
        }


        public IEnumerable<Post> GetAllPost()
        {
            // PostCommentContainer _aPostCommentContainer = new PostCommentContainer();
            HomeController aController=new HomeController();
            List<Post> Posts = new List<Post>();

            string connectionStrings = @"Server=BITM-401-PC21\SQLEXPRESS;Database=UniversityDB;Integrated security=True";
            SqlConnection aConnection = new SqlConnection(connectionStrings);
            aConnection.Open();
            SqlCommand aCommand = new SqlCommand("SELECT*FROM Table_Post", aConnection);
            SqlDataReader reader = aCommand.ExecuteReader();

            while (reader.Read())
            {
                Post aPost=new Post();
                aPost.PostDate = Convert.ToDateTime(reader[0]); 
                aPost.Message = reader[1].ToString();
                aPost.PostId = (int) reader[2];
                aPost.APostComment=aController.AddPostComment(aPost.PostId);
                Posts.Add(aPost);
            }


            aConnection.Close();

            return Posts;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HelloWorldInASPDOTNetMVC.Models;

namespace HelloWorldInASPDOTNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private StudentContainer _aStudentContainer = new StudentContainer();
        private PostContainer _aPostContainer = new PostContainer();
        private PostCommentContainer _aPostCommentContainer = new PostCommentContainer();

        private int i = 0;
        //public ActionResult GetPost()
        //{
        //    List<Post> posts = _aPostContainer.GetAllPost();
        //    var queryLondonCustomers3 =
        //        from cust in posts
                
        //        orderby cust.PostDate descending 
        //        select cust;
        //    List<Post> newList=new List<Post>();
           
            
        //    return View(queryLondonCustomers3);
        //}

        [HttpGet]
        public ActionResult AddPost()
        {
            IEnumerable<Post> posts = _aPostContainer.GetAllPost();

            var queryLondonCustomers3 =
                from cust in posts

                orderby cust.PostDate descending
                select cust;
            

            return View(queryLondonCustomers3);
        }

        [HttpPost]
        public ActionResult AddPost(Post aPost)
        {
           
            aPost.PostDate = DateTime.UtcNow;
            _aPostContainer.SavePost(aPost);
            return RedirectToAction("AddPost");
        }



        [HttpGet]
        public IEnumerable<PostComment> AddPostComment(int? postId)
        {
            Post aPost=new Post();
            if (postId != null)
            {
             
                aPost.PostId = (int) postId;
            }

            List<PostComment> posts = _aPostCommentContainer.GetAllPost(aPost);
            var queryLondonCustomers3 =
                from cust in posts

                orderby cust.PostDate ascending 
                select cust;
           // List<PostComment> newList = new List<PostComment>();

            return queryLondonCustomers3;
        }

        [HttpPost]
        public ActionResult AddPostComment(PostComment aPost)
        {
            aPost.PostDate = DateTime.UtcNow;
         
            _aPostCommentContainer.SavePost(aPost);
            return RedirectToAction("AddPost");
        }












        public ActionResult St(Student aStudent)
        {
           
            return View(aStudent);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student aStudent)
        {
            aStudent.PostedDate = DateTime.Now;
            try
            {
                _aStudentContainer.SaveStudent(aStudent);
            }
            catch (Exception)
            {

                ViewBag.NameExit = "Name already exit";
                return View();
            }
                


            return RedirectToAction("SeeStudent");
        }
        public ActionResult SeeStudent()
        {
            return View(_aStudentContainer.GetStudents());
        }



        public string Index(int? n)
        {
            return ""+n;
        }

        public string M1(int? a)
        {
            int? b = null;
            return "Your name: " + a;
        }

        public string M1(string name)
        {
            int? b = null;
            return "Your name: " + name;
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}
using BookManagementSystem.Core.Modal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookManagementSystem.Web.Controllers
{
    public class BookController : Controller
    {

        #region Login
        [HttpPost]
        public ActionResult LoginCheck(AdminLogin login)
        
        {
            if (login != null)
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:44635/api/bookApi/LoginCheck");

                //HTTP POST
                var postTask = client.PostAsJsonAsync(client.BaseAddress, login);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("UserName", login.Username);

                    TempData["LoginAlert"] = "Login Successfully";

                    return RedirectToAction("BookDetailList");
                }
            }
            TempData["LoginAlert"] = "Invalid Account";
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        #region Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                HttpContext.Session.Remove("UserName");
                TempData["LogoutAlert"] = "Logout Successfully ";
            }
            return RedirectToAction("Login");
        }
        #endregion


        #endregion

        #region All Book Detail List [Get Logic]
        [HttpGet]
        public ActionResult BookDetailList()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                IEnumerable<BookDetails> Books = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:44635/api/BookApi/BookDetailList");
                //HTTP GET
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookDetails>>();
                    readTask.Wait();

                    Books = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Books = Enumerable.Empty<BookDetails>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }


            }
            return View(Books);
        }
            return RedirectToAction("Login");
        }
        #endregion

        #region Insert book details [Post] [Save Logic For Both Add And Edit]
        public ActionResult AddBookDetails(BookDetails book)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
 
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:44635/api/bookApi/InsertBookDetails");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync(client.BaseAddress, book);
                        postTask.Wait();

                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("BookDetailList");
                        }
                    return View("AddEdit");
                }    
            }
            return RedirectToAction("Login");
        }

        #endregion

        #region AddEdit [Get Logic] [View Page]
      
        public ActionResult AddEdit(int bookId)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                if (bookId > 0)
                {
                    using var client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:44635/api/BookApi/");
                    //HTTP GET
                    var responseTask = client.GetAsync("GetBookById?bookId=" + bookId);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<BookDetails>();
                        readTask.Wait();

                        BookDetails book = readTask.Result;
                        return View(book);
                    }

                }
                else
                {
                    using var client = new HttpClient();

                    client.BaseAddress = new Uri("http://localhost:44635/api/BookApi/GetAuthorName");
                    //HTTP GET
                    var responseTask = client.GetAsync(client.BaseAddress);
                    responseTask.Wait();

                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var responseData = result.Content.ReadAsStringAsync().Result;
                        IList<AuthorDetails> authors = JsonConvert.DeserializeObject<List<AuthorDetails>>(responseData);
                        BookDetails book = new()
                        {
                            AuthorList = authors
                        };
                        return View(book);
                    }
                }
            }
            return RedirectToAction("Login");
        }

        #endregion

        #region Delete Book Details
        public ActionResult DeleteBookDetails(int BookId)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44635/api/BookApi/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("DeleteBook?BookId=" + BookId);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("BookDetailList");
                }
            }

            return RedirectToAction("BookDetailList");
        }
            return RedirectToAction("Login");
        }
        #endregion
        
    }

}

#region Edit Comment
//public ActionResult EditBookDetails(int bookId)
//{
//    if (HttpContext.Session.GetString("UserName") != null)
//    {
//        //if (bookId > 0)
//        //{
//        //    BookDetails book = null;

//        //    using (var client = new HttpClient())
//        //    {
//        //        client.BaseAddress = new Uri("http://localhost:44635/api/BookApi/");
//        //        //HTTP GET
//        //        var responseTask = client.GetAsync("GetBookById?bookId=" + bookId);
//        //        responseTask.Wait();

//        //        var result = responseTask.Result;
//        //        if (result.IsSuccessStatusCode)
//        //        {
//        //            var readTask = result.Content.ReadAsAsync<BookDetails>();
//        //            readTask.Wait();

//        //            book = readTask.Result;
//        //        }
//        //    }

//        //    return View("AddEdit", book);
//        //}
//    }

//    return RedirectToAction("Login");
//}
#endregion
#region Name commented
//public ActionResult GetAuthorName()
//{
//    if (HttpContext.Session.GetString("UserName") != null)
//    {
//        IEnumerable<AuthorDetails> names = null;

//        using (var client = new HttpClient())
//        {

//            client.BaseAddress = new Uri("http://localhost:44635/api/BookApi/GetAuthorName");
//            //HTTP GET
//            var responseTask = client.GetAsync(client.BaseAddress);
//            responseTask.Wait();

//            var result = responseTask.Result;

//            if (result.IsSuccessStatusCode)
//            {
//                var readTask = result.Content.ReadAsAsync<IList<AuthorDetails>>();
//                readTask.Wait();

//                names = readTask.Result;
//            }
//            else
//            {

//                names = Enumerable.Empty<AuthorDetails>();

//                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//            }
//            ViewBag.author = new SelectList(names, "AuthorId", "BookAuthor");

//        }
//        return View();
//    }
//    return View("Login");
//}
#endregion

#region Commented

//using (var client = new HttpClient())
//{
//    client.BaseAddress = new Uri("http://localhost:44635/api/bookApi/UpdateBookDetails");

//    //HTTP POST
//    var putTask = client.PutAsJsonAsync<BookDetails>(client.BaseAddress, book);
//    putTask.Wait();

//    var result = putTask.Result;
//    if (result.IsSuccessStatusCode)
//    {

//        return RedirectToAction("BookDetailList");
//    }
//}
//return View(book);


//    if (book.BookId == 0)
//{
//    using (var client = new HttpClient())
//    {
//        client.BaseAddress = new Uri("http://localhost:44635/api/bookApi/InsertBookDetails");

//        //HTTP POST
//        var postTask = client.PostAsJsonAsync(client.BaseAddress, book);
//        postTask.Wait();

//        var result = postTask.Result;

//        if (result.IsSuccessStatusCode)
//        {
//            return RedirectToAction("BookDetailList");
//        }
//    }

//    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

//    return View(book);
//}















//catch (DataException)
//{
//    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
//}
#endregion
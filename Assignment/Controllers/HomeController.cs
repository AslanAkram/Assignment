
using Assignment.ViewModels;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

using System.Net.Mail;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Text;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
    

        public HomeController()
        {
        }


        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

  

        //public ActionResult ShareToFacebook()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ShareToFacebook(Upload_Images imageupload, HttpPostedFileBase fileUploader)
        //{

         
        //    if (Request.Files.Count > 0)
        //    {

        //        HttpPostedFileBase file = Request.Files[0];
        //        if (file.ContentLength > 0)
        //        {

        //            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        //            string extension = Path.GetExtension(file.FileName);
         
        //            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
        //            file.SaveAs(Path.Combine(Server.MapPath("/image/"), fileName));
        //            imageupload.Upload = "/image/" + fileName;

        //        }
        //    }

        
        //        var postValues = new Dictionary<string, string>();

        //        // list of available parameters available @ http://developers.facebook.com/docs/reference/api/post
        //        postValues.Add("access_token", "EAADHxrKOxG4BAEf4RTvMx3M3J5ZCZBsG53A5SH65dihoiuQO1ii5PMQVS5HnKmcDBQU5UerFrUpoZBNLDU1JHwXmG6iDuGzZA3QpDPdUqSsJJtQA9ARZBO7Dhc7RXjmQGUsrVvFIxV1GZCKGmZA5oCdJhPYPm5FCF3AQor6jU6k0SZCEtTGvHzxPfgVkMFRwRLcFsKDYhTshDJGopP6tygXj");
        //    postValues.Add("url", "https://source.unsplash.com/1600x900");
        //    ////postValues.Add("message", imageupload.Message);
     
 
       
        //    string facebookWallMsgId = string.Empty;
        //        string response;
        //        MethodResult header = Helping.SubmitPost(string.Format("https://graph.facebook.com/me/photos"),
        //                                                    Helping.BuildPostString(postValues),
        //                                                    out response);

        //        if (header.returnCode == MethodResult.ReturnCode.Success)
        //        {
        //            var deserialised =
        //                Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
        //            facebookWallMsgId = deserialised["id"];
      
        //        ViewBag.Message = "File upload successfully!";
        //        }


        //        return View();
        //}

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
  
        [HttpPost]
        public ActionResult Index(Upload_Images imageupload, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                
                var GetValue= UserManager.FindById(User.Identity.GetUserId());

                string from = "aslan.akram9@gmail.com";  
                using (MailMessage mail = new MailMessage("aslan.akram9@gmail.com", GetValue.Email))
                {
                    mail.Subject = imageupload.Title;
                    mail.Body = imageupload.Message;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential = new NetworkCredential(from, "Admin@123");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Image = "File Successfully Upload on Social Media";
                  
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

  
    }
}
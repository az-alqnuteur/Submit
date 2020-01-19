using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Test_code_frest.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Threading.Tasks;


namespace Test_code_frest.Controllers
{
    public class UsersController : Controller
    {
        

        private UsersDBcontect db = new UsersDBcontect();
        // GET: Users
        public ActionResult Index(string Serching)
        {

           // List<Users> users = db.Users.ToList<Users>();
            return View(db.Users.Where(x => x.UserNamr.Contains(Serching) || x.UserEmail.Contains(Serching) || Serching == null).ToList());
        }



       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(Users users)
        {

            var isUserExistt = db.Users.SingleOrDefault(u => u.UserNamr == users.UserNamr && u.UserPass == users.UserPass);

            if (isUserExistt != null)
            {
                Session["Id"] = db.Users.Where(u => u.UserNamr == users.UserNamr).Single().Id;


                return RedirectToAction("UserProfile", new { id = isUserExistt.Id });
                

            }
            else
            {
                ViewBag.Fail = "invalid";
                return View();
            }

        }





        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Users users)
        {
            db.Users.Add(users);
            db.SaveChanges();
            return RedirectToAction("Login");
        }





        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
       


        [HttpPost]
        public ActionResult Edit(Users users)
        {
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult Delete(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        







        [HttpGet]
        public ActionResult RestPassword()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RestPassword(ResetPassword  resetPassword)
        {
            int uid = Convert.ToInt32(Session["Id"]);
            Users UserIndDb = db.Users.Single(e => e.Id == uid);

            if (UserIndDb.UserPass == resetPassword.CurrentPassword && resetPassword.NewPassword.Length >= 8)
            {

                UserIndDb.UserPass = resetPassword.NewPassword;

                db.SaveChanges();



                Session["message"] = "successfully new pass  ";
                
            }
            else
            {
                Session["message"] = "invalid";
            }
            return RedirectToAction("UserProfile", new { id = UserIndDb.Id });
        }


        
        [HttpGet]
        public ActionResult Details(int id  )
        {
            
             Users users = db.Users.Find(id);
            
            return View(users);
        }



        public ActionResult Forgetpassword()
        {
          
            return View();
        }





        public int GenerateRandomNoForUser()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();

            return _rdm.Next(_min, _max);
        }






        [HttpPost]
        public ActionResult SendCodeByEmail(EmailResetPassword emailResetPassword)
        {

            var UserInDb = db.Users.SingleOrDefault(r => r.UserEmail == emailResetPassword.Email_To_Recover);

            if(UserInDb !=null)
            {
                var RanNum = GenerateRandomNoForUser();

                TapleReseetpassword tapleReseetpassword = new TapleReseetpassword();


                tapleReseetpassword.UserId = UserInDb.Id;

                tapleReseetpassword.Code_send = RanNum.ToString();
                    

                      db.TapleReseetpassword.Add(tapleReseetpassword);

                      db.SaveChanges();


                      //send email 

                      
                

                

                MailMessage mailMessage = new MailMessage("azoz141415@gmail.com", emailResetPassword.Email_To_Recover);
                mailMessage.Subject = "رمز تغير كلمة مرور  ";
                mailMessage.Body = RanNum + ": رمز التفعيل";
                mailMessage.IsBodyHtml = false;



                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("azoz141415@gmail.com", "Password");
                client.UseDefaultCredentials = true;
                client.Credentials = nc;
                client.Send(mailMessage);

               


                return View();

            }
            else
            {
                ViewBag.Message = "invalid";
            }

            
            
                
               return View();

            
        }









        [HttpGet]
        public ActionResult UserProfile(int id)
        {


            int uid = Convert.ToInt32(Session["Id"]);
            Users UserIndDb = db.Users.Single(e => e.Id == uid);            
            Users users = db.Users.Find(id);

            return View(users);


        }
        public ActionResult Users(string Serching)
        {

            // List<Users> users = db.Users.ToList<Users>();
            return View(db.Users.Where(x => x.UserNamr.Contains(Serching) || x.UserEmail.Contains(Serching) || Serching == null).ToList());
        }




    }
}
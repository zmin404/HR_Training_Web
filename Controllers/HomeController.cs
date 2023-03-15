using HR_Training.Models;
using HR_Training.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using System.Web.Mvc;

namespace HR_Training.Controllers
{
    public class HomeController : Controller
    {
        HRRTEntities db = new HRRTEntities();

        [HttpGet]
        public ActionResult Index()
        {
            if (TempData["ExpiredMsg"] != null && TempData["ContactUsMsg"] != null)
            {
                ViewData["ExpiredMsg"] = TempData["ExpiredMsg"];
                ViewData["ContactUsMsg"] = TempData["ContactUsMsg"];
            }

            return View();
        }

        // Employee Login (Get)
        public ActionResult EmployeeLogin()
        {
            return View();
        }


        // Employee Login (Post)
        //[HttpPost]
        //public ActionResult EmployeeLogin(tbl_UserEmployee userEmployee)
        //{

        //    string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //    if (string.IsNullOrEmpty(ipAddress))
        //    {
        //        ipAddress = Request.ServerVariables["REMOTE_ADDR"];
        //    }
        //    ViewBag.IPAddress = ipAddress;

        //    //IPHostEntry iphostInfo = Dns.GetHostEntry(Dns.GetHostName());
        //    //string ipAddress = Convert.ToString(iphostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork));

        //    string password = HashPassword(userEmployee.Password);


        //    tbl_UserEmployee employee = db.tbl_UserEmployee.Where(x => x.IsActive == true && x.UserName.ToUpper() == userEmployee.UserName.ToUpper() && x.Password == password).FirstOrDefault();
        //    if (employee == null)
        //    {
        //        ViewBag.msg = "Invaid Email or Password";
        //    }
        //    else
        //    {
        //        if(employee.IPAddress == ipAddress)
        //        {
        //            Session["employee_id"] = employee.EmployeeID;
        //            Session.Timeout = 300;
        //            return RedirectToAction("Courses");
        //        }
        //        else
        //        {
        //            ViewBag.msg = "Invaid IP Address";
        //        }

        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult EmployeeLogin(tbl_UserEmployee userEmployee)
        {
            if (userEmployee.Password != null)
            {
                string ipAddress = GetIp();
                string password = HashPassword(userEmployee.Password);
                tbl_UserEmployee employee = db.tbl_UserEmployee.Where(x => x.IsActive == true && x.UserName.ToUpper() == userEmployee.UserName.ToUpper() && x.Password == password).FirstOrDefault();

                if (employee == null)
                {
                    ViewBag.msg = "Invaid Email or Password";
                }
                else
                {
                    if(employee.IPAddress == null || employee.IPAddress =="null" || employee.IPAddress.Equals(""))
                    {
                        tbl_Employee emp = db.tbl_Employee.Where(x => x.Id == employee.EmployeeID).FirstOrDefault();
                        tbl_Bill bill = db.tbl_Bill.Where(x => x.CompanyID == emp.CompanyID).OrderByDescending(x => x.Id).FirstOrDefault();

                        if (DateTime.Now >= bill.EndDateTime.AddDays(-14))
                        {
                            if (DateTime.Now >= bill.EndDateTime.AddDays(-7))
                            {
                                if (DateTime.Now >= bill.EndDateTime.AddDays(-3))
                                {
                                    if (DateTime.Now >= bill.EndDateTime.AddDays(-2))
                                    {
                                        if (DateTime.Now >= bill.EndDateTime.AddDays(-1))
                                        {
                                            if (DateTime.Now >= bill.EndDateTime)
                                            {
                                                TempData["ExpiredMsg"] = "The subscription has expired!";
                                                TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                                TempData.Keep();
                                                return RedirectToAction("Index");
                                            }
                                            else
                                            {
                                                TempData["ExpiredMsg"] = "The subscription will expire in a day!";
                                                TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                            }
                                        }
                                        else
                                        {
                                            TempData["ExpiredMsg"] = "The subscription will expire in the next two days!";
                                            TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                        }
                                    }
                                    else
                                    {
                                        TempData["ExpiredMsg"] = "The subscription will expire in the next three days!";
                                        TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                    }
                                }
                                else
                                {
                                    TempData["ExpiredMsg"] = "The subscription will expire in a week!";
                                    TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                }
                            }
                            else
                            {
                                TempData["ExpiredMsg"] = "The subscription will expire in the next two weeks!";
                                TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                            }
                            TempData.Keep();
                            Session["employee_id"] = employee.EmployeeID;
                            Session.Timeout = 300;
                            return RedirectToAction("Courses");
                        }
                        else
                        {
                            Session["employee_id"] = employee.EmployeeID;
                            Session.Timeout = 300;
                            return RedirectToAction("Courses");
                        }
                    }
                    else
                    {
                        if (employee.IPAddress == ipAddress)
                        {
                            tbl_Employee emp = db.tbl_Employee.Where(x => x.Id == employee.EmployeeID).FirstOrDefault();
                            tbl_Bill bill = db.tbl_Bill.Where(x => x.CompanyID == emp.CompanyID).OrderByDescending(x => x.Id).FirstOrDefault();

                            if (DateTime.Now >= bill.EndDateTime.AddDays(-14))
                            {
                                if (DateTime.Now >= bill.EndDateTime.AddDays(-7))
                                {
                                    if (DateTime.Now >= bill.EndDateTime.AddDays(-3))
                                    {
                                        if (DateTime.Now >= bill.EndDateTime.AddDays(-2))
                                        {
                                            if (DateTime.Now >= bill.EndDateTime.AddDays(-1))
                                            {
                                                if (DateTime.Now >= bill.EndDateTime)
                                                {
                                                    TempData["ExpiredMsg"] = "The subscription has expired!";
                                                    TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                                    TempData.Keep();
                                                    return RedirectToAction("Index");
                                                }
                                                else
                                                {
                                                    TempData["ExpiredMsg"] = "The subscription will expire in a day!";
                                                    TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                                }
                                            }
                                            else
                                            {
                                                TempData["ExpiredMsg"] = "The subscription will expire in the next two days!";
                                                TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                            }
                                        }
                                        else
                                        {
                                            TempData["ExpiredMsg"] = "The subscription will expire in the next three days!";
                                            TempData["ContactUsMsg"] = "Please contact us for new subscription.";
                                        }
                                    }
                                    else
                                    {
                                        TempData["ExpiredMsg"] = "The subscription will expire in a week!";
                                        TempData["ContactUsMsg"] = "Please contact us for new subscription.";

                                    }
                                }
                                else
                                {
                                    TempData["ExpiredMsg"] = "The subscription will expire in the next two weeks!";
                                    TempData["ContactUsMsg"] = "Please contact us for new subscription.";

                                }
                                TempData.Keep();
                                Session["employee_id"] = employee.EmployeeID;
                                Session.Timeout = 300;
                                return RedirectToAction("Courses");
                            }
                            else
                            {
                                Session["employee_id"] = employee.EmployeeID;
                                Session.Timeout = 300;
                                return RedirectToAction("Courses");
                            }
                        }
                        else
                        {
                            ViewBag.msg = "Invaid IP Address";
                            //ViewBag.ip = ipAddress;
                        }
                    }
                }
            }
            else
            {
                ViewBag.msg = "Invaid Email or Password";
            }
            return View();
        }

        // Courses Form Clicked (Get)
        [HttpGet]
        public ActionResult Courses()
        {

            if (Session["employee_id"] == null)
            {

                return RedirectToAction("EmployeeLogin");
            }
            if (TempData["ExpiredMsg"] != null)
            {
                ViewData["ExpiredMsg"] = TempData["ExpiredMsg"];
                ViewData["ContactUsMsg"] = TempData["ContactUsMsg"];
            }
            int employeeID = Convert.ToInt32(Session["employee_id"].ToString());
            List<tbl_EmployeeCourse> li = db.tbl_EmployeeCourse.Where(x => x.EmployeeID == employeeID).OrderByDescending(x => x.EmployeeCourseID).ToList();
            List<tbl_Course> courseList = new List<tbl_Course>();
            List<tbl_Course> finishedCourseList = new List<tbl_Course>();
            tbl_Course c = new tbl_Course();

            // Define Current Course List and Finished Course List
            foreach (var item in li)
            {

                c = db.tbl_Course.Where(x => x.Id == item.CourseID).OrderByDescending(x => x.Id).SingleOrDefault();
                if (c != null)
                {
                    tbl_CourseLog log = db.tbl_CourseLog.Where(x => x.CourseID == c.Id && x.EmployeeID == employeeID).FirstOrDefault();
                    if (log == null)
                    {
                        courseList.Add(c);
                    }
                    else
                    {
                        finishedCourseList.Add(c);
                    }

                }


            }
            if (courseList.Count == 0)
            {
                ViewData["AllFinished"] = "Congratulation!";

            }
            // Current Course List
            ViewData["list"] = courseList;

            //Finished Course List
            ViewData["finishedCourseList"] = finishedCourseList;

            if (TempData["TopicID"] != null && TempData["CourseID"] != null)
            {
                int topicID = Convert.ToInt32(TempData["TopicID"]);
                int courseID = Convert.ToInt32(TempData["CourseID"]);
                int storyID = Convert.ToInt32(TempData["StoryID"]);

                tbl_Topic tp = db.tbl_Topic.Where(x => x.Id == topicID).FirstOrDefault();


                tbl_Topic topic = db.tbl_Topic.Where(x => x.Id == topicID).FirstOrDefault();
                tbl_Course course = db.tbl_Course.Where(x => x.Id == courseID).FirstOrDefault();


                ViewData["QuestionMsg"] = TempData["QuestionMsg"];
                ViewData["Result"] = TempData["Result"];
                ViewData["CourseFinishedResult"] = TempData["CourseFinishedResult"];
                ViewData["AllFinished"] = TempData["AllFinished"];
                ViewData["TopicTitle"] = topic.Title;
                ViewData["CourseTitle"] = course.Title;

                ViewData["Topic"] = tp.Title;
                ViewData["Description"] = tp.Description;

                ViewData["TopicID"] = topicID;
                ViewData["CourseID"] = courseID;

                ViewData["Reason"] = TempData["SelectedAns"];
                //tbl_ProgressTransaction pt = db.tbl_ProgressTransaction.Where(x => x.EmployeeID == employeeID && x.CourseID == courseID && x.TopicID == topicID && x.StoryID == storyID).FirstOrDefault();
                //if(pt!= null)
                //{
                //    tbl_Question question = db.tbl_Question.Where(x => x.ID == pt.QuestionID).FirstOrDefault();
                //    ViewData["Reason"] = question.Answer;
                //}

            }
            return View();
        }

        // Course items Clicked (Get), Parameter( id == Clicked Course ID (For Only Course ID), topicID == Clicked Topic ID, courseID == CLicked Course ID) 
        [HttpGet]
        public ActionResult TopicAndDescription(int? id, int? topicID, int? courseID)
        {

            if (Session["employee_id"] == null)
            {
                return RedirectToAction("EmployeeLogin");
            }
            int employeeID = Convert.ToInt32(Session["employee_id"].ToString());
            List<tbl_EmployeeCourse> li = db.tbl_EmployeeCourse.Where(x => x.EmployeeID == employeeID).OrderByDescending(x => x.EmployeeCourseID).ToList();
            List<tbl_Course> courseList = new List<tbl_Course>();
            List<tbl_Course> finishedCourseList = new List<tbl_Course>();
            tbl_Course c = new tbl_Course();

            //Define Current Course List and Finished COurse List
            foreach (var item in li)
            {

                c = db.tbl_Course.Where(x => x.Id == item.CourseID).OrderByDescending(x => x.Id).SingleOrDefault();
                if (c != null)
                {
                    tbl_CourseLog log = db.tbl_CourseLog.Where(x => x.CourseID == c.Id && x.EmployeeID == employeeID).FirstOrDefault();
                    if (log == null)
                    {
                        courseList.Add(c);
                    }
                    else
                    {
                        finishedCourseList.Add(c);
                    }
                }


            }


            tbl_CourseLog successLog = db.tbl_CourseLog.Where(x => x.CourseID == id && x.EmployeeID == employeeID).FirstOrDefault();
            if (successLog != null)
            {
                tbl_Course course = db.tbl_Course.Where(x => x.Id == id).FirstOrDefault();
                ViewData["CourseTitle"] = course.Title.ToString();

            }

            //Current Course List
            ViewData["CourseList"] = courseList;

            //Finished COurse List
            ViewData["finishedCourseList"] = finishedCourseList;

            List<tbl_Topic> topicList = new List<tbl_Topic>();
            List<tbl_Topic> finishedTopicList = new List<tbl_Topic>();
            tbl_Topic topic = new tbl_Topic();
            var s = from p in db.tbl_CourseTopicStory
                    group p by p.TopicId into g
                    where g.FirstOrDefault().CourseId == id
                    select new IntVO
                    {
                        TopicID = g.FirstOrDefault().TopicId,
                    };
            List<IntVO> intVO = s.ToList();

            foreach (var item2 in intVO)
            {
                topic = db.tbl_Topic.Where(x => x.Id == item2.TopicID).OrderByDescending(x => x.Id).SingleOrDefault();
                if (topic != null)
                {
                    tbl_CourseTopicLog log = db.tbl_CourseTopicLog.Where(x => x.TopicID == topic.Id && x.EmployeeID == employeeID).FirstOrDefault();
                    if (log == null)
                    {
                        topicList.Add(topic);
                    }
                    else
                    {
                        finishedTopicList.Add(topic);
                    }
                }
            }
            if (topicList.Count == 0)
            {
                tbl_CourseLog tempLog = db.tbl_CourseLog.Where(x => x.CourseID == id && x.EmployeeID == employeeID).FirstOrDefault();
                if(id != 0 && id != null)
                {
                    if (tempLog == null)
                    {
                        SaveCourseLog(Convert.ToInt32(id), employeeID);
                    }
                }

            }
            ViewData["TopicList"] = topicList;
            ViewData["finishedTopicList"] = finishedTopicList;
            ViewData["CourseID"] = id;


            List<tbl_CourseTopicStory> ctsList = db.tbl_CourseTopicStory.Where(x => x.TopicId == topicID && x.CourseId == courseID).ToList();
            Queue<tbl_CourseTopicStory> queue = new Queue<tbl_CourseTopicStory>();

            foreach (tbl_CourseTopicStory a in ctsList)
            {

                queue.Enqueue(a);
            }
            TempData["TopicID"] = topicID;
            TempData["CourseID"] = courseID;
            TempData["ctsData"] = queue;
            TempData.Keep();

            if (ctsList.Count == 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("QuestionStart");
            }

        }

        [HttpGet]
        public ActionResult QuestionStart()
        {

            if (Session["employee_id"] == null)
            {
                return RedirectToAction("EmployeeLogin");
            }
            if (TempData["ctsData"] == null)
            {
                return RedirectToAction("Courses");
            }
            TempData.Keep();
            Session["StartDateTime"] = DateTime.Now;
            int employeeID = Convert.ToInt32(Session["employee_id"]);

            tbl_CourseTopicStory q = null;
            if (TempData["ctsData"] != null)
            {
                Queue<tbl_CourseTopicStory> qlist = (Queue<tbl_CourseTopicStory>)TempData["ctsData"];
                if (qlist.Count > 0)
                {
                    q = qlist.Peek();
                    qlist.Dequeue();
                    TempData["ctsData"] = qlist;
                    //TempData["Q"] = q;
                    tbl_Story story = db.tbl_Story.Where(x => x.Id == q.StoryId).FirstOrDefault();
                    ViewData["Story"] = story.Story;

                    List<tbl_Question> questionList = db.tbl_Question.Where(x => x.StoryId == q.StoryId).OrderBy(x => x.ID).ToList();
                    ViewData["QuestionList"] = questionList;
                    TempData["QuestionList"] = questionList;
                    TempData["StoryID"] = q.StoryId;
                    TempData["QuestionID"] = q.Id;
                    TempData.Keep();
                    return View(q);
                }
                else
                {

                    int topicID = Convert.ToInt32(TempData["TopicID"]);
                    int courseID = Convert.ToInt32(TempData["CourseID"]);



                    List<tbl_Topic> topicList = new List<tbl_Topic>();
                    List<tbl_Topic> finishedTopicList = new List<tbl_Topic>();
                    tbl_Topic topic = new tbl_Topic();
                    var s = from p in db.tbl_CourseTopicStory
                            group p by p.TopicId into g
                            where g.FirstOrDefault().CourseId == courseID
                            select new IntVO
                            {
                                TopicID = g.FirstOrDefault().TopicId,
                            };
                    List<IntVO> intVO = s.ToList();

                    foreach (var item2 in intVO)
                    {
                        topic = db.tbl_Topic.Where(x => x.Id == item2.TopicID).OrderByDescending(x => x.Id).SingleOrDefault();
                        if (topic != null)
                        {
                            tbl_CourseTopicLog log = db.tbl_CourseTopicLog.Where(x => x.TopicID == topic.Id).FirstOrDefault();
                            if (log == null)
                            {
                                topicList.Add(topic);
                            }
                            else
                            {
                                finishedTopicList.Add(topic);
                            }
                        }
                    }
                    List<tbl_Question> QuestionSelected = null;
                    QuestionSelected = TempData["selectedQuestionList"] as List<tbl_Question>;

                    List<QuestionVO> questionList1 = new List<QuestionVO>();
                    questionList1 = TempData["QuestionList1"] as List<QuestionVO>;

                    if (CheckResult(QuestionSelected, questionList1))
                    {
                        SaveCourseTopicLog(courseID, topicID, employeeID);
                        if (topicList.Count == 0)
                        {
                            tbl_CourseLog tempLog = db.tbl_CourseLog.Where(x => x.CourseID == courseID && x.EmployeeID == employeeID).FirstOrDefault();
                            if (tempLog == null)
                            {
                                SaveCourseLog(courseID, employeeID);
                            }

                            List<tbl_EmployeeCourse> li = db.tbl_EmployeeCourse.Where(x => x.EmployeeID == employeeID).OrderByDescending(x => x.EmployeeCourseID).ToList();
                            List<tbl_Course> courseList = new List<tbl_Course>();
                            List<tbl_Course> finishedCourseList = new List<tbl_Course>();
                            tbl_Course c = new tbl_Course();

                            // Define Current Course List and Finished Course List
                            foreach (var item in li)
                            {

                                c = db.tbl_Course.Where(x => x.Id == item.CourseID).OrderByDescending(x => x.Id).SingleOrDefault();
                                if (c != null)
                                {
                                    tbl_CourseLog log = db.tbl_CourseLog.Where(x => x.CourseID == c.Id && x.EmployeeID == employeeID).FirstOrDefault();
                                    if (log == null)
                                    {
                                        courseList.Add(c);
                                    }
                                    else
                                    {
                                        finishedCourseList.Add(c);
                                    }

                                }


                            }
                            if (courseList.Count == 0)
                            {
                                TempData["AllFinished"] = "Congratulation!";
                                TempData.Keep();
                            }
                            else
                            {
                                TempData["CourseFinishedResult"] = "Congratulation. You Passed!";
                                TempData.Keep();
                            }


                        }
                        else
                        {
                            TempData["Result"] = "Congratulation. You Passed!";
                            TempData.Keep();
                        }
                    }
                    else
                    {
                        TempData["selectedQuestionList"] = null;
                        return RedirectToAction("TopicAndDescription", new { topicID = topicID, courseID = courseID });
                    }
                    TempData["selectedQuestionList"] = null;
                    return RedirectToAction("Courses");


                }

            }
            //else
            //{
            //    return RedirectToAction("StudentExam");
            //}


            return View();
        }

        [HttpPost]
        public ActionResult QuestionStart(CourseTopicStoryVO q)
        {
            if (Session["employee_id"] == null)
            {
                return RedirectToAction("EmployeeLogin");
            }

            List<QuestionVO> questionList1 = new List<QuestionVO>();
            if ((TempData["QuestionList"] as List<tbl_Question>).Count() > 0)
            {
                foreach (var item in TempData["QuestionList"] as List<tbl_Question>)
                {
                    QuestionVO qVO = new QuestionVO();
                    qVO.ID = item.ID;
                    qVO.IsCorrect = item.IsCorrect;
                    qVO.Answer = item.Answer;
                    questionList1.Add(qVO);
                }
            }
            TempData["QuestionList1"] = questionList1;
            TempData.Keep();
            List<tbl_Question> questionList = new List<tbl_Question>();
            questionList = TempData["QuestionList"] as List<tbl_Question>;

            foreach (var item in questionList)
            {
                item.IsCorrect = false;
            }
            if (q.SelectedQuestion.Count != 0)
            {
                foreach (var item in questionList)
                {
                    foreach (var items in q.SelectedQuestion)
                    {
                        //if (item.ID.ToString() == items.Id.ToString())
                        if (item.ID.ToString() == items.Trim())
                        {
                            item.IsCorrect = true;
                            TempData["QuestionID"] = item.ID;
                        }
                    }
                }
            }
            else
            {
                foreach (var item in questionList)
                {
                    item.IsCorrect = false;
                }
            }
            TempData["selectedQuestionList"] = questionList;
            TempData.Keep();
            if (CheckResult(questionList, questionList1))
            {
                SaveCorrectAns(Convert.ToInt32(TempData["CourseID"]), Convert.ToInt32(TempData["TopicID"]), Convert.ToInt32(Session["employee_id"]), Convert.ToInt32(TempData["QuestionID"]));
                return RedirectToAction("QuestionStart");
            }
            else
            {

                tbl_ProgressTransaction pt = new tbl_ProgressTransaction();
                pt.TransactionDate = DateTime.Now;
                pt.EmployeeID = Convert.ToInt32(Session["employee_id"]);
                pt.CourseID = Convert.ToInt32(TempData["CourseID"]);
                pt.TopicID = Convert.ToInt32(TempData["TopicID"]);
                pt.StoryID = Convert.ToInt32(TempData["StoryID"]);
                pt.QuestionID = Convert.ToInt32(TempData["QuestionID"]);
                pt.StartDateTime = (DateTime)Session["StartDateTime"];
                pt.EndDateTime = DateTime.Now;
                pt.AnswerStatus = false;
                pt.LastModifiedBy = Convert.ToInt32(Session["employee_id"]);
                pt.LastModifiedOn = DateTime.Now;
                db.tbl_ProgressTransaction.Add(pt);
                db.SaveChanges();


                TempData["QuestionMsg"] = "Your answer is wrong. Please read the story again!";
                TempData.Keep();
                return RedirectToAction("Courses");
            }
        }

        public bool CheckResult(List<tbl_Question> tbl_question, List<QuestionVO> questionVO)
        {
            int i = 0;
            List<tbl_Question> selectedAns = new List<tbl_Question>();
            if (questionVO != null && tbl_question != null)
            {
                foreach (var item in questionVO)
                {
                    foreach (var items in tbl_question)
                    {
                        if (item.ID == items.ID && item.IsCorrect == items.IsCorrect)
                        {
                            i++;

                        }

                    }

                }
                foreach (var selected in tbl_question)
                {
                    if (selected.IsCorrect == true)
                    {
                        selectedAns.Add(selected);
                    }
                }
                if (selectedAns.Count == 0)
                {
                    TempData["SelectedAns"] = null;
                }
                else
                {
                    TempData["SelectedAns"] = selectedAns;
                }
                TempData.Keep();
                if (i == questionVO.Count())
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }

        }

        public void SaveCourseTopicLog(int courseID, int topicID, int employeeID)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
                tbl_CourseTopicLog log = new tbl_CourseTopicLog();
                log.CourseID = courseID;
                log.TopicID = topicID;
                log.EmployeeID = employeeID;
                log.AnswerStatus = true;
                log.LastModifiedBy = employeeID;
                log.LastModifiedOn = DateTime.Now;
                db.tbl_CourseTopicLog.Add(log);
                db.SaveChanges();

                //tbl_ProgressTransaction pt = new tbl_ProgressTransaction();
                //pt.TransactionDate = DateTime.Now;
                //pt.EmployeeID = employeeID;
                //pt.CourseID = courseID;
                //pt.TopicID = topicID;
                //pt.StoryID = null;
                //pt.AnswerStatus = true;
                //pt.LastModifiedBy = employeeID;
                //pt.LastModifiedOn = DateTime.Now;
                //db.tbl_ProgressTransaction.Add(pt);
                //db.SaveChanges();
                //scope.Complete();
            //}
        }

        public void SaveCorrectAns(int courseID, int topicID, int employeeID, int questionID)
        {         
                tbl_ProgressTransaction pt = new tbl_ProgressTransaction();
                pt.TransactionDate = DateTime.Now;
                pt.EmployeeID = employeeID;
                pt.CourseID = courseID;
                pt.TopicID = topicID;
                pt.StoryID = Convert.ToInt32(TempData["StoryID"]);
				pt.QuestionID = questionID;
                pt.StartDateTime = (DateTime)Session["StartDateTime"];
                pt.EndDateTime = DateTime.Now;
                pt.AnswerStatus = true;
                pt.LastModifiedBy = employeeID;
                pt.LastModifiedOn = DateTime.Now;
                db.tbl_ProgressTransaction.Add(pt);
                db.SaveChanges();
        }
        public void SaveCourseLog(int courseID, int employeeID)
        {
            tbl_CourseLog log = new tbl_CourseLog();
            log.CourseID = courseID;
            log.EmployeeID = employeeID;
            log.Status = true;
            log.LastModifiedBy = employeeID;
            log.LastModifiedOn = DateTime.Now;
            db.tbl_CourseLog.Add(log);
            db.SaveChanges();
        }
        public static string HashPassword(string password)
        {

            byte[] hashedPassword;

            using (SHA1 sha1 = new SHA1Managed())
            {
                hashedPassword = sha1.ComputeHash(Encoding.ASCII.GetBytes(password));
            }

            string hexPassword = "0x" + BitConverter.ToString(hashedPassword).Replace("-", "");

            return hexPassword;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            ViewData["ExpiredMsg"] = null;
            TempData["ExpiredMsg"] = null;
            ViewData["ContactUsMsg"] = null;
            TempData["ContactUsMsg"] = null;
            ViewData.Clear();
            TempData.Clear();
            return RedirectToAction("Index");
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }
    }
}
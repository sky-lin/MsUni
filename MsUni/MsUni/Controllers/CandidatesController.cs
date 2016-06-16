using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MsUni.Models;
using MsUni.Helper;

namespace MsUni.Controllers
{
    public class CandidatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Candidates
        public ActionResult Index()
        {
            return View(db.Candidates.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CandidateId,Name,Age,City,Mobile,University,Email,CandidateImage,Vote,Approved")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateId,Name,Age,City,Mobile,University,Email,CandidateImage,Vote,Approved")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Contacts/Vote/5
        public ActionResult Vote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate contact = db.Candidates.Find(id);
            string ip = IPHelper.GetVisitorIPAddress(false);
            if (contact == null)
            {
                return HttpNotFound();
            }
            else if (db.Votes.Any(x => x.UserIP.Equals(ip)))
            {
                ViewBag.errorMessage = "This IP has already made a vote. One IP can only vote once.";
                return View("Error");
            }
            return View(contact);
        }

        // POST: Contacts/Vote/5
        [HttpPost, ActionName("Vote")]
        [ValidateAntiForgeryToken]
        public ActionResult VoteConfirmed(int id)
        {
            Candidate contact = db.Candidates.Find(id);
            contact.Vote++;
            string ip = IPHelper.GetVisitorIPAddress(false);
            db.Votes.Add(new Vote()
            {
                UserIP = ip,
                UserName = User.Identity.Name,
                VoteTime = DateTime.UtcNow,
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Candidates/Apply
        public ActionResult Apply()
        {
            return View();
        }

        // POST: Candidates/Apply
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply([Bind(Include = "CandidateId,Name,Age,City,Mobile,University,Email")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                bool userAlreadyApplied = db.Candidates.Any(x => string.Equals(x.Email, User.Identity.Name));

                if (userAlreadyApplied) {
                    ViewBag.errorMessage = "You Have Already Applied!";
                    return View("error");
                }

                bool picAlreadyExist = db.Images.Any(x => string.Equals(x.UserId, User.Identity.Name)
                    && string.Equals(x.ImageType, "Upload"));

                if (picAlreadyExist)
                {
                    MsUni.Models.Image imageDB = db.Images.First(x => string.Equals(x.UserId, User.Identity.Name)
                        && string.Equals(x.ImageType, "Upload"));

                    candidate.CandidateImageId = imageDB.ImageId;

                    db.Candidates.Add(candidate);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.errorMessage = "Please upload a picture for the competition!";
                    return View("error");
                }
            }

            return View(candidate);
        }

        [HttpPost]
        public ActionResult Upload(string type)
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentType != "image/jpeg")
                {
                    ViewBag.errorMessage = "Please upload the correct image with jpeg type!";
                    return View("error");
                }
                byte[] imageSize = new byte[file.ContentLength];
                file.InputStream.Read(imageSize, 0, (int)file.ContentLength);

                bool picAlreadyExist = db.Images.Any(x => string.Equals(x.UserId, User.Identity.Name)
                    && string.Equals(x.ImageType, type));

                if (picAlreadyExist)
                {
                    MsUni.Models.Image imageDB = db.Images.First(x => string.Equals(x.UserId, User.Identity.Name)
                        && string.Equals(x.ImageType, type));

                    imageDB.ImageData = imageSize;
                    if (ModelState.IsValid)
                    {
                        db.Entry(imageDB).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    db.Images.Add(new MsUni.Models.Image
                    {
                        ImageData = imageSize,
                        UserId = User.Identity.Name,
                        ImageType = type
                    });
                    db.SaveChanges();
                }
                return View("Apply");
            }
            catch
            {
                ViewBag.errorMessage = "Error happened when uploading picture!";
                return View("error");
            }
        }

        public ActionResult GetImageByUser(string type)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                ViewBag.errorMessage = "You must log in";
                return View("error");
            }

            bool picAlreadyExist = db.Images.Any(x => string.Equals(x.UserId, User.Identity.Name)
                && string.Equals(x.ImageType, type));

            if (picAlreadyExist)
            {
                MsUni.Models.Image imageDB = db.Images.First(x => string.Equals(x.UserId, User.Identity.Name)
                && string.Equals(x.ImageType, type));

                byte[] image = imageDB.ImageData;
                return File(image, "image/jpg");
            }
            else
            {
                return File("./../Images/default", "image/jpg");
            }
        }

        public ActionResult GetThumbNailImageByImageId(int imageId)
        {
            MsUni.Models.Image image = db.Images.Find(imageId);
            if (image == null)
            {
                return null;
            }
            byte[] imageData = image.ImageData;
            System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(imageData);
            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
            System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(60, 80, null, IntPtr.Zero);
            System.IO.MemoryStream myResult = new System.IO.MemoryStream();
            newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);  //Or whatever format you want.
            return File(myResult.ToArray(), "image/jpg");
        }
        public ActionResult GetImageByImageId(int imageId)
        {
            MsUni.Models.Image image = db.Images.Find(imageId);
            if (image == null) {
                return null;
            }
            byte[] imageData = image.ImageData;
            return File(imageData, "image/jpg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

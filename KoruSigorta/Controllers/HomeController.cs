using FluentValidation.Results;
using Rezervasyon.Abstract;
using Rezervasyon.FluentValidation;
using Rezervasyon.Models;
using Rezervasyon.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rezervasyon.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Randevu> _randevu = new GenericRepository<Randevu>();

        #region Randevu Alma
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Randevu randevu)
        {
            RandevuValidation rv = new RandevuValidation();
            ValidationResult results = rv.Validate(randevu);
            
            if (results.IsValid)
            {
                _randevu.Insert(randevu);
                randevu.Approval = false;
                return View();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
        #endregion

        #region Onaysız Randevu Listesi
        public ActionResult Index()
        {
            var randevuValue = _randevu.List();

            return View(randevuValue);
        }
        #endregion

        #region Onaylı Randevu Listesi
        public ActionResult Index2()
        {
            var randevuValue = _randevu.List();

            return View(randevuValue);
        }
        #endregion

        #region Randevu Onay
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var p = _randevu.GetByID(id);

            return View(p);

        }
        [HttpPost]
        public ActionResult Edit(Randevu r)
        {
            r.Approval = true;

            _randevu.Update(r);
            return RedirectToAction("Index");
        }
        #endregion
        
    }
}
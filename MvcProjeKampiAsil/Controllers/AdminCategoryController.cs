﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampiAsil.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategoryController

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);    

        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();


        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator cat=new CategoryValidator();
            ValidationResult results=cat.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
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

        public ActionResult DeleteCategory(int id)
        {

            var categoryvalue=cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
        cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }



    }
}
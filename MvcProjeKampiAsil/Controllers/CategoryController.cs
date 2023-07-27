﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampiAsil.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
           var categoryvalues = cm.GetList();
            return View(categoryvalues);

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();

        }



        [HttpPost]
        public ActionResult AddCategory(Category p)
        {

          //  cm.CategoryAddBL(p);
          CategoryValidator categoryValidator =new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return RedirectToAction("GetCategoryList");
        }


    }
}
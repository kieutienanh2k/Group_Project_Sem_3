﻿using ProjectSem3.Models;
using ProjectSem3.Models.SaleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSem3.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private const string CartSession = "CartSession";

        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int bookId, int quantity)
        {
            Book book = db.Books.SingleOrDefault(n => n.Id == bookId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Book.Id == bookId))
                {
                    foreach (var item in list)
                    {
                        if (item.Book.Id == bookId) 
                        {
                            item.Quantity += quantity;
                        }   
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Book = book;
                    item.Quantity = quantity;
                    list.Add(item);
                }
            }
            else
            {
                var item = new CartItem();
                item.Book = book;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                //gan vao session
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }
        public ActionResult DeleteItem(int bookId)
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            foreach (var item in list)
            {
                if (item.Book.Id == bookId)
                {
                    list.Remove(item);
                    break;
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCart(FormCollection fc)
        {
            string[] quantities = fc.GetValues("quantity");
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[CartSession] = list;

            return RedirectToAction("Index");
        }
        public ActionResult Payment()
        {
           
            return View("Payment");
        }
        public ActionResult ProcessOrder(FormCollection fc)
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            //
            /* ApplicationUser applicationUser = new ApplicationUser()
             {
                 UserName = fc["username"],
                 Email = fc["email"],
                 Address = fc["address"]
             };*/
            var userId = db.Users
                .Where(m => m.Email == fc["email"])
                .Select(m => m.Id)
                .SingleOrDefault();

            // 1.save into order
            Order order = new Order()
            {
                UserId = userId,
                DateOrder = DateTime.Now,
                PaymentId = int.Parse(fc["Form"]),
                Status = "da dat hang",
                Description = fc["description"]
            };


            // 2.save into orderdetail

            return View("OrderSuccess");
        }
    }
}
using DataAcess;
using Domen;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PostContext();

            //DodajTip();
            //dodajPost();
            //DodajMeni();
            //var type2 = context.UserTypes.Find(2);
            
            //context.Users.Add(new User
            //{
            //    Username = "admin",
            //    Password = "admin",
            //    Email = "jelena.miletic.171.12@ict.esu.rs",
            //    UserType = type2
            //});

            //context.SaveChanges();

        }

        //private static void DodajTip()
        //{
        //    var context = new PostContext();

        //    context.CategoryPosts.Add(new CategoryPost
        //    {
        //        NameCat = "Travel"

        //    });
        //    context.CategoryPosts.Add(new CategoryPost
        //    {
        //        NameCat = "Holiday"

        //    });

        //    context.CategoryPosts.Add(new CategoryPost
        //    {
        //        NameCat = "Food"

        //    });
        //    context.CategoryPosts.Add(new CategoryPost
        //    {
        //        NameCat = "LifeStyle"

        //    });

        //    context.SaveChanges();
        //}



        //private static void dodajPost()
        //{
        //    var context = new PostContext();

        //    context.Posts.Add(new Post
        //    {
        //        Name = "The Outrageous Travel Fees You Can Totally Avoid",
        //        Text = "Resort fees were originally charged by, well, resorts, supposedly to cover their extra amenities like towels at the pool and classes at the fitness center.",
        //        Picture = "1.jpg",
        //        CategoryPost = context.CategoryPosts.Find(1),
        //        User = context.Users.Find(2)

        //    });
        //    context.Posts.Add(new Post
        //    {
        //        Name = "35 REASONS TO VISIT GREECE",
        //        Text = "When it comes to hospitality and welcoming people I have never ever experienced anything like Greece.",
        //        Picture = "1.jpg",
        //        CategoryPost = context.CategoryPosts.Find(2),
        //        User = context.Users.Find(2)

        //    });
        //    context.Posts.Add(new Post
        //    {
        //        Name = "Is Chinese Food Healthy to Eat?",
        //        Text = "For a healthy Chinese meal, choose lean sources of protein, such as shrimp, skinless chicken breast, fish and tofu.",
        //        Picture = "1.jpg",
        //        CategoryPost = context.CategoryPosts.Find(3),
        //        User = context.Users.Find(2)

        //    });
        //    context.Posts.Add(new Post
        //    {
        //        Name = "KNOW YOUR LIFESTYLE",
        //        Text = "In cooperation with Second Chance-teachers and non-governmental organisations (NGOs) engaged in development education,",
        //        Picture = "1.jpg",
        //        CategoryPost = context.CategoryPosts.Find(4),
        //        User = context.Users.Find(2)

        //    });

        //    context.SaveChanges();

        //}

        //private static void DodajMeni() {
        //    var context = new PostContext();

        //    context.Menus.Add(new Menu {
        //        MenuName="Pocetna",
        //        Link="api/pocetna"

        //    });

        //    context.Menus.Add(new Menu
        //    {
        //        MenuName = "Galerija",
        //        Link = "api/pocetna"

        //    });

        //    context.SaveChanges();
        //}
    }


       
}

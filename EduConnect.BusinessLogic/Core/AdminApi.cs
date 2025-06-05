using EduConnect.BusinessLogic.DBModel;
using EduConnect.Domain.Entities.Thread;
using EduConnect.Domain.Entities.User;
using EduConnect.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduConnect.BusinessLogic.Core
{
    internal class AdminApi
    {
        // --- User Methods ---
        protected IEnumerable<UDbTable> GetAllUsersAction()
        {
            using (var db = new UserContext())
            {
                return db.Users.ToList();
            }
        }

        protected UDbTable GetUserByIdAction(int id)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }



          protected bool UpdateUserAction(UDbTable updatedUser)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
                    if (user == null)
                         return false;

                    user.Username = updatedUser.Username;
                    user.Email = updatedUser.Email;
                    user.Level = updatedUser.Level;

                    if (!string.IsNullOrWhiteSpace(updatedUser.Password))
                    {
                         user.Password = PasswordHelper.HashGen(updatedUser.Password);
                    }

                    db.SaveChanges();
                    return true;
               }
          }


          protected bool DeleteUserAction(int id)
          {
               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user == null)
                         return false;

                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
        }

        // --- Thread Methods ---
        protected IEnumerable<UDbThreads> GetAllThreadsAction()
        {
            using (var db = new UserContext())
            {
                return db.Threads.ToList();
            }
        }

        protected UDbThreads GetThreadByIdAction(int id)
        {
            using (var db = new UserContext())
            {
                return db.Threads.FirstOrDefault(t => t.Id == id);
            }
        }

        protected bool UpdateThreadAction(UDbThreads updatedThread)
        {
            using (var db = new UserContext())
            {
                var thread = db.Threads.FirstOrDefault(t => t.Id == updatedThread.Id);
                if (thread == null)
                    return false;

                thread.Title = updatedThread.Title;
                thread.Author = updatedThread.Author;
                thread.Category = updatedThread.Category;
                thread.Description = updatedThread.Description;

                db.SaveChanges();
                return true;
            }
        }

        protected bool DeleteThreadAction(int id)
        {
            using (var db = new UserContext())
            {
                var thread = db.Threads.FirstOrDefault(t => t.Id == id);
                if (thread == null)
                    return false;

                db.Threads.Remove(thread);
                db.SaveChanges();
                return true;
            }
        }

        // --- Create Thread using DTO ---
        protected AddThreadResp AddThreadAction(AddThreadDTO dto)
        {
            var response = new AddThreadResp();

            if (string.IsNullOrWhiteSpace(dto.Title) || dto.Title.Length > 128)
            {
                response.Status = false;
                response.Error = "Title is required and must be less than 128 characters.";
                return response;
            }

            if (string.IsNullOrWhiteSpace(dto.Author))
            {
                response.Status = false;
                response.Error = "Author is required.";
                return response;
            }

            if (string.IsNullOrWhiteSpace(dto.Category))
            {
                response.Status = false;
                response.Error = "Category is required.";
                return response;
            }

            if (dto.Description != null && dto.Description.Length > 2048)
            {
                response.Status = false;
                response.Error = "Description must be less than 2048 characters.";
                return response;
            }

            using (var db = new UserContext())
            {
                var newThread = new UDbThreads
                {
                    Title = dto.Title,
                    Author = dto.Author,
                    Category = dto.Category,
                    Description = dto.Description
                };

                db.Threads.Add(newThread);
                db.SaveChanges();
            }

            response.Status = true;
            return response;
        }
    }
}

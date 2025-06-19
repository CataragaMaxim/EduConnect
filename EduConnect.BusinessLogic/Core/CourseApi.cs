using EduConnect.BusinessLogic.DBModel;
using EduConnect.Domain.Entities.Courses;
using EduConnect.Domain.Entities.User;
using System;
using System.Linq;

namespace EduConnect.BusinessLogic.Core
{
     public class CourseApi
     {
          public AddThreadResp AddCourseAction(AddCourseDTO model)
          {
               using (var db = new UserContext())
               {
                    var entity = new UDbCourse
                    {
                         Title = model.Title,
                         Description = model.Description,
                         Category = model.Category,
                         AccessLevel = model.AccessLevel,
                         AllowedUsers = model.AllowedUsers,
                         CreatedBy = model.CreatedBy,
                         CreatedAt = DateTime.Now
                    };
                    db.Courses.Add(entity);
                    db.SaveChanges();

                    if (model.Videos != null)
                    {
                         foreach (var v in model.Videos)
                              db.VideoItems.Add(new VideoItem
                              {
                                   CourseId = entity.Id,
                                   Title = v.Title,
                                   VideoUrl = v.VideoUrl,
                                   Order = v.Order
                              });
                         db.SaveChanges();
                    }
               }
               return new AddThreadResp { Status = true };
          }

          public void UpdateCourseAction(AddCourseDTO model)
          {
               using (var db = new UserContext())
               {
                    var e = db.Courses.FirstOrDefault(c => c.Id == model.Id);
                    if (e == null) return;

                    e.Title = model.Title;
                    e.Description = model.Description;
                    e.Category = model.Category;
                    e.AccessLevel = model.AccessLevel;
                    e.AllowedUsers = model.AllowedUsers;

                    var old = db.VideoItems.Where(v => v.CourseId == e.Id);
                    db.VideoItems.RemoveRange(old);
                    db.SaveChanges();

                    if (model.Videos != null)
                    {
                         foreach (var v in model.Videos)
                              db.VideoItems.Add(new VideoItem
                              {
                                   CourseId = e.Id,
                                   Title = v.Title,
                                   VideoUrl = v.VideoUrl,
                                   Order = v.Order
                              });
                    }
                    db.SaveChanges();
               }
          }

          public void DeleteCourseAction(int id)
          {
               using (var db = new UserContext())
               {
                    var e = db.Courses.FirstOrDefault(c => c.Id == id);
                    if (e == null) return;

                    var vids = db.VideoItems.Where(v => v.CourseId == id);
                    db.VideoItems.RemoveRange(vids);
                    db.Courses.Remove(e);
                    db.SaveChanges();
               }
          }

          public UDbCourse GetCourseByIdAction(int id)
          {
               using (var db = new UserContext())
               {
                    return db.Courses.Include("VideoItems").FirstOrDefault(c => c.Id == id);
               }
          }

          public IQueryable<UDbCourse> GetAllCoursesAction()
          {
               var db = new UserContext();
               return db.Courses.Include("VideoItems");
          }
     }
}

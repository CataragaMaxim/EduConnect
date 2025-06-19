using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.Courses;
using EduConnect.Domain.Entities.User;
using System.Collections.Generic;

namespace EduConnect.BusinessLogic.BLogic
{
     public class CourseBL : CourseApi, ICourse
     {
          public AddThreadResp AddCourse(AddCourseDTO model)
          {
               return AddCourseAction(model);
          }

          public void UpdateCourse(AddCourseDTO model)
          {
               UpdateCourseAction(model);
          }

          public void DeleteCourse(int id)
          {
               DeleteCourseAction(id);
          }

          public UDbCourse GetCourseById(int id)
          {
               return GetCourseByIdAction(id);
          }

          public IEnumerable<UDbCourse> GetAllCourses()
          {
               return GetAllCoursesAction();
          }
     }
}

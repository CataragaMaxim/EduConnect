using EduConnect.BusinessLogic.BLogic;
using EduConnect.Domain.Entities.Courses;
using EduConnect.Domain.Entities.User;
using System.Collections.Generic;

namespace EduConnect.BusinessLogic.Interfaces
{
     public interface ICourse
     {
          AddThreadResp AddCourse(AddCourseDTO model);
          void UpdateCourse(AddCourseDTO model);
          void DeleteCourse(int id);
          UDbCourse GetCourseById(int id);
          IEnumerable<UDbCourse> GetAllCourses();

     }
}

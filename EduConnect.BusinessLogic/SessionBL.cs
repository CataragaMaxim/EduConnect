using EduConnect.BusinessLogic.Core;
using EduConnect.BusinessLogic.Interfaces;
using EduConnect.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EduConnect.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          private readonly HttpSessionStateBase _session;
          private readonly HttpRequestBase _request;
          private readonly HttpResponseBase _response;

          public SessionBL(HttpSessionStateBase session, HttpRequestBase request, HttpResponseBase response)
          {
               _session = session;
               _request = request;
               _response = response;
          }

          public void SetUserSession(string username, int userLevel, string token, string email)
          {
               _session["Username"] = username;
               _session["UserLevel"] = userLevel;
               _session["UserToken"] = token;
               _session["UserEmail"] = email;

               var cookie = new HttpCookie("UserToken", token)
               {
                    Expires = DateTime.Now.AddDays(1)
               };
               _response.Cookies.Add(cookie);
          }

          public string GetUserEmail()
          {
               return _session["UserEmail"] as string;
          }

          public void ClearUserSession()
          {
               _session.Clear();

               if (_request.Cookies["UserToken"] != null)
               {
                    var cookie = new HttpCookie("UserToken") { Expires = DateTime.Now.AddDays(-1) };
                    _response.Cookies.Add(cookie);
               }
          }

          public string GetUserToken()
          {
               var token = _session["UserToken"] as string;
               if (string.IsNullOrEmpty(token) && _request.Cookies["UserToken"] != null)
               {
                    token = _request.Cookies["UserToken"].Value;
               }
               return token;
          }

          public bool IsSessionValid(string key)
          {
               return IsSessionValidAction(key);
          }

          public int GetUserIdBySessionKey(string key)
          {
               return GetUserIdBySessionKeyAction(key);
          }
     }
}

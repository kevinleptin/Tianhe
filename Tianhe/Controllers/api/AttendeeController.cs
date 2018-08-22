using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tianhe.Models;
using Tianhe.Models.dto;

namespace Tianhe.Controllers.api
{
    public class AttendeeController : ApiController
    {
        [Route("api/attendee/join")]
        [HttpPost]
        public IHttpActionResult Join(Attendee attendee)
        {
            if (attendee == null)
            {
                return BadRequest("提交数据有误");
            }

            ErrorMessage dto = new ErrorMessage();

            if (string.IsNullOrEmpty(attendee.MobiPhoneNumber))
            {
                dto.Status = 1;
                dto.Msg = "电话号码不能为空";
                return Ok(dto);
            }

            attendee.Ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            attendee.City = System.Web.HttpUtility.UrlDecode(attendee.City);
            attendee.Gender = System.Web.HttpUtility.UrlDecode(attendee.Gender);
            attendee.Name = System.Web.HttpUtility.UrlDecode(attendee.Name);
            attendee.Province = System.Web.HttpUtility.UrlDecode(attendee.Province);

            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                if (_context.Attendees.FirstOrDefault(c => c.MobiPhoneNumber == attendee.MobiPhoneNumber) != null)
                {
                    dto.Status = 1;
                    dto.Msg = "该电话号码已参与成功，请勿重复提交。";
                    return Ok(dto);
                }
                _context.Attendees.Add(attendee);
                _context.SaveChanges();
                dto.Msg = "参与成功";
                dto.Status = 0;
                return Ok(dto);
            }
        }
    }
}

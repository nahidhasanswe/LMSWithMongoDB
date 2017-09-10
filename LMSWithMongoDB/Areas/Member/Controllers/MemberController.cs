using BusinessLogicLayer.MemberLogic;
using RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMSWithMongoDB.Areas.Member.Controllers
{
    [RoutePrefix("api/Member/Operation")]
    public class MemberController : ApiController
    {
        MemberOperation _member = new MemberOperation();

        [HttpPost]
        [Route("AddMember")]
        public async Task<IHttpActionResult> Add(Members member)
        {
            try
            {
                await _member.AddMember(member);
                return Ok("Successfully add new Member");
            }
            catch
            {
                return BadRequest("Member Id can not be duplicated");
            }

        }

        [HttpGet]
        [Route("GetMember/{id}")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetMemberById(string id)
        {
            var member = await _member.GetMemberById(id);
            if (member == null)
            {
                return BadRequest("The member is not exist");
            }
            return Ok(member);

        }

        [HttpGet]
        [Route("GetMember")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetMember()
        {
            var members = await _member.GetAllMembers();
            return Ok(members);

        }

        [HttpPost]
        [Route("UpdateMember")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateMember(Members member)
        {
            try
            {
                await _member.UpdateMember(member.Id, member);
            }
            catch
            {
                return BadRequest("The member is not exist");
            }
            return Ok("You have successfully updated the member");

        }

        [HttpGet]
        [Route("RemoveMember/{id}")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> RemoveMember(string id)
        {
            try
            {
                await _member.DeleteMemberById(id);
            }
            catch
            {
                return BadRequest("The member is not exist");
            }
            return Ok("You have successfully remove the member");

        }

    }
}

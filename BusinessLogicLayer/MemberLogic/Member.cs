using MongoDB.Driver;
using RepositoryPattern;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BusinessLogicLayer.MemberLogic
{
    public class MemberOperation
    {
        MemberRepository _member;

        public MemberOperation()
        {
            _member = new MemberRepository();
        }

        public async Task AddMember(Members member)
        {
            await _member.Add(member);
        }

        public async Task<IEnumerable<Members>> GetAllMembers()
        {
            return await _member.Get();
        }

        public async Task<Members> GetMemberById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id can not be null"));
            else if (id.Length != 24)
                throw new HttpResponseException(ExceptionHandle.BadRequest("Invalid Id. Please check id length"));

            try
            {
                return await _member.Get(id);
            }catch(FormatException e)
            {
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id format is not valid. Please check again"));
            }
            
        }

        public async Task<DeleteResult> DeleteMemberById(string id)
        {
            return await _member.Remove(id);
        }

        public async Task UpdateMember(string id, Members member)
        {
            await _member.Update(id, member);
        }
    }
}
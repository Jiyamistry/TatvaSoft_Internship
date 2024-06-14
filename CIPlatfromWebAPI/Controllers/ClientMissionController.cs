using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientMissionController : ControllerBase
    {
        private readonly BALMission _balMission;
        ResponseResult result = new ResponseResult();
        public ClientMissionController(BALMission balMission)
        {
            _balMission = balMission;
        }

        [HttpGet]
        [Route("ClientSideMissionList/{userid}")]
        public ResponseResult ClientSideMissionList(int userid)
        {
            try
            {
                result.Data = _balMission.ClientSideMissionList(userid);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("ApplyMission")]
        public ResponseResult ApplyMission(MissionApplication missionApplication)
        {
            try
            {
                result.Data = _balMission.ApplyMission(missionApplication);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("MissionClientList")]
        public ResponseResult MissionClientList(SortestData data)
        {
            try
            {
                result.Data = _balMission.MissionClientList(data);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("AddMissionFavourite")]
        public ResponseResult AddMissionFavourite(MissionFavourites missionFavourites)
        {
            try
            {
                result.Data = _balMission.AddMissionFavourite(missionFavourites);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("RemoveMissionFavourite")]
        public ResponseResult RemoveMissionFavourite(MissionFavourites missionFavourites)
        {
            try
            {
                result.Data = _balMission.RemoveMissionFavourite(missionFavourites);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("SendInviteMissionMail")]
        public ResponseResult SendInviteMissionMail(List<MissionShareOrInvite> user)
        {
            try
            {
                result.Data = _balMission.SendInviteMissionMail(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        [Route("MissionDetailByMissionId")]
        [Authorize]
        public ResponseResult MissionDetailByMissionId(SortestData data)
        {
            try
            {
                result.Data = _balMission.MissionDetailByMissionId(data);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}

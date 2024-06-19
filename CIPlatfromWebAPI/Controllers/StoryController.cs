using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly BALStory _balStory;
        ResponseResult result = new ResponseResult();
        public StoryController(BALStory balStory)
        {
            _balStory = balStory;
        }

        [HttpGet]
        [Route("GetMissionTitle")]
        public ResponseResult GetMissionTitle()
        {
            try
            {
                result.Data = _balStory.GetMissionTitle();
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
        [Route("AddStory")]
        public ResponseResult AddStory(Story story)
        {
            try
            {
                result.Data = _balStory.AddStory(story);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("ClientSideStoryList")]
        public ResponseResult ClientSideStoryList()
        {
            try
            {
                result.Data = _balStory.ClientSideStoryList();
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("StoryDetailById/{id}")]
        public ResponseResult StoryDetailById(int id)
        {
            try
            {
                result.Data = _balStory.StoryDetailById(id);
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
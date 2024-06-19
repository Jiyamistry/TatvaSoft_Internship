using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALStory
    {
        private readonly AppDbContext _cIDbContext;

        public DALStory(AppDbContext ciDbContext)
        {
            _cIDbContext = ciDbContext;
        }
        public List<DropDown> GetMissionTitle()
        {
            try
            {
                var missionTitleList = _cIDbContext.Missions
                    .Where(m => !m.IsDeleted)
                    .Select(m => new DropDown
                    {
                        Text = m.MissionTitle,
                        Value = m.Id
                    })
                    .ToList();

                return missionTitleList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch mission titles.", ex);
            }
        }

        public string AddStory(Story story)
        {
            string result = "";
            try
            {
                story.IsActive = false;

                int mID = _cIDbContext.Story.Max(u => u.Id) + 1;
                story.Id = mID;
                _cIDbContext.Story.Add(story);
                _cIDbContext.SaveChanges();

                result = "Story Added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add story.", ex);
            }
            return result;
        }


        public List<Story> ClientSideStoryList()
        {
            try
            {
                List<Story> storyList = _cIDbContext.Story.Where(s => !s.IsDeleted).ToList();
                return storyList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch story list.", ex);
            }
        }

        public Story StoryDetailById(int id)
        {
            try
            {
                var storyById = _cIDbContext.Story
                                            .FirstOrDefault(s => s.Id == id);

                return storyById;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch story details.", ex);
            }
        }

        public List<Story> AdminSideStoryList()
        {
            List<Story> storyList = new List<Story>();
            try
            {
                storyList = _cIDbContext.Story.Where(s => !s.IsDeleted).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return storyList;
        }
        public string StoryStatusActive(Story story)
        {
            try
            {
                var storyToUpdate = _cIDbContext.Story
                                                .FirstOrDefault(s => s.Id == story.Id);
                if (storyToUpdate != null)
                {
                    storyToUpdate.IsActive = true;
                    _cIDbContext.SaveChanges();
                    return "Story Activated";
                }
                else
                {
                    return "Story not found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update story active status.", ex);
            }
        }

        public string DeleteStory(int id)
        {
            try
            {
                var storyToDelete = _cIDbContext.Story.FirstOrDefault(s => s.Id == id);
                if (storyToDelete != null)
                {
                    _cIDbContext.Story.Remove(storyToDelete);
                    _cIDbContext.SaveChanges();
                    return "Story Deleted Successfully";
                }
                else
                {
                    return "Story not found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete story.", ex);
            }
        }


        public Story StoryDetailByIdAdmin(int id)
        {
            try
            {
                var storyById = _cIDbContext.Story.FirstOrDefault(s => s.Id == id);
                return storyById;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch story details.", ex);
            }
        }
    }
}
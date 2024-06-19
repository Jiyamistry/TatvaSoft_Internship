using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    public class Story : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public string UserFullName { get; set; }
        [NotMapped]
        public string UserImage { get; set; }
        [NotMapped]
        public string MissionTitle { get; set; }
        public string StoryTitle { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StoryDate { get; set; }
        public string StoryDescription { get; set; }
        public string VideoUrl { get; set; }
        public string StoryImage { get; set; }
        public bool IsActive { get; set; }
        public int? StoryViewerCount { get; set; } = 0;

    }
}
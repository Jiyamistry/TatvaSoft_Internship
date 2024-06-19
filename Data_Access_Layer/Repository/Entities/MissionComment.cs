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
    public class MissionComment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int UserId { get; set; }
        public string CommentDescription { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "timestamp")]
        public DateTime? CommentDate { get; set; }
        [NotMapped]
        public string UserFullName { get; set; }
        [NotMapped]
        public string UserImage { get; set; }
    }
}
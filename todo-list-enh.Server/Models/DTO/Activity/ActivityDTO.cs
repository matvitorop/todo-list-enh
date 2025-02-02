using System.ComponentModel.DataAnnotations.Schema;

namespace todo_list_enh.Server.Models.DTO.Activity
{
    public class ActivityDTO
    {
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
    }
}

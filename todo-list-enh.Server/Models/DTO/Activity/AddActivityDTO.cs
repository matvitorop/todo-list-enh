namespace todo_list_enh.Server.Models.DTO.Activity
{
    public class AddActivityDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
    }
}

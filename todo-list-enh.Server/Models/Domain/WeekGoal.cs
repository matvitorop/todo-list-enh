﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("WeekGoal")]
    public class WeekGoal
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Week")]
        public int periodId { get; set; }

        [ForeignKey("Goal")]
        public int GoalId { get; set; }

        public Week Week { get; set; } = null!;
        public Goal Goal { get; set; } = null!;
    }

}

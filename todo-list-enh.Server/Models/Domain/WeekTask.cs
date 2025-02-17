﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todo_list_enh.Server.Models.Domain
{
    [Table("WeekTask")]
    public class WeekTask
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Week")]
        public int periodId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        public int Order { get; set; }

        public Week Week { get; set; } = null!;
        //[JsonIgnore]
        public Task Task { get; set; } = null!;

    }
}

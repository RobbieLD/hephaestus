using Hephaestus.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hephaestus.Models
{
    public class LogEntry
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
    }
}

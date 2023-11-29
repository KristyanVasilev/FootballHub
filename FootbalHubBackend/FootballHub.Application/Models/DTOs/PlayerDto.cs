using FootballHub.Application.Models.PlayerApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballHub.Application.Models.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Photo { get; set; } = null!;
    }
}

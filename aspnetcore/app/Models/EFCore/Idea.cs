using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using StartupIdeas.Models;
using System;

namespace StartupIdeas.Models.EFCore
{
    public class Idea : ITrackable
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(20, 2)")]
        public decimal ProjectedRevenue { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}

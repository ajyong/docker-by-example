using System;

namespace StartupIdeas.Models
{
    public interface ITrackable
    {
        DateTimeOffset Created { get; set; }
        DateTimeOffset Modified { get; set; }
    }

}

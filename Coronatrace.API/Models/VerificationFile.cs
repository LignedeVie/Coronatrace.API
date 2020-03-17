using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coronatrace.API.Models
{
    public class VerificationFile
    {
        [Key]
        public long Id { get; set; }
        public string UserId { get; internal set; }
        public string FileName { get; internal set; }
    }
}

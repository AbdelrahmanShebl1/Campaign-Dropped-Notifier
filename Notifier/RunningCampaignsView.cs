#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Notifier
{
    [Keyless]
    public partial class RunningCampaignsView
    {
        [Required]
        [StringLength(100)]
        public string cName { get; set; }
        [Required]
        [StringLength(11)]
        [Unicode(false)]
        public string cSMSSender { get; set; }
        [Required]
        public string cSMSBody { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime cStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime cEndDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string cLocation { get; set; }
        public int cQuota { get; set; }
        [Required]
        [StringLength(3)]
        [Unicode(false)]
        public string cNoCommutersStatus { get; set; }
        public string cIncFile { get; set; }
        public string cExecFile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime cLogDate { get; set; }
    }
}
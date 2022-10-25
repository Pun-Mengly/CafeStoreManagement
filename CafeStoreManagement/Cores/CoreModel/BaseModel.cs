﻿
using System.ComponentModel.DataAnnotations.Schema;

public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; }
    }


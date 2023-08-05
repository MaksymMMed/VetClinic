﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DAL.Entities;

namespace VetClinic.BLL.DTO.Request
{
    public class AnimalRequest
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string AnimalSex { get; set; }
        public string AnimalKind { get; set; }
        public string OwnerId { get; set; }
    }
}

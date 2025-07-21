﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    internal class Speciality {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Doctor> Doctors { get; set; } = new();
    }
}

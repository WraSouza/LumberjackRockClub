﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LumberjackRockClub.Model
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Password {  get; set; }
        public string Email {  get; set; }
        public DateTime LastAccessDay {  get; set; }
        public DateTime CreatedDate {  get; set; }
        public string PerfilType { get; set; }
    }
}

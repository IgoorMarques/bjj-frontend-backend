﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Faixa")]
    public class Faixa : Base
    {
        public int Graus { get; set; }
        public string? Descricao { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}

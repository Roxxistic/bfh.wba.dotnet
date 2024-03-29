﻿using System.ComponentModel.DataAnnotations;

namespace Bfh.Wba.AspNetCore.Web.Models
{
    public class Konto
    {
        public KontoGruppe Funktion { get; set; }
        public KontoGruppe Sachgruppe { get; set; }

        [Required(ErrorMessage = "Nummer darf nicht leer sein")]
        [Range(0,99, ErrorMessage = "Nummer muss zwischen 0 und 99 liegen")]
        public int Nummer { get; set; }

        [Required(ErrorMessage = "Kontoname darf nicht leer sein")]
        public string Name { get; set; }

        public string Kontonummer
        {
            get
            {
                return $"{Funktion?.Id}.{Sachgruppe?.Id}.{Nummer:00}";
            }
        }
    }
}

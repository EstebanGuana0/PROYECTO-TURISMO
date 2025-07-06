using System;

namespace TurismoComunitario.Server.Models;
public class Reserva
    {
        public int Id { get; set; }
        public string LugarSeleccionado { get; set; }
        public int CantidadPersonas { get; set; }
        public bool DiscapacidadGeneral { get; set; }
        public string TiempoInicio { get; set; }
        public string TiempoFin { get; set; }
        public string PersonasJson { get; set; }  // Aquí se guarda la lista de personas en formato texto JSON
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }

using System;
using System.ComponentModel;

namespace ServiciosAdicionales.Data.Enum;

public enum EstadoPedido 
{
    [Description("Borrador")]
    Borrador,
    [Description("En curso")]
    EnCurso,
    [Description("Finalizado")]
    Finalizado


}

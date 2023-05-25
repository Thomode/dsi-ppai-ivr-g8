namespace dsi_ppai_grupo_8.Models;

public class CambioEstado
{
    private string fechaHoraInicio;
    private string fechaHoraFin;
    private Estado estado;
    public CambioEstado(string fechaHoraInicio, string fechaHoraFin, Estado estado)
    {
        this.fechaHoraInicio = fechaHoraInicio;
        this.fechaHoraFin = fechaHoraFin;
        this.estado = estado;
    }

}
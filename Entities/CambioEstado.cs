namespace dsi_ppai_ivr_g8.Entities;

public class CambioEstado
{
    private DateTime fechaHoraInicio;
    private Estado estado;

    public CambioEstado(DateTime fechaHoraInicio, Estado estado)
    {
        this.fechaHoraInicio = fechaHoraInicio;
        this.estado = estado;
    }

    public DateTime getFechaHoraInicio()
    {
        return this.fechaHoraInicio;
    }

    public bool esEstadoInicial()
    {
        return estado.esIniciada();
    }

    // cambiar nombre en el diagrama
    public bool esEstadoFinalizada()
    {
        return estado.esFinalizada();
    }

    public string getNombreEstado()
    {
        return this.estado.getNombre();
    }
}
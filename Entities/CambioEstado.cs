namespace dsi_ppai_ivr_g8.Entities;

public class CambioEstado
{
    private string fechaHoraInicio;
    private Estado estado;

    public CambioEstado(string fechaHoraInicio, Estado estado)
    {
        this.fechaHoraInicio = fechaHoraInicio;
        this.estado = estado;
    }

    public string getFechaHoraInicio(){
        return this.fechaHoraInicio;
    }

    public Boolean esEstadoInicial(){
        return estado.esIniciada();
    }

    public Boolean noEsEstadoFinalizado(){
        return estado.esFinalizada();
    }

    public string getNombreEstado(){
        return this.estado.getNombre();
    }
}
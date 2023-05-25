namespace dsi_ppai_grupo_8.Entities;

public class CambioEstado
{
    private string fechaHoraInicio;
    private Estado estado;

    public CambioEstado(string fechaHoraInicio, Estado estado)
    {
        this.fechaHoraInicio = fechaHoraInicio;
        this.estado = estado;
    }

    public Boolean esEstadoEnCurso(){
        return estado.esEnCurso();
    }

}
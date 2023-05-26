namespace dsi_ppai_ivr_g8.Entities;

public class Llamada
{
    private string descripcionOperador;
    private string detalleAccionRequerida;
    private int duracion = 0;
    private string encuestaEnviada;
    private string observacionAuditor;
    private List<CambioEstado> cambiosEstados = new List<CambioEstado>();
    private Cliente cliente;
    private List<OpcionLlamada> opcionSeleccionada = new List<OpcionLlamada>();
    private List<SubOpcionLlamada> subOpcionSeleccionada = new List<SubOpcionLlamada>();

    public Llamada(string descripcionOperador, string detalleAccionRequerida, string encuestaEnviada, string observacionAuditor, Cliente cliente)
    {
        this.descripcionOperador = descripcionOperador;
        this.detalleAccionRequerida = detalleAccionRequerida;
        this.encuestaEnviada = encuestaEnviada;
        this.observacionAuditor = observacionAuditor;
        this.cliente = cliente;
    }

    public void calcularDuracion()
    {
        DateTime fechaHoraIniciada = new DateTime();
        DateTime fechaHoraFinalizada = new DateTime();

        foreach (CambioEstado cambio in cambiosEstados)
        {
            if (cambio.esEstadoInicial())
            {
                fechaHoraIniciada = cambio.getFechaHoraInicio();
            }
            if (cambio.esEstadoFinalizada())
            {
                fechaHoraFinalizada = cambio.getFechaHoraInicio();
            }
        }

        TimeSpan duracion = fechaHoraFinalizada - fechaHoraIniciada;

        this.duracion = (int)duracion.TotalMinutes;
    }

    // Que tiene que retornar
    public bool esDePeriodo(DateTime fechaInicio, DateTime fechaFinal)
    {
        DateTime fechaHoraIniciada = new DateTime();
        DateTime fechaHoraFinalizada = new DateTime();

        foreach (CambioEstado cambio in cambiosEstados)
        {
            if (cambio.esEstadoInicial())
            {
                fechaHoraIniciada = cambio.getFechaHoraInicio();
            }
            if (cambio.esEstadoFinalizada())
            {
                fechaHoraFinalizada = cambio.getFechaHoraInicio();
            }
        }

        return fechaHoraIniciada.CompareTo(fechaInicio) >= 0 && fechaHoraFinalizada.CompareTo(fechaFinal) <= 0;
    }

    public int getDuracion()
    {
        return this.duracion;
    }

    public string getNombreClienteDeLlamada()
    {
        return cliente.getNombreCompleto();
    }

    // Que tiene que retornar (creo que para este caso de uso no aplica)
    public string getRespuesta()
    {
        return "";
    }

    public void setDescripcionOperador(string descripcionOperador)
    {
        this.descripcionOperador = descripcionOperador;
    }

    public void setDuracion(int duracion)
    {
        this.duracion = duracion;
    }

    public void setEstadoActual(CambioEstado cambioEstado)
    {
        this.cambiosEstados.Add(cambioEstado);
    }

    // Funcion falta realizar (es la misma funcion del anterior)
    public void newCambioDeEstado()
    {

    }

    public void setOpcion(OpcionLlamada opcion)
    {
        this.opcionSeleccionada.Add(opcion);
    }

    public void setSubOpcion(SubOpcionLlamada subOpcion)
    {
        this.subOpcionSeleccionada.Add(subOpcion);
    }
}
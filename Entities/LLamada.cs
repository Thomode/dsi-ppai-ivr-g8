namespace dsi_ppai_ivr_g8.Entities;

public class Llamada
{
    private string descripcionOperador = "";
    private string detalleAccionRequerida = "";
    private int duracion = 0;
    private List<CambioEstado> cambiosEstados = new List<CambioEstado>();
    private Cliente cliente;
    private OpcionLlamada opcionSeleccionada;
    private List<SubOpcionLlamada> subOpcionSeleccionada = new List<SubOpcionLlamada>();
    private CategoriaLlamada categoriaLlamada;

    public Llamada(Cliente cliente)
    {
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
        this.opcionSeleccionada = opcion;
    }

    public void setSubOpcion(SubOpcionLlamada subOpcion)
    {
        this.subOpcionSeleccionada.Add(subOpcion);
    }

    public bool esEstadoInicial()
    {   
        bool esInicial = false;

        foreach( CambioEstado cambio in cambiosEstados)
        {
            if (cambio.esEstadoInicial())
            {
                esInicial = true;
                break;
            }
        }

        return esInicial;
    }

    public bool esEstadoFinalizada()
    {   
        bool esFinalizada = false;

        foreach( CambioEstado cambio in cambiosEstados)
        {
            if (cambio.esEstadoFinalizada())
            {
                esFinalizada = true;
                break;
            }
        }

        return esFinalizada;
    }

    public void setCategoriaLlamada(CategoriaLlamada categoria)
    {
        this.categoriaLlamada = categoria;
    }

    public CategoriaLlamada getCategoriaLlamada()
    {
        return this.categoriaLlamada;
    }

    public List<SubOpcionLlamada> getSubOpcionSeleccionada()
    {
        return this.subOpcionSeleccionada;
    }

    public void setOpcionSeleccionada(OpcionLlamada opcionLlamada)
    {
        this.opcionSeleccionada = opcionLlamada;
    }
    public void setSubOpcionesSeleccionada(SubOpcionLlamada subOpcionLlamada)
    {
        this.subOpcionSeleccionada.Add(subOpcionLlamada);
    }
    public OpcionLlamada getOpcionSeleccionada()
    {
        return this.opcionSeleccionada;
    }
}
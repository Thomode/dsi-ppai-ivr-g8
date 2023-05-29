namespace dsi_ppai_ivr_g8.Entities;

public class Llamada
{
    private string descripcionOperador = "";
    private string detalleAccionRequerida = "";
    private int duracion = 0;
    private List<CambioEstado> cambiosEstados;
    private Cliente cliente;
    private OpcionLlamada opcionSeleccionada;
    private List<SubOpcionLlamada> subOpcionSeleccionada;
    private CategoriaLlamada categoriaLlamada;
    private Accion accionRequerida = null;

    public Llamada(Cliente cliente, List<CambioEstado> cambiosEstados, CategoriaLlamada categoriaLlamada, OpcionLlamada opcionSeleccionada, List<SubOpcionLlamada> subOpcionSeleccionada)
    {
        this.cliente = cliente;
        this.cambiosEstados = cambiosEstados;
        this.categoriaLlamada = categoriaLlamada;
        this.opcionSeleccionada = opcionSeleccionada;
        this.subOpcionSeleccionada = subOpcionSeleccionada;
    }

    public int calcularDuracion()
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

        return (int)duracion.TotalMinutes;
    }

    public void setDuracion(int duracion)
    {
        this.duracion = duracion;
    }

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

    public void setEstadoActual(CambioEstado cambioEstado)
    {
        this.cambiosEstados.Add(cambioEstado);
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

        foreach (CambioEstado cambio in cambiosEstados)
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

        foreach (CambioEstado cambio in cambiosEstados)
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
    public void setSubOpcionesSeleccionada(List<SubOpcionLlamada> subOpcionSeleccionada)
    {
        this.subOpcionSeleccionada = subOpcionSeleccionada;
    }
    public OpcionLlamada getOpcionSeleccionada()
    {
        return this.opcionSeleccionada;
    }

    public Cliente getCliente()
    {
        return this.cliente;
    }

    public Accion getAccionRequerida()
    {
        return this.accionRequerida;
    }

    public void setAccionRequerida(Accion accionRequerida)
    {
        this.accionRequerida = accionRequerida;
    }
}
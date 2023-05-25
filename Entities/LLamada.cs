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

    // Como calcular la duracion
    public int calcularDuracion()
    {
        return 0;
    }

    // Que tiene que retornar
    public Boolean esDeDuracion()
    {
        return true;
    }

    public int getDuracion()
    {
        return this.duracion;
    }

    public string getNombreClienteDeLlamada()
    {
        return cliente.getNombreCompleto();
    }

    // Que tiene que retornar?
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

    // Funcion falta realizar
    public void setEstadoActual()
    {

    }

    // Funcion falta realizar
    public void newCambioDeEstado()
    {

    }

    // Funcion falta realizar
    public void setOpcion()
    {

    }

    // Funcion falta realizar
    public void setSubOpcion()
    {

    }
}
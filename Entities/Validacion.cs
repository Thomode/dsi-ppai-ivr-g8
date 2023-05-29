namespace dsi_ppai_ivr_g8.Entities;

public class Validacion
{
    private string audioMensajeValidacion;
    private string nombre;
    private int nroOrden;
    private List<OpcionValidacion> opcionValidacion;

    public Validacion(string audioMensajeValidacion, string nombre, int nroOrden, List<OpcionValidacion> opcionValidacion)
    {
        this.audioMensajeValidacion = audioMensajeValidacion;
        this.nombre = nombre;
        this.nroOrden = nroOrden;
        this.opcionValidacion = opcionValidacion;
    }

    public string getAudioMensajeValidacion()
    {
        return this.audioMensajeValidacion;
    }

    public string getMensajeValidacion()
    {
        return this.nombre;
    }

    public string getNombre(){
        return this.nombre;
    }

    // Que tiene que retornar
    public string getValidacion()
    {
        return "";
    }

    public int getNroOrden()
    {
        return this.nroOrden;
    }
    public void setOpcionValidacion(List<OpcionValidacion> opcionValidacion)
    {
        this.opcionValidacion = opcionValidacion;
    }

    public List<OpcionValidacion> getOpcionValidacion()
    {
        return this.opcionValidacion;
    }
}
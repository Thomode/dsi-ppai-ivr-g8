namespace dsi_ppai_ivr_g8.Entities;

public class Validacion
{
    private string audioMensajeValidacion;
    private string nombre;
    private int nroOrden;

    public Validacion(string audioMensajeValidacion, string nombre, int nroOrden)
    {
        this.audioMensajeValidacion = audioMensajeValidacion;
        this.nombre = nombre;
        this.nroOrden = nroOrden;
    }

    public string getAudioMensajeValidacion()
    {
        return this.audioMensajeValidacion;
    }

    public string getMensajeValidacion()
    {
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
}
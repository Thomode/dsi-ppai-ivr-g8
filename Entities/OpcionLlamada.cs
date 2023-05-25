namespace dsi_ppai_ivr_g8.Entities;

public class OpcionLlamada
{
    private string audioMensajeOpciones;
    private string mensajeSubOpciones;
    private string nombre;
    private int nroOrden;
    private List<SubOpcionLlamada> subOpcionLlamada = new List<SubOpcionLlamada>();
    private List<Validacion> validacionRequerida = new List<Validacion>();

    public OpcionLlamada(string audioMensajeOpciones, string mensajeSubOpciones, string nombre, int nroOrden)
    {
        this.audioMensajeOpciones = audioMensajeOpciones;
        this.mensajeSubOpciones = mensajeSubOpciones;
        this.nombre = nombre;
        this.nroOrden = nroOrden;
    }

    public string getAudioMensajeOpciones()
    {
        return this.audioMensajeOpciones;
    }

    public string getDescripcionConSubOpcion()
    {
        return this.mensajeSubOpciones;
    }

    // Que tiene que retornar?
    public string getOpcion()
    {
        return "";
    }

    public string getNombre()
    {
        return this.nombre;
    }

}
namespace dsi_ppai_ivr_g8.Entities;

public class CategoriaLlamada
{
    private string audioMensajeOpciones;
    private string mensajeOpciones;
    private string nombre;
    private int nroOrden;

    public CategoriaLlamada(string audioMensajeOpciones, string mensajeOpciones, string nombre, int nroOrden)
    {
        this.audioMensajeOpciones = audioMensajeOpciones;
        this.mensajeOpciones = mensajeOpciones;
        this.nombre = nombre;
        this.nroOrden = nroOrden;
    }

    public string getAudioMensajeOpciones()
    {
        return this.audioMensajeOpciones;
    }

    public string getNombre()
    {
        return this.nombre;
    }
}
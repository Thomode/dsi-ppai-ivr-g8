namespace dsi_ppai_ivr_g8.Entities;

public class OpcionLlamada
{
    private string audioMensajeOpciones;
    private string mensajeSubOpciones;
    private string nombre;
    private int nroOrden;
    private List<SubOpcionLlamada> subOpcionLlamada;
    private List<Validacion> validacionRequerida = new List<Validacion>();

    public OpcionLlamada(string audioMensajeOpciones, string mensajeSubOpciones, string nombre, int nroOrden, List<SubOpcionLlamada> subOpcionLlamada)
    {
        this.audioMensajeOpciones = audioMensajeOpciones;
        this.mensajeSubOpciones = mensajeSubOpciones;
        this.nombre = nombre;
        this.nroOrden = nroOrden;
        this.subOpcionLlamada = subOpcionLlamada;
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

    public void setSubOpcion(List<SubOpcionLlamada> subOpcion)
    {
        this.subOpcionLlamada = subOpcion;
    }

    public List<string> getNombreSubOpciones()
    {   
        List<string> nombreSubOpciones = new List<string>();

        foreach(SubOpcionLlamada subOpcion in subOpcionLlamada)
        {
            nombreSubOpciones.Add(subOpcion.getNombre());
        }

        return nombreSubOpciones;
    }
}
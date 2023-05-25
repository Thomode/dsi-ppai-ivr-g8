namespace dsi_ppai_ivr_g8.Entities;

public class SubOpcionLlamada
{
    private string nombre;
    private int nroOrden;
    private List<Validacion> validacionRequerida = new List<Validacion>();

    public SubOpcionLlamada(string nombre, int nroOrden)
    {
        this.nombre = nombre;
        this.nroOrden = nroOrden;
    }

    public bool esNro(int nro)
    {
        return this.nroOrden == nro;
    }

    public string getNombre()
    {
        return this.nombre;
    }

    // Que tiene que retornar?
    public string getValidaciones()
    {
        return "";
    }

    // Que tiene que retornar?
    public string getSubOpcion()
    {
        return "";
    }
}
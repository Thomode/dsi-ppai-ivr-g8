namespace dsi_ppai_ivr_g8.Entities;

public class Accion 
{
    private string descripcion;

    public Accion(string descripcion)
    {
        this.descripcion = descripcion;
    }

    public string getDescripcion()
    {
        return this.descripcion;
    }
}
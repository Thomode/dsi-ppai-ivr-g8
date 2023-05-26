namespace dsi_ppai_ivr_g8.Entities;

public class OpcionValidacion
{
    private bool correcta;
    private string descripcion;

    public OpcionValidacion(bool correcta, string descripcion)
    {
        this.correcta = correcta;
        this.descripcion = descripcion;
    }

    public bool esCorrecta(string datoAValidar)
    {
        return this.descripcion == datoAValidar;
    }

    public string getDescripcion()
    {
        return this.descripcion;
    }
}
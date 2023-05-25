namespace dsi_ppai_ivr_g8.Entities;

public class InformacionCliente
{
    private string datoAValidar;
    private Validacion validacion;

    public InformacionCliente(string datoAValidar, Validacion validacion)
    {
        this.datoAValidar = datoAValidar;
        this.validacion = validacion;
    }

    public bool esInformacionCorrecta(string dato)
    {
        return this.datoAValidar == dato;
    }

    public bool esValidacion()
    {
        return true;
    }
}
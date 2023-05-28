namespace dsi_ppai_ivr_g8.Entities;

public class InformacionCliente
{
    private string datoAValidar;
    private Validacion validacion;
    private OpcionValidacion opcionCorrecta;

    public InformacionCliente(string datoAValidar, Validacion validacion, OpcionValidacion opcionCorrecta = null)
    {
        this.datoAValidar = datoAValidar;
        this.validacion = validacion;
        this.opcionCorrecta = opcionCorrecta;
    }

    public bool esInformacionCorrecta(string dato)
    {
        return opcionCorrecta != null && opcionCorrecta.esCorrecta() && opcionCorrecta.getDescripcion() == dato;
    }

    public bool esValidacion()
    {
        return true;
    }

    public Validacion getValidacion()
    {
        return this.validacion;
    }

    public OpcionValidacion getOpcionCorrecta()
    {
        return this.opcionCorrecta;
    }
}
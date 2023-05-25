namespace dsi_ppai_ivr_g8.Entities;

public class InformacionCliente 
{
    private string datoAValidar;
    public InformacionCliente(string datoAValidar)
    {
        this.datoAValidar = datoAValidar;
    }

    public Boolean esInformacionCorrecta(string dato)
    {
        return this.datoAValidar == dato;
    }

    public Boolean esValidacion(){
        return true;
    }
}
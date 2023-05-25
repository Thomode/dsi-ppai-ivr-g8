namespace dsi_ppai_ivr_g8.Entities;

public class Cliente
{
    private int dni;
    private string nombreCompleto;
    private int nroCelular;
    private List<InformacionCliente> info = new List<InformacionCliente>();

    public Cliente(int dni, string nombreCompleto, int nroCelular)
    {
        this.dni = dni;
        this.nombreCompleto = nombreCompleto;
        this.nroCelular = nroCelular;
    }

    public string getNombreCompleto()
    {
        return this.nombreCompleto;
    }

    public bool esCliente(int dni)
    {
        return this.dni == dni;
    }

    public bool esInformacionCorrecta(string dato)
    {
        bool esInformacionCorrecta = false;

        foreach (InformacionCliente informacion in info)
        {
            if (informacion.esInformacionCorrecta(dato))
            {
                esInformacionCorrecta = true;
                break;
            }
        }
        return esInformacionCorrecta;
    }
}
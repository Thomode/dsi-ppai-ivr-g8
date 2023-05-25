namespace dsi_ppai_ivr_g8.Entities;

public class Estado
{
    private string nombre;

    public Estado(string nombre)
    {
        this.nombre = nombre;
    }

    public string getNombre()
    {
        return this.nombre;
    }

    public bool esIniciada()
    {
        return this.nombre == "Iniciada";
    }
    public bool esFinalizada()
    {
        return this.nombre == "Finalizada";
    }

    public bool esEstadoEnCurso()
    {
        return this.nombre == "EnCurso";
    }

    public bool esEstadoCancelado()
    {
        return this.nombre == "Cancelado";
    }
}
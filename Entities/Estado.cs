namespace dsi_ppai_ivr_g8.Entities;

public class Estado
{   
    private string nombre;
    public Estado(string nombre)
    {
        this.nombre = nombre;
    }

    public string getNombre(){
        return this.nombre;
    }

    public Boolean esIniciada(){
        return this.nombre == "Iniciada";
    }
    public Boolean esFinalizada(){
        return this.nombre == "Finalizada";
    }

    public Boolean esEstadoEnCurso(){
        return this.nombre == "EnCurso";
    }
    
    public Boolean esEstadoCancelado(){
        return this.nombre == "Cancelado";
    }    
}
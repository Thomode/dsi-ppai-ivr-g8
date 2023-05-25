namespace dsi_ppai_grupo_8.Models;

public class Estado
{   
    private string nombre;
    public Estado(string nombre)
    {
        this.nombre = nombre;
    }

    public Boolean esEnCurso(){
        return this.nombre == "EnCurso";
    }
    
    public string getNombre(){
        return this.nombre;
    }
}
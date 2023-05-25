namespace dsi_ppai_grupo_8.Models;

public class Llamada 
{
    private string nombre;
    private List<CambioEstado> cambiosEstados;

    public Llamada(string nombre, List<CambioEstado> cambioEstados)
    {
        this.nombre = nombre;
        this.cambiosEstados = cambioEstados;
    }
}
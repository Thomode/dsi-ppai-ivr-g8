using Microsoft.AspNetCore.Mvc;
using dsi_ppai_grupo_8.Models;

namespace dsi_ppai_grupo_8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GestorRegistroDeRespuestaController : ControllerBase
{
    private List<Llamada> llamadas = new List<Llamada> {
        /*
        new Llamada("tomas1"),
        new Llamada("tomas2"),
        new Llamada("tomas3"),
        new Llamada("tomas4")
        */
    };
    public GestorRegistroDeRespuestaController()
    {

    }

    [HttpGet]
    public Llamada mostrarDatosLlamadas()
    {
        return buscarLlamada();
    }
    
    [NonAction]
    public Llamada buscarLlamada()
    {
        Random random = new Random();
        int index = random.Next(llamadas.Count);

        return llamadas[index];
    }
    
    [NonAction]
    public string getFechaHoraActual()
    {
        return DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
    }
}
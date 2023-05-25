using Microsoft.AspNetCore.Mvc;
using dsi_ppai_ivr_g8.Entities;

namespace dsi_ppai_ivr_g8.Controllers;

[ApiController]
[Route("[controller]")]
public class GestorRegistroDeRespuestaController : ControllerBase
{
    private List<Llamada> llamadas = new List<Llamada>
    {
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
    public void tomarOpcionOperador()
    {

    }

    [NonAction]
    public Llamada buscarLlamada()
    {
        Random random = new Random();
        int index = random.Next(llamadas.Count);

        return llamadas[index];
    }

    [NonAction]
    public void asignarEstadoEnCurso()
    {

    }

    [NonAction]
    public string getFechaHoraActual()
    {
        return DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
    }

    [NonAction]
    public void buscarValidacionesSubOpcion()
    {

    }

    [NonAction]
    public void ordenarValidacion()
    {

    }

    [NonAction]
    public void ingresarRespuestasValidaciones()
    {

    }

    [NonAction]
    public void tomarRespuestaValidacion()
    {

    }

    [NonAction]
    public void validarRespuestaIngresada()
    {

    }

    [NonAction]
    public void ingresarDescripcionRespuesta()
    {

    }

    [NonAction]
    public void tomarDescripcionRespuesta()
    {

    }

    [NonAction]
    public void confirmarOperacion()
    {

    }

    [NonAction]
    public void registrarAccion()
    {

    }

    [NonAction]
    public void registrarFinalizacionLlamada()
    {

    }

    [NonAction]
    public void asignarEstadoFinalizado()
    {

    }

    [NonAction]
    public void finCU()
    {

    }
}
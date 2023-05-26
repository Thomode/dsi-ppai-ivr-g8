using Microsoft.AspNetCore.Mvc;
using dsi_ppai_ivr_g8.Entities;

namespace dsi_ppai_ivr_g8.Controllers;

[ApiController]
[Route("[controller]")]
public class GestorRegistroDeRespuestaController : ControllerBase
{
    private Cliente cliente;
    private List<Llamada> llamadas;
    private Llamada llamada;
    private Llamada llamadaCliente;
    private Estado estado;
    private CambioEstado cambioEstado;

    public GestorRegistroDeRespuestaController()
    {
        this.estado = new Estado("esInicializada");
        this.cambioEstado = new CambioEstado(DateTime.Now, estado);

        this.cliente = new Cliente(29232323, "Jose Pereyra", 351232324);
        this.llamada = new Llamada("", "", "", "", this.cliente);
        this.llamada.setEstadoActual(this.cambioEstado);

        this.llamadas = new List<Llamada> {
            this.llamada
        };

        this.tomarOpcionOperador();
    }

    [HttpGet]
    public dynamic mostrarDatosLlamadas()
    {
        //Estado estado = buscarEstado();
        return new {
            nombreEstado = this.estado.getNombre()
        };
    }

    [NonAction]
    public void tomarOpcionOperador()
    {
        this.buscarLlamada();
    }

    [NonAction]
    public void buscarLlamada()
    {
        foreach(Llamada llamada in llamadas)
        {
            
        }
    }

    [NonAction]
    public void asignarEstadoEnCurso()
    {

    }

    [NonAction]
    public DateTime getFechaHoraActual()
    {
        return DateTime.Now;
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
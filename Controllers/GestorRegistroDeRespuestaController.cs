using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    private DateTime fechaHoraActual;
    private List<Estado> estados = new List<Estado>{
        new Estado("Iniciada"),
        new Estado("EnCurso"),
        new Estado("Finalizada"),
        new Estado("Cancelada")
    };

    public GestorRegistroDeRespuestaController()
    {
        this.estado = new Estado("Iniciada");
        this.cambioEstado = new CambioEstado(DateTime.Now, estado);

        OpcionValidacion opcionValidacion1 = new OpcionValidacion(true, "1991");
        OpcionValidacion opcionValidacion2 = new OpcionValidacion(false, "1997");
        OpcionValidacion opcionValidacion3 = new OpcionValidacion(false, "1999");

        Validacion validacion1 = new Validacion("Audio Validacion", "validacion1", 1);
        validacion1.setOpcionValidacion(opcionValidacion1);
        validacion1.setOpcionValidacion(opcionValidacion2);
        validacion1.setOpcionValidacion(opcionValidacion3);

        Validacion validacion2 = new Validacion("Audio Validacion", "validacion2", 1);
        validacion2.setOpcionValidacion(opcionValidacion1);
        validacion2.setOpcionValidacion(opcionValidacion2);
        validacion2.setOpcionValidacion(opcionValidacion3);

        SubOpcionLlamada subOpcionLlamada1 = new SubOpcionLlamada("1.SubOpcion", 1);
        subOpcionLlamada1.setValidacion(validacion1);

        SubOpcionLlamada subOpcionLlamada2 = new SubOpcionLlamada("2.SubOpcion", 2);
        subOpcionLlamada2.setValidacion(validacion2);

        OpcionLlamada opcionLlamada = new OpcionLlamada("Audio opcion", "Mensaje opcion", "opcion1", 1);
        opcionLlamada.setSubOpcion(subOpcionLlamada1);
        opcionLlamada.setSubOpcion(subOpcionLlamada2);

        CategoriaLlamada categoriaLlamada = new CategoriaLlamada("Audio Categoria", "Mensaje Categoria", "Categoria1", 1);
        categoriaLlamada.setOpcionLlamada(opcionLlamada);

        this.cliente = new Cliente(29232323, "Jose Pereyra", 351232324);
        this.llamada = new Llamada(this.cliente);
        this.llamada.setCategoriaLlamada(categoriaLlamada);
        this.llamada.setEstadoActual(this.cambioEstado);
        this.llamada.setOpcionSeleccionada(opcionLlamada);
        this.llamada.setSubOpcionesSeleccionada(subOpcionLlamada2);
        this.llamada.setSubOpcionesSeleccionada(subOpcionLlamada1);
        

        this.llamadas = new List<Llamada> {
            this.llamada
        };

        this.tomarOpcionOperador();
    }

    [HttpGet]
    public dynamic mostrarDatosLlamadas()
    {
        string nombreCliente = this.llamada.getNombreClienteDeLlamada();
        string categoria = this.llamada.categoriaLlamada.getNombre();
        string opcion = this.llamada.categoriaLlamada.getNombreOpcion();
        //List<string> subopciones = this.llamada.categoriaLlamada.getNombreSubOpciones();

        var subOpciones = this.buscarSubOpcionYValidaciones();
        var subOpcionesOrdenadas = this.ordenarSubOpciones(subOpciones);

        return new
        {
            nombreCliente = nombreCliente,
            categoria = categoria,
            opcion = opcion,
            subOpciones = subOpcionesOrdenadas
        };
    }

    [NonAction]
    public void tomarOpcionOperador()
    {
        this.buscarLlamada();
        this.getFechaHoraActual();
        this.asignarEstadoEnCurso();
    }

    [NonAction]
    public void buscarLlamada()
    {
        foreach (Llamada llamada in llamadas)
        {
            if (llamada.esEstadoInicial() && !llamada.esEstadoFinalizada())
            {
                this.llamadaCliente = llamada;
            }
        }
    }

    [NonAction]
    public void asignarEstadoEnCurso()
    {
        Estado estadoEnCurso = new Estado("Iniciada");

        foreach (Estado estado in estados)
        {
            if (estado.esEstadoEnCurso())
            {
                estadoEnCurso = estado;
            }
        }
        CambioEstado cambio = new CambioEstado(this.fechaHoraActual, estadoEnCurso);

        this.llamadaCliente.setEstadoActual(cambio);
    }

    [NonAction]
    public void getFechaHoraActual()
    {
        this.fechaHoraActual = DateTime.Now;
    }

    [NonAction]
    public dynamic buscarSubOpcionYValidaciones()
    {
        var subOpciones = new List<dynamic>();

        foreach (SubOpcionLlamada subOpcion in this.llamadaCliente.getSubOpcionSeleccionada())
        {
            var validaciones = new List<dynamic>();

            foreach (Validacion validacionRequerida in subOpcion.getValidacionRequerida())
            {
                var opcionesV = new List<dynamic>();

                foreach (OpcionValidacion opcionValidacion in validacionRequerida.getOpcionValidacion())
                {
                    opcionesV.Add(new
                    {
                        descripcion = opcionValidacion.getDescripcion()
                    });
                }

                validaciones.Add(new
                {
                    nombre = validacionRequerida.getMensajeValidacion(),
                    nroOrden = validacionRequerida.getNroOrden(),
                    opcionesValidacion = opcionesV
                });
            }
            subOpciones.Add(new
            {
                nombre = subOpcion.getNombre(),
                nroOrden = subOpcion.getNroOrden(),
                validaciones = validaciones
            });

        }
        return subOpciones;
    }

    [NonAction]
    public dynamic ordenarSubOpciones(List<dynamic> subOpcionesYValidaciones)
    {
        return subOpcionesYValidaciones.OrderBy(sub => sub.nroOrden).ToArray();
    }

    [NonAction]
    public void ingresarRespuestasValidaciones()
    {

    }

    [HttpPost]
    public void tomarRespuestaValidacion(dynamic validacion)
    {
        string nombreSubOpcion = validacion.nombreSubOpcion;
        string nombreValidacion = validacion.nombreValidacion;
        string descripcionOpcionV = validacion.descripcionOpcionV;

        this.validarRespuestaIngresada(nombreSubOpcion, nombreValidacion, descripcionOpcionV);
    }

    [NonAction]
    public void validarRespuestaIngresada(string nombreSubOpcion, string nombreValidacion, string descripcionOpcionV)
    {
        foreach(SubOpcionLlamada subOpcion in llamada.getSubOpcionSeleccionada())
        {
            if (subOpcion.getNombre() == nombreSubOpcion)
            {
                foreach(Validacion validacion in subOpcion.getValidacionRequerida())
                {
                    if(validacion.getNombre() == nombreValidacion)
                    {
                        
                    }
                }
            }
        }
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
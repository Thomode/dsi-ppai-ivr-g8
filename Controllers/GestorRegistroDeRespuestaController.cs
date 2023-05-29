using Microsoft.AspNetCore.Mvc;
using dsi_ppai_ivr_g8.Entities;
using dsi_ppai_ivr_g8.Models;

namespace dsi_ppai_ivr_g8.Controllers;

[ApiController]
[Route("api")]
public class GestorRegistroDeRespuestaController : ControllerBase
{
    private List<Llamada> llamadas;
    private Llamada llamadaCliente;
    private DateTime fechaHoraActual;
    private List<Estado> estados = new List<Estado> {
        new Estado("Iniciada"),
        new Estado("EnCurso"),
        new Estado("Finalizada"),
        new Estado("Cancelada")
    };
    private List<Accion> acciones = new List<Accion> {
        new Accion("Accion1"),
        new Accion("Accion2"),
        new Accion("Accion3")
    };
    private string descripcionOperador = "";
    private string accionRequerida = "";

    public GestorRegistroDeRespuestaController()
    {
        this.tomarOpcionOperador();
        this.buscarLlamada();
        this.getFechaHoraActual();
        this.asignarEstadoEnCurso();
    }

    [HttpGet]
    [Route("datos-llamada")]
    public dynamic mostrarDatosLlamada()
    {
        string nombreCliente = this.llamadaCliente.getNombreClienteDeLlamada();
        string categoria = this.llamadaCliente.getCategoriaLlamada().getNombre();
        string opcion = this.llamadaCliente.getOpcionSeleccionada().getNombre();

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
        Estado estado = new Estado("Iniciada");
        CambioEstado cambioEstado = new CambioEstado(DateTime.Now, estado);

        OpcionValidacion opcionValidacion1 = new OpcionValidacion(true, "1991");
        OpcionValidacion opcionValidacion2 = new OpcionValidacion(false, "1997");
        OpcionValidacion opcionValidacion3 = new OpcionValidacion(false, "1999");

        Validacion validacion1 = new Validacion("Audio Validacion", "validacion1", 1,
        new List<OpcionValidacion> {
            opcionValidacion1, opcionValidacion2, opcionValidacion3
        });

        Validacion validacion2 = new Validacion("Audio Validacion", "validacion2", 1,
        new List<OpcionValidacion> {
            opcionValidacion1, opcionValidacion2, opcionValidacion3
        });

        SubOpcionLlamada subOpcionLlamada1 = new SubOpcionLlamada("1.SubOpcion", 1,
        new List<Validacion> {
            validacion1
        });

        SubOpcionLlamada subOpcionLlamada2 = new SubOpcionLlamada("2.SubOpcion", 2,
        new List<Validacion> {
            validacion2
        });

        OpcionLlamada opcionLlamada = new OpcionLlamada("Audio opcion", "Mensaje opcion", "opcion1", 1,
        new List<SubOpcionLlamada> {
            subOpcionLlamada1, subOpcionLlamada2
        });

        CategoriaLlamada categoriaLlamada = new CategoriaLlamada("Audio Categoria", "Mensaje Categoria", "Categoria1", 1);

        InformacionCliente info1 = new InformacionCliente("1991", validacion1, opcionValidacion1);
        InformacionCliente info2 = new InformacionCliente("1997", validacion1);
        InformacionCliente info3 = new InformacionCliente("1999", validacion1);

        InformacionCliente info4 = new InformacionCliente("1991", validacion2, opcionValidacion1);
        InformacionCliente info5 = new InformacionCliente("1997", validacion2);
        InformacionCliente info6 = new InformacionCliente("1999", validacion2);

        Cliente cliente = new Cliente(29232323, "Jose Pereyra", 351232324,
            new List<InformacionCliente> { info1, info2, info3, info4, info5, info6 }
        );

        Llamada llamada = new Llamada(cliente, new List<CambioEstado> { cambioEstado }, categoriaLlamada, opcionLlamada,
        new List<SubOpcionLlamada> {
            subOpcionLlamada1, subOpcionLlamada2
        });

        this.llamadas = new List<Llamada> {
            llamada
        };
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
    [Route("validacion")]
    public bool tomarRespuestaValidacion([FromBody] ValidacionBody validacion)
    {
        String descripcion = validacion.descripcion;
        return this.validarRespuestaIngresada(descripcion);
    }

    [NonAction]
    public bool validarRespuestaIngresada(string descripcionOpcionV)
    {
        return this.llamadaCliente.getCliente().esInformacionCorrecta(descripcionOpcionV);
    }

    [NonAction]
    public void ingresarDescripcionRespuesta()
    {

    }

    [HttpPost]
    [Route("descripcion-operador")]
    public bool tomarDescripcionRespuesta([FromBody] ValidacionBody operador)
    {
        bool esValido = false;

        if (operador.descripcion != "")
        {
            this.descripcionOperador = operador.descripcion;
            esValido = true;
        }

        return esValido;
    }

    [HttpGet]
    [Route("acciones")]
    public List<string> mostrarAcciones()
    {
        List<string> acciones = new List<string>();

        foreach (Accion accion in this.acciones)
        {
            acciones.Add(accion.getDescripcion());
        }

        return acciones;
    }

    [NonAction]
    public void registrarAccion()
    {

    }

    [HttpPost]
    [Route("accion-requerida")]
    public bool tomarAccionRequerida([FromBody] ValidacionBody accion)
    {
        bool esValido = false;

        if (accion.descripcion != "")
        {
            this.accionRequerida = accion.descripcion;
            esValido = true;
        }

        return esValido;
    }


    [NonAction]
    public void confirmarOperacion()
    {

    }

    [HttpPost]
    [Route("confirmacion")]
    public bool tomarConfirmacionOperador([FromBody] ConfirmacionBody confirmacion)
    {
        bool registroRealizado = false;

        if (confirmacion.confirmacion)
        {
            this.registrarFinalizacionLlamada();
            registroRealizado = true;
        }

        return registroRealizado;
    }

    [NonAction]
    public void registrarFinalizacionLlamada()
    {
        this.llamadaCliente.setDescripcionOperador(this.descripcionOperador);

        Accion accionRequerida = new Accion(this.accionRequerida);
        this.llamadaCliente.setAccionRequerida(accionRequerida);

        this.getFechaHoraActual();
        this.asignarEstadoFinalizado();

        int duracion = this.llamadaCliente.calcularDuracion();
        this.llamadaCliente.setDuracion(duracion);
    }

    [NonAction]
    public void asignarEstadoFinalizado()
    {
        Estado estadoEnCurso = new Estado("Iniciada");

        foreach (Estado estado in estados)
        {
            if (estado.esFinalizada())
            {
                estadoEnCurso = estado;
            }
        }
        CambioEstado cambio = new CambioEstado(this.fechaHoraActual, estadoEnCurso);

        this.llamadaCliente.setEstadoActual(cambio);
    }

    [NonAction]
    public void finCU()
    {

    }
}
using AutoMapper;
using GCO.Datos;
using GCO.Negocio;
using GCO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GCO.WebApi.Controllers
{
    [RoutePrefix("api/ordenDePago")]
    public class GCO_Orden_De_PagoController : ApiController
    {
        [Route("")]
        public List<GCO_Orden_De_PagoModel> GetAll()
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<GCO_Estado, GCO_EstadoModel>();
                });

                var items = from b in LNOrdenDePago.ListarTodos()
                            select new GCO_Orden_De_PagoModel()
                            {
                                idOrdenDePago = b.idOrdenDePago,
                                precioTotOP = b.precioTotOP,
                                descuentoOP = b.descuentoOP,
                                fechaRegOP = b.fechaRegOP,
                                fechaModOP = b.fechaModOP,
                                idEstado = b.idEstado,
                                GCO_Estado = Mapper.Map<GCO_EstadoModel>(b.GCO_Estado)
                            };
                return items.ToList();
            }
            catch (System.Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message),
                    ReasonPhrase = "There was an error processing the request"
                };
                throw new HttpResponseException(resp);
            }

        }

        [Route("{id}")]
        public IHttpActionResult GetItem(string id)
        {
            var b = LNOrdenDePago.Obtener(Guid.Parse(id));
            if (b == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No item with ID = {0}", id)),
                    ReasonPhrase = "Items ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else
            {
                var newItem = new GCO_Orden_De_PagoModel()
                {
                    idOrdenDePago = b.idOrdenDePago,
                    precioTotOP = b.precioTotOP,
                    descuentoOP = b.descuentoOP,
                    fechaRegOP = b.fechaRegOP,
                    fechaModOP = b.fechaModOP,
                    idEstado = b.idEstado
                };
                return Ok(newItem);
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] GCO_Orden_De_PagoModel b)
        {
            if (b == null)
            {
                return BadRequest();
            }

            var p = new GCO_Orden_De_Pago();
            p.idOrdenDePago = b.idOrdenDePago;
            p.precioTotOP = b.precioTotOP;
            p.descuentoOP = b.descuentoOP;
            p.fechaRegOP = b.fechaRegOP;
            p.fechaModOP = b.fechaModOP;
            p.idEstado = b.idEstado;

            LNOrdenDePago.add(p);
            return Ok(b);
        }

        
    }
}

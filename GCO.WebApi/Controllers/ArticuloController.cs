using GCO.Datos;
using GCO.Negocio;
using GCO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

namespace GCO.WebApi.Controllers
{
    [RoutePrefix("api/articulo")]
    public class ArticuloController : ApiController
    {
        [Route("")]
        public List<ArticuloModel> GetAll()
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Articulo, ArticuloModel>();
                    cfg.CreateMap<ICollection<GCO_Solicitud_De_Insumos_Detalle>, ICollection<GCO_Solicitud_De_Insumos_DetalleModel>>();
                });

                var items = from b in LNArticulo.ListarTodos()
                            select new ArticuloModel()
                            {
                                codArticulo = b.codArticulo,
                                nombre = b.nombre,
                                descripcion = b.descripcion,
                                unidadMedida = b.unidadMedida,
                                TipoArticulo = b.TipoArticulo,
                                costosxUM = b.costosxUM,
                                fechaRegArticulo = b.fechaRegArticulo,
                                fechaModArticulo = b.fechaModArticulo,
                                GCO_Solicitud_De_Insumos_Detalle = Mapper.Map<ICollection<GCO_Solicitud_De_Insumos_DetalleModel>>(b.GCO_Solicitud_De_Insumos_Detalle)
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
        public IHttpActionResult GetItem(int id)
        {
            var b = LNArticulo.Obtener(id);
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
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Articulo, ArticuloModel>();
                    cfg.CreateMap<ICollection<GCO_Solicitud_De_Insumos_Detalle>, ICollection<GCO_Solicitud_De_Insumos_DetalleModel>>();
                });

                var newItem = new ArticuloModel()
                {
                    codArticulo = b.codArticulo,
                    nombre = b.nombre,
                    descripcion = b.descripcion,
                    unidadMedida = b.unidadMedida,
                    TipoArticulo = b.TipoArticulo,
                    costosxUM = b.costosxUM,
                    fechaRegArticulo = b.fechaRegArticulo,
                    fechaModArticulo = b.fechaModArticulo,
                    GCO_Solicitud_De_Insumos_Detalle = Mapper.Map<ICollection<GCO_Solicitud_De_Insumos_DetalleModel>>(b.GCO_Solicitud_De_Insumos_Detalle)
                };
                return Ok(newItem);
            }
        }

    }
}

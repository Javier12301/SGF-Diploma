﻿using SGF.DATOS.Negocio;
using SGF.MODELO.Negocio;
using SGF.NEGOCIO.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class CompraBLL
    {
        private SesionBLL lSesion = SesionBLL.ObtenerInstancia;
        // Singleton de cCompra
        private static CompraBLL _instancia = null;
        private CompraBLL() { }
        public static CompraBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new CompraBLL();
                return _instancia;
            }
        }

        // Manejo de Compras
        public bool RegistrarCompra(Compra oCompra, DataTable DetalleCompra)
        {
            if (oCompra != null && DetalleCompra != null)
            {
                return CompraDAO.RegistrarCompraD(oCompra, DetalleCompra);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de compras no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }

        // Obtener Folio
        public int ObtenerFolio()
        {
            return CompraDAO.ObtenerFolioD();
        }

        // Obtener compra por id
        public Compra ObtenerCompraPorID(int compraID)
        {
            if (compraID > 0)
            {
                return CompraDAO.ObtenerCompraPorIDD(compraID);
            }
            else
            {
                throw new ArgumentNullException("Se ha producido un error: el campo de compras no puede estár vacío. Por favor, asegúrese de proporcionar la información necesaria e inténtelo de nuevo. Si el problema persiste, contactar con el administrador si este error persiste.");
            }
        }
    }
}
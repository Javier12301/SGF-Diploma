using SGF.DATOS.Negocio;
using SGF.MODELO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGF.NEGOCIO.Negocio
{
    public class NegocioBLL
    {
        private static NegocioBLL _instancia = null;
        private NegocioBLL() { }
        public static NegocioBLL ObtenerInstancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new NegocioBLL();
                return _instancia;
            }
        }

        // Conteo de monedas
        public int ConteoMonedas()
        {
            return NegocioDAO.ConteoMonedas();
        }

        // Existencia de moneda
        public bool ExisteMoneda(string nombre)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                return NegocioDAO.ExisteMonedaD(nombre);
            }           
            else
            {
                throw new Exception("No se puede verificar la existencia de la moneda porque no se ha proporcionado un nombre.");
            }
        }

        // Obtener Lista de monedas disponibles en el negocio
        public List<Moneda> ObtenerMonedasDisponibles()
        {
            List<Moneda> listaMonedas = NegocioDAO.ObtenerMonedasDisponibles();
            if(listaMonedas != null)
            {
                return listaMonedas;
            }
            else
            {
                throw new Exception("Ocurrió un error al obtener las monedas o no hay monedas disponibles en el sistema, contacte con el administrador del sistema si este error persiste.");
            }
        }

        // Alta Moneda
        public bool AltaMoneda(Moneda oMoneda)
        {
            if(oMoneda != null)
            {
                return NegocioDAO.AltaMonedaD(oMoneda);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar dar de alta la moneda, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Modificar Moneda
        public bool ModificarMoneda(Moneda oMoneda)
        {
            if(oMoneda != null)
            {
                return NegocioDAO.ModificarMonedaD(oMoneda);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar modificar la moneda, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Eliminar Moneda
        public bool EliminarMoneda(int monedaID)
        {
            if(monedaID > 0)
            {
                return NegocioDAO.BajaMonedaD(monedaID);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar eliminar la moneda, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Obtener moneda por ID
        public Moneda ObtenerMonedaPorID(int monedaID)
        {
            if(monedaID > 0)
            {
                return NegocioDAO.ObtenerMonedaPorIDD(monedaID);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener la moneda, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Obtener moneda por nombre
        public Moneda ObtenerMonedaPorNombre(string nombre)
        {
            if(!string.IsNullOrEmpty(nombre))
            {
                Moneda oMoneda = NegocioDAO.ObtenerMonedaPorNombre(nombre);
                if(oMoneda != null)
                {
                    return oMoneda;
                }
                else
                {
                    throw new Exception("La moneda no existe o no se pudo obtener, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
                }
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener la moneda, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // ID de moneda en uso
        public bool MonedaEnUso(int monedaID)
        {
            if(monedaID > 0)
            {
                MODELO.Negocio.NegocioModelo oNegocio = NegocioDAO.ObtenerDatosDelNegocioD();
                if(oNegocio != null)
                {
                    if(oNegocio.moneda.MonedaID == monedaID)
                        return true;
                    else
                        return false;
                }
                else
                {
                    throw new Exception("Ocurrió un error al obtener los datos del negocio, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
                }
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener la moneda, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Impuesto
        // Obtener impuesto por ID
        public Impuesto ObtenerImpuestoPorID(int impuestoID)
        {
            if(impuestoID > 0)
            {
                return NegocioDAO.ObtenerImpuestoPorIDD(impuestoID);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener el impuesto, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Modificar impuesto
        public bool ModificarImpuesto(Impuesto oImpuesto)
        {
            if(oImpuesto != null)
            {
                return NegocioDAO.ModificarImpuestoD(oImpuesto);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar modificar el impuesto, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }

        // Obtener datos del negocio
        public NegocioModelo ObtenerDatosDelNegocio()
        {
            NegocioModelo oNegocio = NegocioDAO.ObtenerDatosDelNegocioD();
            if(oNegocio != null)
            {
                return oNegocio;
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar obtener los datos del negocio, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }

        }

        

        // Modificar datos del negocio
        public bool ModificarNegocio(NegocioModelo negocio)
        {
            if(negocio != null)
            {
                return NegocioDAO.ModificarNegocioD(negocio);
            }
            else
            {
                throw new Exception("Ocurrió un error al intentar modificar los datos del negocio, por favor intente de nuevo y si el problema persiste contacte con el administrador del sistema.");
            }
        }
    }
}

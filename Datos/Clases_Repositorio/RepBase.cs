using Entidades.Actores;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases_Repositorio
{
    public abstract class RepBase<T>
    {
        private string filename;
        private List<T> lista;
        private Dictionary<string, T> diccionario;
        private bool cargado;
        public RepBase(string filename)
        {
            this.filename = filename;
            this.lista = new List<T>();
            this.diccionario = new Dictionary<string, T>();
            this.cargado = false;
        }
        abstract protected bool agregarAlDiccionario(T entidad);
        abstract protected bool eliminarDelDiccionario(T entidad);
        
        public string Filename
        {
            get { return filename; }
            set { filename = string.IsNullOrWhiteSpace(value) ? filename : value; }
        }
        public List<T> Lista
        {
            get { return lista; }
        }
        public Dictionary<string, T> Diccionario
        {
            get { return diccionario; }
        }
        public bool agregarALista(T entidad)
        {
            if (entidad != null && !lista.Contains(entidad))
            {
                lista.Add(entidad);
                return true;
            }
            return false;
        }
        public bool eliminarDeLista(T entidad)
        {
            if (entidad != null)
            {
                return lista.Remove(entidad);
            }
            else return false;
        }
        public bool Cargado
        {
            get { return cargado; }
            set { cargado = value; }
        }
    }
}

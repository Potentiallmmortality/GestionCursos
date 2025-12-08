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
        private bool cargado;
        public RepBase(string filename)
        {
            this.filename = filename;
            this.lista = new List<T>();
            this.cargado = false;
        }
        public string Filename
        {
            get { return filename; }
            set { filename = string.IsNullOrWhiteSpace(value) ? filename : value; }
        }
        public List<T> Lista
        {
            get { return lista; }
        }
        public bool Cargado
        {
            get { return cargado; }
            set { cargado = value; }
        }
    }
}

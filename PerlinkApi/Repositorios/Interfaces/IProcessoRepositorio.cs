using PerlinkApi.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerlinkApi.Repositorios.Interfaces
{
    public interface IProcessoRepositorio
    {
        /// <summary>
        /// Recupera os Processos atribuidos às empresas
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        IEnumerable<Processo> getProcessos();
    }
}

using PerlinkApi.Entidades;
using System.Collections.Generic;

namespace PerlinkApi.Repositorios.Interfaces
{
    public interface IEmpresaRepositorio
    {
        /// <summary>
        /// Busca a entidade Empresa a partir do Cnpj informado
        /// </summary>
        /// <param name="cnpj">Cnpj da empresa</param>
        /// <returns>etorna a entidade Empresa </returns>
        Empresa getEmpresaPorCnpj(string cnpj);
        /// <summary>
        /// Busca a lista de empresas
        /// </summary>
        /// <returns>Retorna uma lista de empresas</returns>
        IEnumerable<Empresa> getEmpresas();
    }
}

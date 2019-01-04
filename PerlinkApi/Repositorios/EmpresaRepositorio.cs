using PerlinkApi.Entidades;
using PerlinkApi.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PerlinkApi.Repositorios
{
    public class EmpresaRepositorio: IEmpresaRepositorio
    {
        /// <summary>
        /// Busca a entidade Empresa a partir do Cnpj informado
        /// </summary>
        /// <param name="cnpj">Cnpj da empresa</param>
        /// <returns>etorna a entidade Empresa </returns>
        public Empresa getEmpresaPorCnpj(string cnpj)
        {
            return getEmpresas()
                .Where(w => w.Cnpj == cnpj)
                .FirstOrDefault();
        }

        /// <summary>
        /// Busca a lista de empresas
        /// </summary>
        /// <returns>Retorna uma lista de empresas</returns>
        public IEnumerable<Empresa> getEmpresas()
        {
            var listaEmpresas = new List<Empresa>();
            listaEmpresas.Add(new Empresa
            {
                Nome = "Empresa A",
                Cnpj = "00000000001",
                UF = "RJ"
            });
            listaEmpresas.Add(new Empresa
            {
                Nome = "Empresa B",
                Cnpj = "00000000002",
                UF = "SP"
            });
            return listaEmpresas;
        }
    }
}

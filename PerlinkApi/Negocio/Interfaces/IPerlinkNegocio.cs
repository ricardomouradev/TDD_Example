using PerlinkApi.Entidades;
using System.Collections.Generic;

namespace PerlinkApi.Negocio.Interfaces
{
    public interface IPerlinkNegocio
    {
        /// <summary>
        /// Calcula a soma de todos os processos ativos
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        double CalcularSomaDosProcessosAtivos();
        /// <summary>
        /// Calcula a média do valor de processos no RJ para clientes da Empresa A
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        double CalcularMediaValorProcessosRJparaClienteEmpresaA();
        /// <summary>
        /// Calcula o número de processos com valores acima de 100000
        /// </summary>
        /// <returns>Retorna um número inteiro</returns>
        int CalcularNumeroProcessosValorAcima100000();
        /// <summary>
        /// Obtem a lista de processos iniciados em setembro de 2007
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        IEnumerable<Processo> ObterListaProcessosSetembro2007();
        /// <summary>
        /// Obtem a listade processos cujo Estado pertença ao mesmo Estado do cliente
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        IEnumerable<Processo> ObterListaProcessosMesmoEstadoCliente();
        /// <summary>
        /// Obtem a lista de processos que possuam a sigla TRAB
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        IEnumerable<Processo> ObterListaProcessosContenhamSiglaTRAB();
    }
}

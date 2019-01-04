using PerlinkApi.Entidades;
using PerlinkApi.Enums;
using PerlinkApi.Negocio.Interfaces;
using PerlinkApi.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PerlinkApi.Negocio
{
    public class PerlinkNegocio : IPerlinkNegocio
    {
        private readonly IProcessoRepositorio _processoRepositorio;
        /// <summary>
        /// Construtor da classe PerlinkNegocio injetando a classe de repositório ProcessoRepositorio
        /// </summary>
        /// <param name="processoRepositorio">Classe de repositório de processos</param>
        public PerlinkNegocio(IProcessoRepositorio processoRepositorio)
        {
            _processoRepositorio = processoRepositorio;
        }
        /// <summary>
        /// Calcula a soma de todos os processos ativos
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        public double CalcularSomaDosProcessosAtivos()
        {
            var processos = _processoRepositorio.getProcessos();
            var soma = processos
                .Where(w => w.Ativo == true)
                .Sum(s => s.Valor);
            return soma;
        }

        /// <summary>
        /// Calcula a média do valor de processos no RJ para clientes da Empresa A
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        public double CalcularMediaValorProcessosRJparaClienteEmpresaA()
        {
            var processos = _processoRepositorio.getProcessos();
            var soma = processos
                .Where(w => w.Empresa.Nome == "Empresa A" && w.UF == "RJ")
                .Average(a => a.Valor);
            return soma;
        }

        /// <summary>
        /// Calcula o número de processos com valores acima de 100000
        /// </summary>
        /// <returns>Retorna um número inteiro</returns>
        public int CalcularNumeroProcessosValorAcima100000()
        {
            var processos = _processoRepositorio.getProcessos();
            var quantidade = processos
                .Where(w => w.Valor > 100000)
                .Count();
            return quantidade;
        }

        /// <summary>
        /// Obtem a lista de processos iniciados em setembro de 2007
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        public IEnumerable<Processo> ObterListaProcessosSetembro2007()
        {
            var processos = _processoRepositorio.getProcessos()
                .Where(w => w.DataInicio.Month == (int)Mes.Setembro && w.DataInicio.Year == 2007);
            return processos;
        }

        /// <summary>
        /// Obtem a listade processos cujo Estado pertença ao mesmo Estado do cliente
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        public IEnumerable<Processo> ObterListaProcessosMesmoEstadoCliente()
        {
            var processos = _processoRepositorio.getProcessos()
                .Where(w => w.UF == w.Empresa.UF);
            return processos;
        }

        /// <summary>
        /// Obtem a lista de processos que possuam a sigla TRAB
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        public IEnumerable<Processo> ObterListaProcessosContenhamSiglaTRAB()
        {
            var processos = _processoRepositorio.getProcessos()
                .Where(w => w.NumeroProcesso.ToUpper().Contains("TRAB"));
            return processos;
        }

    }
}

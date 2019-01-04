using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerlinkApi.Negocio;
using PerlinkApi.Negocio.Interfaces;
using PerlinkApi.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace PerlinkApiTestes
{
    /// <summary>
    /// Testes unitários para a Api Perlink
    /// </summary>
    [TestClass]
    public class PerlinkApiTestes
    {
        private IPerlinkNegocio api;

        /// <summary>
        /// Inicializa a API injetando as respectivas dependências
        /// </summary>
        [TestInitialize]
        public void ConfigEnvironment()
        {
            api = new PerlinkNegocio(new ProcessoRepositorio(new EmpresaRepositorio()));
        }

        /// <summary>
        /// Caso de uso: Calcular a soma dos processos ativos. A aplicação deve retornar R$ 1.087.000,00
        /// </summary>
        [TestMethod()]
        public void CalcularSomaDosProcessosAtivos()
        {
            var resultadoApi = api.CalcularSomaDosProcessosAtivos();
            Assert.IsTrue(resultadoApi == 1087000, "A Soma dos processos ativos resultou " + resultadoApi.ToString() + ". A plicação deve retornar 1087000");
        }

        /// <summary>
        /// Caso de uso: Calcular a a média do valor dos processos no Rio de Janeiro para o Cliente "Empresa A". A aplicação deve retornar R$ 110.000,00
        /// </summary>
        [TestMethod()]
        public void CalcularMediaValorProcessosRJparaClienteEmpresaA()
        {
            var resultadoApi = api.CalcularMediaValorProcessosRJparaClienteEmpresaA();
            Assert.IsTrue(resultadoApi == 110000, "A média do valor dos processos no Rio de Janeiro para o Cliente 'Empresa A' retornou (" + resultadoApi.ToString() + "). A aplicação deve retornar R$ 110000");
        }

        /// <summary>
        /// Caso de uso: Calcular o Número de processos com valor acima de R$ 100.000,00. A aplicação deve retornar 2
        /// </summary>
        [TestMethod()]
        public void CalcularNumeroProcessosValorAcima100000()
        {
            var resultadoApi = api.CalcularNumeroProcessosValorAcima100000();
            Assert.IsTrue(resultadoApi == 2, "O número de processos com valor acima de 100000 retornou (" + resultadoApi.ToString() + "). A aplicação deve retornar 2");
        }

        /// <summary>
        /// Caso de uso: Obter a lista de Processos de Setembro de 2007. A aplicação deve retornar uma lista com somente o Processo “00010TRABAM”
        /// </summary>
        [TestMethod()]
        public void ObterListaProcessosSetembro2007()
        {
            var resultadoApi = api.ObterListaProcessosSetembro2007();
            Assert.IsTrue(resultadoApi.Count() == 1 && resultadoApi.FirstOrDefault().NumeroProcesso == "00010TRABAM", "A lista de processos de Setembro de 2007 retornou " + resultadoApi.ToString() + ". A aplicação deve retornar uma lista com somente o Processo '00010TRABAM0'");
        }

        /// <summary>
        /// Caso de uso: Obter a lista de processos no mesmo estado do cliente, para cada um dos clientes. A aplicação deve retornar uma lista com os processos de número “00001CIVELRJ”,”00004CIVELRJ” para o Cliente "Empresa A" e “00008CIVELSP”,”00009CIVELSP” para o o Cliente "Empresa B"
        /// </summary>
        [TestMethod()]
        public void ObterListaProcessosMesmoEstadoCliente()
        {
            var resultadoApi = api.ObterListaProcessosMesmoEstadoCliente();
            var listaValidaEmpresaA = new List<string>();
            listaValidaEmpresaA.Add("00001CIVELRJ");
            listaValidaEmpresaA.Add("00004CIVELRJ");

            var listaValidaEmpresaB = new List<string>();
            listaValidaEmpresaB.Add("00008CIVELSP");
            listaValidaEmpresaB.Add("00009CIVELSP");

            var condicao = (resultadoApi.Where(w => w.Empresa.Nome == "Empresa A").Count() == 2 && resultadoApi.Where(w => w.Empresa.Nome == "Empresa A").All(a => listaValidaEmpresaA.Contains(a.NumeroProcesso)))
                && (resultadoApi.Where(w => w.Empresa.Nome == "Empresa B").Count() == 2 && resultadoApi.Where(w => w.Empresa.Nome == "Empresa B").All(a => listaValidaEmpresaB.Contains(a.NumeroProcesso)));
            Assert.IsTrue(condicao, "A lista de processos no mesmo estado do cliente retornou " + resultadoApi.ToString() + ". A aplicação deve retornar uma lista com os processos de número '00001CIVELRJ','00004CIVELRJ' para o Cliente 'Empresa A' e '00008CIVELSP','00009CIVELSP' para o Cliente 'Empresa B'");
        }

        /// <summary>
        /// Caso de uso: Obter a lista de processos que contenham a sigla “TRAB”. A aplicação deve retornar uma lista com os processos “00003TRABMG” e “00010TRABAM”
        /// </summary>
        [TestMethod()]
        public void ObterListaProcessosContenhamSiglaTRAB()
        {
            var resultadoApi = api.ObterListaProcessosContenhamSiglaTRAB();
            var listaValidaProcessos = new List<string>();
            listaValidaProcessos.Add("00003TRABMG");
            listaValidaProcessos.Add("00010TRABAM");

            var condicao = (resultadoApi.Count() == 2 && resultadoApi.All(a => listaValidaProcessos.Contains(a.NumeroProcesso)));
            Assert.IsTrue(condicao, "A lista de processos que contenham a sigla 'TRAB' retornou " + resultadoApi.ToString() + "). A aplicação deve retornar uma lista com os processos 00003TRABMG' e '00010TRABAM'");
        }


    }
}

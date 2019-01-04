using PerlinkApi.Entidades;
using PerlinkApi.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerlinkApi.Repositorios
{
    public class ProcessoRepositorio : IProcessoRepositorio
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        /// <summary>
        /// Contrutor da classe de repositório de processos injetando dependencia da classe de repositório de empresas
        /// </summary>
        /// <param name="empresaRepositorio"></param>
        public ProcessoRepositorio(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        /// <summary>
        /// Recupera os Processos atribuidos às empresas
        /// </summary>
        /// <returns>Retorna uma lista de processos</returns>
        public IEnumerable<Processo> getProcessos()
        {
            var listaProcessos = new List<Processo>();
            #region Processos para Empresa A
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000001"),
                Ativo = true,
                NumeroProcesso = "00001CIVELRJ",
                UF = "RJ",
                Valor = 200000.00,
                DataInicio = new DateTime(2007, 1, 10)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000001"),
                Ativo = true,
                NumeroProcesso = "00002CIVELSP",
                UF = "SP",
                Valor = 100000.00,
                DataInicio = new DateTime(2007, 10, 20)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000001"),
                Ativo = false,
                NumeroProcesso = "00003TRABMG",
                UF = "MG",
                Valor = 10000.00,
                DataInicio = new DateTime(2007, 10, 30)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000001"),
                Ativo = false,
                NumeroProcesso = "00004CIVELRJ",
                UF = "RJ",
                Valor = 20000.00,
                DataInicio = new DateTime(2007, 11, 10)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000001"),
                Ativo = true,
                NumeroProcesso = "00005CIVELSP",
                UF = "SP",
                Valor = 35000.00,
                DataInicio = new DateTime(2007, 11, 15)
            });
            #endregion

            #region Processos para Empresa B
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000002"),
                Ativo = true,
                NumeroProcesso = "00006CIVELRJ",
                UF = "RJ",
                Valor = 20000.00,
                DataInicio = new DateTime(2007, 5, 1)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000002"),
                Ativo = true,
                NumeroProcesso = "00007CIVELRJ",
                UF = "RJ",
                Valor = 700000.00,
                DataInicio = new DateTime(2007, 6, 2)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000002"),
                Ativo = false,
                NumeroProcesso = "00008CIVELSP",
                UF = "SP",
                Valor = 500.00,
                DataInicio = new DateTime(2007, 7, 3)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000002"),
                Ativo = true,
                NumeroProcesso = "00009CIVELSP",
                UF = "SP",
                Valor = 32000.00,
                DataInicio = new DateTime(2007, 11, 10)
            });
            listaProcessos.Add(new Processo
            {
                Empresa = _empresaRepositorio.getEmpresaPorCnpj("00000000002"),
                Ativo = false,
                NumeroProcesso = "00010TRABAM",
                UF = "AM",
                Valor = 1000.00,
                DataInicio = new DateTime(2007, 9, 5)
            });
            #endregion
            return listaProcessos;
        }
    }
}

using System;

namespace PerlinkApi.Entidades
{
    /// <summary>
    /// Classe de Processo
    /// </summary>
    public class Processo
    {
        public Empresa Empresa { get; set; }
        public string NumeroProcesso { get; set; }
        public string UF { get; set; }
        public bool Ativo { get; set; }
        public double Valor { get; set; }
        public DateTime DataInicio { get; set; }
    }
}

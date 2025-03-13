using System;

namespace Odontoprev.Models.Entities;

    /// <summary>
    /// Representa um registro de faturamento.
    /// </summary>
    public class Faturamento
    {
        /// <summary>
        /// Identificador único do faturamento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de emissão do faturamento.
        /// </summary>
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Valor total faturado.
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Status do faturamento (ex: Pago, Pendente).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Identificador do procedimento associado ao faturamento.
        /// </summary>
        public int ProcedimentoOpId { get; set; }
    }

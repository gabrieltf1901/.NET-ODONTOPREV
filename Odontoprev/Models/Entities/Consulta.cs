using System;

namespace Odontoprev.Models.Entities;

    /// <summary>
    /// Representa uma consulta realizada.
    /// </summary>
    public class Consulta
    {
        /// <summary>
        /// Identificador único da consulta.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data e hora em que a consulta foi realizada.
        /// </summary>
        public DateTime DataHoraConsulta { get; set; }

        /// <summary>
        /// Tipo de procedimento realizado na consulta.
        /// </summary>
        public string TipoProcedimento { get; set; }

        /// <summary>
        /// Valor da consulta.
        /// </summary>
        public decimal ValorConsulta { get; set; }

        /// <summary>
        /// Status da consulta (ex: Concluída, Agendada, Cancelada).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Identificador do profissional responsável pela consulta.
        /// </summary>
        public int ProfissionalOpId { get; set; }
    }

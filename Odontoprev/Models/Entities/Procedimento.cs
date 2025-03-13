using System;

namespace Odontoprev.Models.Entities;

    /// <summary>
    /// Representa um procedimento odontológico.
    /// </summary>
    public class Procedimento
    {
        /// <summary>
        /// Identificador único do procedimento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descrição do procedimento.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Preço unitário do procedimento.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Categoria do procedimento (ex: Rotina, Urgente).
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Identificador da consulta associada ao procedimento.
        /// </summary>
        public int ConsultaOpId { get; set; }
    }

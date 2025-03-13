using System;

namespace Odontoprev.Models.Entities;

    /// <summary>
    /// Representa um paciente.
    /// </summary>
    public class Paciente
    {
        /// <summary>
        /// Identificador único do paciente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome completo do paciente.
        /// </summary>
        public string NomeCompleto { get; set; }

        /// <summary>
        /// Data de nascimento do paciente.
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Contato (telefone, email, etc.) do paciente.
        /// </summary>
        public string Contato { get; set; }

        /// <summary>
        /// Plano de saúde do paciente.
        /// </summary>
        public string PlanoDeSaude { get; set; }

        /// <summary>
        /// Histórico médico do paciente.
        /// </summary>
        public string HistoricoMedico { get; set; }
    }

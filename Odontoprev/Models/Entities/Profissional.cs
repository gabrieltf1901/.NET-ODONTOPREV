using System;

namespace Odontoprev.Models.Entities;

    /// <summary>
    /// Representa um profissional de odontologia.
    /// </summary>
    public class Profissional
    {
        /// <summary>
        /// Identificador único do profissional.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Registro CRM do profissional.
        /// </summary>
        public string Crm { get; set; }

        /// <summary>
        /// Nome completo do profissional.
        /// </summary>
        public string NomeCompleto { get; set; }

        /// <summary>
        /// Especialidade odontológica do profissional.
        /// </summary>
        public string EspecialidadeOdontologica { get; set; }

        /// <summary>
        /// Contato do profissional.
        /// </summary>
        public string Contato { get; set; }

        /// <summary>
        /// Horário de consulta do profissional.
        /// </summary>
        public string HorarioDeConsulta { get; set; }

        /// <summary>
        /// Avaliação de qualidade do serviço prestado.
        /// </summary>
        public string AvaliacaoQualidadeServico { get; set; }

        /// <summary>
        /// Identificador do paciente associado (caso exista relacionamento direto).
        /// </summary>
        public int PacienteOpId { get; set; }
    }

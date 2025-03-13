using System;

namespace Odontoprev.Singleton;

/// <summary>
/// Implementação do padrão Singleton para gerenciar configurações globais da aplicação.
/// </summary>
public sealed class ConfigManager
{
    private static readonly Lazy<ConfigManager> instance =
        new Lazy<ConfigManager>(() => new ConfigManager());

    public static ConfigManager Instance => instance.Value;

    // Construtor privado para evitar instância externa
    private ConfigManager() { }

    // Exemplo de método de acesso a uma configuração global
    public string GetAppName() => "OdontoPrev API";
}
namespace Robots.Model
{
    /// <summary>
    /// Enumeracio de les possibles direccions d'una persona
    /// </summary>
    public enum Direccio { Quiet, Nord, Est, Sud, Oest }
    /// <summary>
    /// Enumeracio dels limits d'un escenari a la configuracio inicial
    /// </summary>
    public enum LimitsEscenari { Files = 15, Columnes = 15, Homes = 50, Dones = 50, Cambrers = 20 }
    /// <summary>
    /// Enumeracio amb valors per defecte a la pantalla de configuracio inicial
    /// </summary>
    public enum DefaultsEscenari { Files = 5, Columnes = 5, Homes = 5, Dones = 5, Cambrers = 2 }
}

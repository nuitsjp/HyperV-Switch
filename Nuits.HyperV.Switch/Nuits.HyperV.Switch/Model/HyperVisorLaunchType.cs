namespace Nuits.HyperV.Switch.Model
{
    /// <summary>
    /// HyperVisorLaunchType
    /// </summary>
    public enum HyperVisorLaunchType : ulong
    {
        /// <summary>
        /// OFF
        /// </summary>
        Off = 0,
        /// <summary>
        /// AUTO
        /// </summary>
        Auto = 1,
        /// <summary>
        /// ブートローダーに該当の設定が存在しない
        /// </summary>
        None = 2
    }
}

namespace Test.Common
{
    public class CommonHelpers
    {
        #region Singleton

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static CommonHelpers Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ??= new CommonHelpers();
                }
            }
        }

        #endregion Singleton

        #region Propiedades Privadas

        /// <summary>
        /// The instance
        /// </summary>
        private static CommonHelpers _instance;

        /// <summary>
        /// The padlock
        /// </summary>
        private static readonly object Padlock = new object();

        #endregion Propiedades Privadas

        #region Propiedades Públicas

        /// <summary>
        /// Gets or sets the cadena parametros.
        /// </summary>
        /// <value>The cadena parametros.</value>
        public string CadenaConexion { get; set; }


        #endregion Propiedades Públicas
    }
}
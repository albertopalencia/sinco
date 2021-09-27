using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Infrastructure.Helpers
{
	public class DapperHelper
	{
		#region Singleton

		/// <summary>
		///     Clase esta instanciada.
		/// </summary>
		/// <value>The instancia.</value>
		public static DapperHelper Instance
		{
			get
			{
				lock (Padlock)
				{
					return _instance ??= new DapperHelper();
				}
			}
		}

		#endregion Singleton

		#region Propiedades Privadas y Públicas

		/// <summary>
		///     Propiedad estatica que almacena la instancia del objecto.
		/// </summary>
		private static DapperHelper _instance;

		/// <summary>
		///     Atributo para validar el estado para instanciar el objeto
		/// </summary>
		private static readonly object Padlock = new object();

		#endregion Propiedades Privadas y Públicas

		#region Métodos Públicos

		public async Task<IEnumerable<T>> ExecuteQuerySelectAsync<T>(string cnx, string query, object filter = null) where T : class
		{
			await using var conn = new SqlConnection(cnx);
			conn.Open();
			return await conn.QueryAsync<T>(query, filter)
				.ConfigureAwait(false);
		}

		#endregion Métodos Públicos
	}
}
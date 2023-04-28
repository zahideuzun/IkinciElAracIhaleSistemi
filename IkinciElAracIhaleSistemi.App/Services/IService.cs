using IkinciElAracIhaleSistemi.App.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.App.Services
{
	public interface IService<T> : IDisposable where T : class, new()
	{
		IQueryable<T> Query(); // Read işlemleri
		Result Add(T model); // Create işlemleri
		Result Update(T model); // Update işlemleri
		Result Delete(int id); // Delete işlemleri
	}
}

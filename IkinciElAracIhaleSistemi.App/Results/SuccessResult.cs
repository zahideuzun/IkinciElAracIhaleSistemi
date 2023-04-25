using IkinciElAracIhaleSistemi.App.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemi.App.Results
{
	public class SuccessResult : Result
	{
		public SuccessResult(string message) : base(true, message)
		{
		}

		public SuccessResult() : base(true, "")
		{
		}
	}
}

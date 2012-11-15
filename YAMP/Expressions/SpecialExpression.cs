using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YAMP
{
	class SpecialExpression : Expression
	{
		public string SpecialName
		{
			get { return this._input; }
		}
		
		public SpecialExpression () : base(@"((\$)|(:))")
		{
		}

		public SpecialExpression(QueryContext query, Match match) : this()
		{
			Query = query;
			mx = match;
		}

		public override Expression Create(QueryContext query, Match match)
		{
			return new SpecialExpression(query, match);
		}

		public override Value Interpret(Dictionary<string, Value> symbols)
		{
			if(SpecialName.Equals(":"))
				return new RangeValue();

			var variable = Context.GetVariable(SpecialName);

			if (variable != null)
				return variable;
			
			throw new ParseException(Offset, SpecialName);
		}
	}
}


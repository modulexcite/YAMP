/*
    Copyright (c) 2012, Florian Rappl.
    All rights reserved.

    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:
        * Redistributions of source code must retain the above copyright
          notice, this list of conditions and the following disclaimer.
        * Redistributions in binary form must reproduce the above copyright
          notice, this list of conditions and the following disclaimer in the
          documentation and/or other materials provided with the distribution.
        * Neither the name of the YAMP team nor the names of its contributors
          may be used to endorse or promote products derived from this
          software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
    ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
    WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
    DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
    DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
    (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
    LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
    ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
    (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.IO;
using System.Text;

namespace YAMP
{
	public class StringValue : Value, IFunction
	{
		#region Members

		string _value;

		#endregion

		#region Properties

		public string Value
		{
			get { return _value; }
		}

		public int Length
		{
			get { return _value.Length; }
		}

		#endregion

		#region implemented abstract members of Value

		public override Value Add (Value right)
		{
			return new StringValue(_value + right.ToString());
		}

		public override Value Subtract (Value right)
		{
			throw new OperationNotSupportedException("-", this);
		}

		public override Value Multiply (Value right)
		{
			throw new OperationNotSupportedException("*", this);
		}

		public override Value Divide (Value denominator)
		{
			throw new OperationNotSupportedException("/", this);
		}

		public override Value Power (Value exponent)
		{
			throw new OperationNotSupportedException("^", this);
		}
		
		public override byte[] Serialize ()
		{
            using (var ms = Serializer.Create())
            {
                ms.Serialize(_value);
                return ms.Value;
            }
		}

		public override Value Deserialize (byte[] content)
		{
            using(var ds = Deserializer.Create(content))
            {
                _value = ds.GetString();
            }

			return this;
		}

		#endregion

		#region ctor

		public StringValue () : this(string.Empty)
		{
		}

		public StringValue (string value)
		{
			_value = value;
		}

        public StringValue(char[] str) : this(new string(str))
        {
        }

		#endregion

		#region Overrides

		public override string ToString (ParseContext context)
		{
			return _value;
		}

		#endregion

        #region Behavior as method

        public Value Perform(ParseContext context, Value argument)
        {
            if (argument is NumericValue)
            {
                var idx = BuildIndex(argument, Length);
                var str = new char[idx.Length];

                for (var i = 0; i < idx.Length; i++)
                    str[i] = _value[idx[i]];

                return new StringValue(str);
            }

            throw new OperationNotSupportedException("string-index", argument);
        }

        #endregion
    }
}


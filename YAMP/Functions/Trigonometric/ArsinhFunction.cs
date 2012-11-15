﻿using System;

namespace YAMP
{
	[Description("The inverse of the sinh(x) function.")]
	[Kind(PopularKinds.Function)]
    class ArsinhFunction : StandardFunction
    {
        protected override ScalarValue GetValue(ScalarValue value)
        {
            return (value + ((value * value) + 1.0).Sqrt()).Ln();
        }
    }
}

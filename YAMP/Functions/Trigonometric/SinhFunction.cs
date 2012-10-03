﻿using System;

namespace YAMP
{
    [Description("The standard sinh(x) function.")]
    class SinhFunction : StandardFunction
    {
        protected override ScalarValue GetValue(ScalarValue value)
        {
            return (value.Exp() - (-value).Exp()) / 2.0;
        }
    }
}
﻿using System;

namespace YAMP
{
    /// <summary>
    /// Gets the omega constant.
    /// </summary>
    [Description("The omega constant is the value of W(1) where W is Lambert's W function. The name is derived from the alternate name for Lambert's W function, the omega function.")]
    [Kind(PopularKinds.Constant)]
    class OmegaConstant : BaseConstant
    {
        static readonly ScalarValue omega = new ScalarValue(0.5671432904097838729999686622, 0.0);

        public override Value Value
        {
            get { return omega; }
        }
    }
}

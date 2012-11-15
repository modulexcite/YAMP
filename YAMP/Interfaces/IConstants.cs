﻿using System;

namespace YAMP
{
    /// <summary>
    /// Marks a class as being a collection of constants.
    /// </summary>
    public interface IConstants
    {
		string Name { get; }

		Value Value { get; }
    }
}

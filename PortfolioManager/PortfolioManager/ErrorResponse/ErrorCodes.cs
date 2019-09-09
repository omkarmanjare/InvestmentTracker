using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PortfolioManager.ErrorResponse
{
    public enum ErrorCodes
    {
        [Description("The request contanins invalid inputs")]
        InvalidInputs=1001
    }
}
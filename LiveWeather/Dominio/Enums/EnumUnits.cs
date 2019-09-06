using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum EnumUnits
    {
        [StringValueAttribute("F")]
        Imperial,
        [StringValueAttribute("C")]
        Metric
    }
}

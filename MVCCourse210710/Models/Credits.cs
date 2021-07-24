using System;
using System.ComponentModel.DataAnnotations;

namespace MVCCourse210710.Models
{
    public enum Credits : int
    {
        [Display(Name = "零")]
        Zero,

        [Display(Name = "一")]
        One,

        [Display(Name = "二")]
        Two,

        [Display(Name = "三")]
        Three,

        [Display(Name = "四")]
        Four,

        [Display(Name = "五")]
        Five
    }

    [Flags]
    public enum FlagsEnum : byte
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Four = 4,
        Eight = 8,
        Sixteen = 16,
    }
}
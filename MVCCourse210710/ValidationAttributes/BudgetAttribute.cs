using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourse210710.DataAttributes
{
    public class BudgetAttribute : DataTypeAttribute
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public BudgetAttribute() : base(DataType.Text)      //沒有參數
        {
            MinValue = 0;
            MaxValue = 100;

            ErrorMessage = $"請輸入合理金額範圍 ({MinValue} ~ {MaxValue})";
        }
        public BudgetAttribute(int minValue, int maxValue) : base(DataType.Text)      //有參數
        {
            MinValue = minValue;
            MaxValue = maxValue;

            ErrorMessage = $"請輸入合理金額範圍 ({MinValue} ~ {MaxValue})";
        }
        public override bool IsValid(object value)      //MVC 會主動幫你呼叫
        {
            var obj = (decimal)value;
            return (obj >= MinValue && obj <= MaxValue);
        }
    }
}
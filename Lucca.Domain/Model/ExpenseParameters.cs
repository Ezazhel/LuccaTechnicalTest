using System;
using System.Collections.Generic;
using System.Text;

namespace Lucca.Domain.Model
{
    public class ExpenseParameters : QueryStringParameters
    {
        public ExpenseParameters()
        {
            OrderBy = "date";
        }
    }
}
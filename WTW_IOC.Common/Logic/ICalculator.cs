﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Common.Logic
{
    public interface ICalculator
    {
        int Add(int first, int second);
        int Subtract(int first, int second);
        int Multiply(int first, int second);
        double Divide(int first, int second);
    }
}

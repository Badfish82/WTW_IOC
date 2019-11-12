using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW_IOC.Common.Logic
{
    public interface ISampleLogic
    {
        string[] LoadSampleModel();
        string AddMessage(int first, int second);
        string SubtractMessage(int first, int second);
        string MultiplyMessage(int first, int second);
        string DivideMessage(int first, int second);
    }
}

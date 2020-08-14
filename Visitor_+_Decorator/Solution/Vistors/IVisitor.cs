using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    interface IVisitor<T>
    {
        T GetValue(IADTreeNode node, IVisitor<T> v, ADTreeContext context);
    }
    interface IIntVIsitor
    {
        int GetValue(IADTreeNode node, IIntVIsitor v, ADTreeContext context);
    }
}

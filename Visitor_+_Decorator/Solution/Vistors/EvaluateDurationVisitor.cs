using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class EvaluateDurationVisitor : IVisitor<int>
    {
        public int GetValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context)
        {
            ADTreeNodeDurationDecorator decNode = new ADTreeNodeDurationDecorator(node);
            return decNode.GetImportantValue(node, v, context);
        }
    }
}

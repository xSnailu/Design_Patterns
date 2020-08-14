using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class EvaluateCostVisitor : IVisitor<int>
    {
        public int GetValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context)
        {
            ADTreeNodeCostDecorator decNode = new ADTreeNodeCostDecorator(node);
            return decNode.GetImportantValue(node, v, context); 
        }
    }
}

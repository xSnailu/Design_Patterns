using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class EvaluateSuccessVisitor : IVisitor<bool>
    {
        public bool GetValue(IADTreeNode node, IVisitor<bool> v, ADTreeContext context)
        {
            if (context.GetNodeOutcome(node.Name) != null)
            {
                // jesli juz ustawione to zwroc
                return (bool)context.GetNodeOutcome(node.Name);
            }
            else
            {
                if(node.LeftNode == null && node.RightNode == null)
                {
                    // randomowo sie liczy
                    bool boolVal = node.CalculateSuccess(true, true);
                    //context.SetNodeOutcome(node.Name, boolVal);
                    return boolVal;
                }
                else if(node.LeftNode != null && node.RightNode != null)
                {
                    // liczy sie wedlug node
                    bool boolVal = node.CalculateSuccess(v.GetValue(node.LeftNode,v,context), v.GetValue(node.RightNode, v, context));
                    //context.SetNodeOutcome(node.Name, boolVal);
                    return boolVal;
                }
                
            }

            // jesli jeden jest ustawiony a drugi nie to błąd
            throw new ArgumentException();
        }
    }
}

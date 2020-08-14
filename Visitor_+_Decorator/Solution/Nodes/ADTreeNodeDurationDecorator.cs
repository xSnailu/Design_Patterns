using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class ADTreeNodeDurationDecorator : IADTreeNode
    {
        IADTreeNode node;
        public ADTreeNodeDurationDecorator(IADTreeNode node)
        {
            this.node = node;
        }

        public string Name { get => node.Name; set { node.Name = value; } }
        public int Duration { get => node.Duration; set { node.Duration = value; } }
        public int Cost { get => node.Cost; set { node.Duration = value; } }
        public IADTreeNode LeftNode { get => node == null? null : node.LeftNode == null? null : new ADTreeNodeDurationDecorator(node.LeftNode); set { node.LeftNode = value; } }
        public IADTreeNode RightNode { get => node == null ? null : node.RightNode == null? null : new ADTreeNodeDurationDecorator(node.RightNode); set { node.RightNode = value; } }

        public bool CalculateSuccess(bool left, bool right)
        {
            return node.CalculateSuccess(left, right);
        }

        public int CalcVal(int a, int b)
        {
            return node.CalcVal(a, b);
        }

        public int GetImportantValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context)
        {
            if (node.LeftNode != null && node.RightNode != null)
            {
                return node.Duration + node.CalcVal(v.GetValue(node.LeftNode, v, context), v.GetValue(node.RightNode, v, context));
            }
            else
                return node.Duration;
        }
    }
}

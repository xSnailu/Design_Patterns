using System;

namespace Task
{
    interface IADTreeNode
    {
        string Name { get; set; }
        int Duration { get; set; }
        int Cost { get; set; }
        // TODO: Uzupełnienie interfejsu, implementacja w klasach odpowiadających poszczególnym typom węzłów, dodanie funkcjonalności do analizy drzewa pod kątem sukcesu ataku, minimalnego czasu i kosztu.
        IADTreeNode LeftNode { get; set; }
        IADTreeNode RightNode { get; set; }
        bool CalculateSuccess(bool left, bool right);
        int GetImportantValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context);
        int CalcVal(int a, int b);
    }

    class AndNode : IADTreeNode
    {
        private IADTreeNode leftNode;
        private IADTreeNode rightNode;

        public AndNode(string name, int duration, int cost, IADTreeNode leftNode, IADTreeNode rightNode)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }
        public IADTreeNode LeftNode { get=>leftNode; set { leftNode = value; } }
        public IADTreeNode RightNode { get=>rightNode; set { rightNode = value; } }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }

        public bool CalculateSuccess(bool left, bool right)
        {
            return left && right;
        }

        public int CalcVal(int a, int b)
        {
            return a + b;
        }

        public int GetImportantValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context)
        {
            throw new NotImplementedException();
        }
    }

    class OrNode : IADTreeNode
    {
        private IADTreeNode leftNode;
        private IADTreeNode rightNode;
        public OrNode(string name, int duration, int cost, IADTreeNode leftNode, IADTreeNode rightNode)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
            this.leftNode = leftNode;
            this.rightNode = rightNode;
        }
        public IADTreeNode LeftNode { get => leftNode; set { leftNode = value; } }
        public IADTreeNode RightNode { get => rightNode; set { rightNode = value; } }

        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }

        public bool CalculateSuccess(bool left, bool right)
        {
            return left || right;
        }

        public int CalcVal(int a, int b)
        {
            return a < b ? a : b;
        }

        public int GetImportantValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context)
        {
            throw new NotImplementedException();
        }
    }

    class LeafNode : IADTreeNode
    {
        public LeafNode(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }

        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public IADTreeNode LeftNode { get => null; set => throw new System.NotImplementedException(); }
        public IADTreeNode RightNode { get => null; set => throw new System.NotImplementedException(); }

        public bool CalculateSuccess(bool left, bool right)
        {
            Random random = new Random();
            bool randVal = random.Next(2) < 1;
            return randVal;
        }

        public int CalcVal(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int GetImportantValue(IADTreeNode node, IVisitor<int> v, ADTreeContext context)
        {
            throw new NotImplementedException();
        }
    }


}

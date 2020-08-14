using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class ADTreeParser
    {
        public IADTreeNode Parse(string prefix_expression)
        {
            Stack<string> tokens = new Stack<string>(prefix_expression.Split(' ').Reverse<string>());
            var expression = ParseNext(tokens);
            if (tokens.Count != 0) throw new SyntaxErrorException();
            return expression;
        }

        private IADTreeNode ParseNext(Stack<string> tokens)
        {
            if (tokens.Count == 0) throw new SyntaxErrorException();
            string[] split = tokens.Pop().Split(',');
            if (split.Length != 4) throw new SyntaxErrorException();
            string type = split[0];
            string name = split[1];
            int cost = int.Parse(split[2]);
            int time = int.Parse(split[3]);
            switch (type)
            {
                // TODO: dokończenie implementacji parsera (konstrukcja drzewa odpowiadającego wejściowemu łańcuchowi i zwrócenie korzenia).
                case "AND":
                    return new AndNode(name, time, cost, ParseNext(tokens), ParseNext(tokens));
                case "OR":
                    return new OrNode(name, time, cost, ParseNext(tokens), ParseNext(tokens));
                case "LEAF":
                    return new LeafNode(name, time, cost);
                default: throw new SyntaxErrorException();
            }
        }
    }
}

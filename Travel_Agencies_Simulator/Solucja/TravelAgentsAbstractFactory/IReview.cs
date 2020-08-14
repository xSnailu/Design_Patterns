using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace Solucja.TravelAgentsAbstractFactory
{
    public interface IReview
    {
        void ShowContent();
    }
    class PolandReview : IReview
    {
        BSTNode reviev;
        public PolandReview(BSTNode reviev)
        {
            this.reviev = reviev;
        }
        public void ShowContent()
        {
            string revievUserName = reviev.UserName;
            string revievText = reviev.Review;
            revievUserName = revievUserName.Replace('a', 'ą');
            revievText = revievText.Replace('a', 'ą');

            revievUserName = revievUserName.Replace('e', 'ę');
            revievText = revievText.Replace('e', 'ę');

            Console.WriteLine();
            Console.WriteLine(revievText);
            Console.WriteLine(revievUserName);
        }
    }
    class ItalyReview : IReview
    {
        BSTNode reviev;
        public ItalyReview(BSTNode reviev)
        {
            this.reviev = reviev;
        }
        public void ShowContent()
        {
            string revievUserName = reviev.UserName;
            string revievText = reviev.Review;

            revievUserName = "Della_" + revievUserName;

            Console.WriteLine();
            Console.WriteLine(revievText);
            Console.WriteLine(revievUserName);
        }
    }
    class FranceReview : IReview
    {

        BSTNode reviev;
        public FranceReview(BSTNode reviev)
        {
            this.reviev = reviev;
        }
        public void ShowContent()
        {
            // TO SPRAWDZIĆ CZY DZIAŁA
            string revievUserName = reviev.UserName;
            string revievText = reviev.Review;

            for(int i=0; i < revievText.Length - 4; i++)
            {
                if(revievText[i] == ' ')
                {
                    for(int j = 1; j < 4; j++)
                    {
                        if (revievText[i + j] == ' ')
                        {
                            revievText = revievText.Substring(0, i) + " la" + revievText.Substring(i + j, revievText.Length - (i + j));
                            i = i + j;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(revievText);
            Console.WriteLine(revievUserName);
        }
    }
}

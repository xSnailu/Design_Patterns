using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.DataAccess;

namespace TravelAgencies.DatabaseIterators
{
    public interface IDatabaseIterator<dataType>
    {

        bool Next();
        dataType CurrentItem();
    }

    public class BookingDatabaseIterator : IDatabaseIterator<ListNode>
    {
        private ListNode[] rooms;
        private int[] iteratorPosition;
        private int numberOfCategories;
        private int currentCategory;
        public BookingDatabaseIterator(BookingDatabase db)
        {
            this.rooms = db.Rooms;
            currentCategory = 0;
            numberOfCategories = rooms.Length;
            iteratorPosition = new int[numberOfCategories];

            for (int i = 0; i < numberOfCategories; i++)
                iteratorPosition[i] = 0;
        }

        public ListNode CurrentItem()
        {
            ListNode outputListNode = rooms[currentCategory];
            for (int i = 0; i < iteratorPosition[currentCategory]; i++)
            {
                outputListNode = outputListNode.Next;
            }

            return outputListNode;
        }

        private bool AtEnd()
        {
            for (int i = 0; i < numberOfCategories; i++)
                if (iteratorPosition[i] != -1)
                    return false;
            return true;
        }

        public bool Next()
        {
            if (this.AtEnd())
            {
                for (int i = 0; i < numberOfCategories; i++)
                    iteratorPosition[i] = 0;
                currentCategory = 0;
                return false;
            }
            else
            {
                currentCategory = currentCategory + 1;
                currentCategory = currentCategory % numberOfCategories;
                for (int i = 0; i < numberOfCategories; i++)
                {
                    ListNode buforListNode = rooms[currentCategory];
                    for (int j = 0; j < iteratorPosition[currentCategory]; j++)
                    {
                        buforListNode = buforListNode.Next;
                        if (buforListNode == null)
                        {
                            iteratorPosition[currentCategory] = -1;
                            currentCategory = currentCategory + 1;
                            currentCategory = currentCategory % numberOfCategories;
                            continue;
                        }
                        else
                        {
                            iteratorPosition[currentCategory] = iteratorPosition[currentCategory] + 1;
                            break;
                        }
                    }

                }
            }
            return true;
        }
    }
    public class OysterDatabaseIterator : IDatabaseIterator<BSTNode>
    {
        private BSTNode reviews;
        private int postion;
        public OysterDatabaseIterator(OysterDatabase db)
        {
            this.reviews = db.Reviews;
            postion = 0;
        }
        public BSTNode CurrentItem()
        {
            List<BSTNode> tempListOfNodes = new List<BSTNode>();
            int iterator = 0;
            BSTNode outputNode = reviews;
            tempListOfNodes.Add(reviews);
            while (iterator != postion)
            {
                if (outputNode.Left != null)
                {
                    iterator++;
                    tempListOfNodes.Add(outputNode);
                    outputNode = outputNode.Left;
                    continue;
                }
                if (outputNode.Right != null)
                {
                    iterator++;
                    tempListOfNodes.Add(outputNode);
                    outputNode = outputNode.Right;
                    continue;
                }
                while (tempListOfNodes.Count != 0)
                {
                    BSTNode prev = outputNode;
                    outputNode = tempListOfNodes[tempListOfNodes.Count - 1];
                    tempListOfNodes.RemoveAt(tempListOfNodes.Count - 1);
                    if (outputNode.Right != null)
                        if (!tempListOfNodes.Contains(outputNode.Right) && outputNode.Right != prev)
                        {
                            tempListOfNodes.Add(outputNode);
                            outputNode = outputNode.Right;
                            iterator++;
                            break;
                        }
                    
                }
            }
            return outputNode;


        }

        public bool Next()
        {
            List<BSTNode> tempListOfNodes = new List<BSTNode>();
            int iterator = 0;
            BSTNode outputNode = reviews;
            tempListOfNodes.Add(reviews);
            while (iterator != postion)
            {
                
                if (outputNode.Left != null)
                {
                    iterator++;
                    tempListOfNodes.Add(outputNode);
                    outputNode = outputNode.Left;
                    continue;
                }
                if (outputNode.Right != null)
                {
                    iterator++;
                    tempListOfNodes.Add(outputNode);
                    outputNode = outputNode.Right;
                    continue;
                }
                while (tempListOfNodes.Count != 0)
                {
                    BSTNode prev = outputNode;
                    outputNode = tempListOfNodes[tempListOfNodes.Count - 1];
                    tempListOfNodes.RemoveAt(tempListOfNodes.Count - 1);
                    if (outputNode.Right != null)
                    {
                        if (outputNode == reviews)
                            if (tempListOfNodes.Contains(outputNode.Right) || prev == outputNode.Right)
                            {
                                postion = 0;
                                return true;
                            }

                        if (!tempListOfNodes.Contains(outputNode.Right) && outputNode.Right != prev)
                        {
                            tempListOfNodes.Add(outputNode);
                            iterator++;
                            outputNode = outputNode.Right;
                            break;
                        }
                            
                    }
                    
                }
            }

            if (outputNode.Left != null)
            {
                iterator++;
                postion++;
                tempListOfNodes.Add(outputNode);
                outputNode = outputNode.Left;
                return true;
            }
            if (outputNode.Right != null)
            {
                iterator++;
                postion++;
                tempListOfNodes.Add(outputNode);
                outputNode = outputNode.Right;
                return true;
            }
            
            while (tempListOfNodes.Count != 0)
            {
                BSTNode prev = outputNode;
                outputNode = tempListOfNodes[tempListOfNodes.Count - 1];
                tempListOfNodes.RemoveAt(tempListOfNodes.Count - 1);
                if (outputNode.Right != null)
                {
                    if (outputNode == reviews)
                        if (tempListOfNodes.Contains(outputNode.Right))
                        {
                            postion = 0;
                            return true;
                        }

                    if (!tempListOfNodes.Contains(outputNode.Right) && outputNode.Right!=prev)
                    {
                        postion++;
                        break;
                    }

                }
            
            }

            return true;
        }

    }
    public class ShutterStockDatabaseIterator : IDatabaseIterator<PhotMetadata>
    {
        PhotMetadata[][][] Photos;
        int i, j, k;

        public ShutterStockDatabaseIterator(ShutterStockDatabase db)
        {
            Photos = db.Photos;
            i = j = k = 0;
        }
        public PhotMetadata CurrentItem()
        {
            this.fixTable();
            return Photos[i][j][k];
        }

        private void fixTable()
        {
            while (Photos[i] == null)
            {
                i = i + 1;
                if (i >= Photos.Length)
                    i = 0;
            }

            while (Photos[i].Length == 0)
            {
                i = i + 1;
                if (i >= Photos.Length)
                    i = 0;
            }

            while (Photos[i][j] == null)
            {
                j = j + 1;
                if (j >= Photos[i].Length)
                {
                    j = 0;
                    i = i + 1;
                    if (i >= Photos.Length)
                        i = 0;
                }
            }

            while (Photos[i][j].Length == 0)
            {
                j = j + 1;
                if (j >= Photos[i].Length)
                {
                    j = 0;
                    i = i + 1;
                    if (i >= Photos.Length)
                        i = 0;
                }
            }

            while (Photos[i][j][k] == null)
            {
                k = k + 1;
                if (k >= Photos[i][j].Length)
                {
                    k = 0;
                    j = j + 1;
                    if (j >= Photos[i].Length)
                    {
                        j = 0;
                        i = i + 1;
                        if (i >= Photos.Length)
                            i = 0;
                    }
                }
            }
        }

        public bool Next()
        {

            if (Photos[i][j].Length > k + 1)
            {
                k = k + 1;            
                return true;
            }

            if (Photos[i].Length > j + 1)
            {
                j = j + 1;
                k = 0;

                return true;
            }

            if (Photos.Length > i + 1)
            {
                i = i + 1;
                j = 0;
                k = 0;

                return true;
            }

            i = 0;
            j = 0;
            k = 0;
            return true;
        }
    }
    public class TripAdvisorDatabaseIterator : IDatabaseIterator<TripEncrypted>
    {
        private TripAdvisorDatabase database;
        private int position;
        public TripAdvisorDatabaseIterator(TripAdvisorDatabase db)
        {
            database = db;
            position = 0;
        }

        public TripEncrypted CurrentItem()
        {
            // tu moze byc nieskonczona pętla
            while (!IsCorrect(position))
                this.Next();



            string name = null;
            for (int i = 0; i < database.Names.Length; i++)
                if (database.Names[i].ContainsKey(database.Ids[position]))
                if (database.Names[i][database.Ids[position]] != null)
                    name = database.Names[i][database.Ids[position]];
           

            return new TripEncrypted(name, database.Prices[database.Ids[position]], database.Ratings[database.Ids[position]], database.Countries[database.Ids[position]]);

        }

        private bool IsCorrect(int position)
        {
            bool isName = false;
            for (int i = 0; i < database.Names.Length; i++)
            {
                if (database.Names[i].ContainsKey(database.Ids[position]))
                    if (database.Names[i][database.Ids[position]] != null)
                    {
                        isName = true;
                        break;
                    }

            }
            if (!isName)
                return false;

            if (!database.Prices.ContainsKey(database.Ids[position]))
                return false;
            if (database.Prices[database.Ids[position]] == null)
            {
                this.Next();
                return false;
            }
            if (!database.Ratings.ContainsKey(database.Ids[position]))
                return false;
            if (database.Ratings[database.Ids[position]] == null)
            {
                this.Next();
                return false;
            }
            if (!database.Countries.ContainsKey(database.Ids[position]))
                return false;
            if (database.Countries[database.Ids[position]] == null)
            {
                this.Next();
                return false;
            }
            return true;
        }
        public bool Next()
        {
            if (position + 1 > database.Ids.Length - 1)
                position = 0;
            else
                position++;

            
            return true;
        }
    }

}





using System;

namespace csharp
{
    class BinarySearchTree<T> where T: IComparable<T>
    {
        private T item;
        private BinarySearchTree<T>? leftTree;
        private BinarySearchTree<T>? rightTree;

        public BinarySearchTree(T item)
        {
            this.item = item;
        }

        public void Add(T item)
        {
            var res = item.CompareTo(this.item);
            if (res < 0)
            {
                if (leftTree is null)
                    leftTree = new BinarySearchTree<T>(item);
                else
                    leftTree.Add(item);
            }
            else if (res >= 0)
            {
                if (rightTree is null)
                    rightTree = new BinarySearchTree<T>(item);
                else
                    rightTree.Add(item);
            }
        }

        public bool Contains(T item)
        {
            var res = item.CompareTo(this.item);

            if (res < 0 && !(leftTree is null))
                return leftTree.Contains(item);
            
            if (res > 0 && !(rightTree is null))
                return rightTree.Contains(item);
            
            return res == 0;
        }
    }
}

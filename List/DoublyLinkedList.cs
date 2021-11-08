using System;

namespace List
{
    public class DoublyLinkedList : ILoveList
    {
        private DoublyNode _head;
        private DoublyNode _tail;

        public DoublyLinkedList()
        {
            CreateEmptyList();
        }

        public DoublyLinkedList(int val)
        {
            _head = new DoublyNode(val);
            _tail = _head;
        }

        public DoublyLinkedList(int[] arr)
        {
            if (arr.Length != 0)
            {
                _head = new DoublyNode(arr[0]);
                _tail = _head;

                for (int i = 1; i < arr.Length; i++)
                {
                    DoublyNode node = new DoublyNode(arr[i]);
                    _tail.Next = node;
                    node.Prev = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                CreateEmptyList();
            }
        }

        public int GetLength()
        {
            int length = 0;
            DoublyNode current = _head;

            while (current != null)
            {
                current = current.Next;
                length++;
            }
            return length;
        }

        public int[] ToArray()
        {
            DoublyNode current = _head;
            int[] arr = new int[GetLength()];
            int i = 0;

            while (current != null)
            {
                arr[i] = current.Val;
                current = current.Next;
                i++;
            }
            return arr;
        }

        public void AddFirst(int val)
        {
            DoublyNode node = new DoublyNode(val);
            node.Next = _head;

            if (_head != null)
            {
                _head.Prev = node;
            }
            _head = node;
        }

        public void AddFirst(DoublyLinkedList list)
        {
            if (_head is null)
            {
                _head = list._head;
                _tail = list._tail;
            }
            else if (list._head != null)
            {
                _head.Prev = list._tail;
                list._tail.Next = _head;
                _head = list._head;
            }
        }

        public void AddLast(int val)
        {
            if (_head != null)
            {
                DoublyNode node = new DoublyNode(val);
                _tail.Next = node;
                node.Prev = _tail;
                _tail = node;
            }
            else
            {
                _head = new DoublyNode(val);
                _tail = _head;
            }
        }

        public void AddLast(DoublyLinkedList list)
        {
            if (_head != null && list._head != null)
            {
                _tail.Next = list._head;
                list._head.Prev = _tail;
                _tail = list._tail;
            }
            if (_head == null)
            {
                _head = list._head;
                _tail = list._tail;
            }
        }

        public void AddAt(int idx, int val)
        {
            int length = GetLength();

            if (idx >= length || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (idx == 0)
            {
                AddFirst(val);
            }
            else if (idx == length)
            {
                AddLast(val);
            }
            else if (idx < length / 2)
            {
                DoublyNode current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                AddDoublyNode(current, val);
            }
            else
            {
                DoublyNode current = _tail;

                for (int i = length; i > idx; i--)
                {
                    current = current.Prev;
                }
                AddDoublyNode(current, val);
            }
        }

        public void AddAt(int idx, DoublyLinkedList list)
        {
            int length = GetLength();

            if (length == 0)
            {
                throw new NullReferenceException();
            }
            else if (list._head == null)
            {
                throw new NullReferenceException();
            }
            else if (idx >= length || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (idx == 0)
            {
                list._tail.Next = _head;
                _head.Prev = list._tail;
                _head = list._head;
            }
            else if (idx < length / 2)
            {
                DoublyNode current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                Add(list, current);
            }
            else
            {
                DoublyNode current = _tail;

                for (int i = length; i > idx; i--)
                {
                    current = current.Prev;
                }
                Add(list, current);
            }
        }

        public bool Contains(int val)
        {
            if (_head is null)
            {
                return false;
            }
            DoublyNode current = _head;

            while (current != null)
            {
                if (current.Val == val)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public int Get(int idx)
        {
            int length = GetLength();

            if (length == 0)
            {
                throw new NullReferenceException();
            }
            else if (idx < 0 || idx >= length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (idx == 0)
            {
                return _head.Val;
            }
            else if (idx == length - 1)
            {
                return _tail.Val;
            }
            else if (idx < (length) / 2)
            {
                DoublyNode current = _head;

                for (int i = 0; i < idx; i++)
                {
                    current = current.Next;
                }
                return current.Val;
            }
            else
            {
                DoublyNode current = _tail;

                for (int i = length - 1; i > idx; i--)
                {
                    current = current.Prev;
                }
                return current.Val;
            }

        }

        public int GetFirst()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            return _head.Val;
        }

        public int GetLast()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            return _tail.Val;
        }


        public int IndexOf(int val)
        {
            if (_head is null)
            {
                return -1;
            }

            if (_head.Next != null)
            {
                DoublyNode current = _head;
                int idx = 0;

                while (current != null)
                {
                    if (current.Val == val)
                    {
                        return idx;
                    }
                    current = current.Next;
                    idx++;
                }
            }
            else
            {
                if (_head.Val == val)
                {
                    return 0;
                }
            }
            return -1;
        }

        public int IndexOfMax()
        {
            if (_head is null)
            {
                return -1;
            }
            int idx = 0;
            int indexOfMax = 0;
            int max = _head.Val;

            DoublyNode current = _head;

            while (current != null)
            {
                if (max < current.Val)
                {
                    max = current.Val;
                    indexOfMax = idx;
                }
                idx++;
                current = current.Next;
            }
            return indexOfMax;
        }

        public int IndexOfMin()
        {
            if (_head is null)
            {
                return -1;
            }
            int idx = 0;
            int indexOfMin = 0;
            int min = _head.Val;

            DoublyNode current = _head;

            while (current != null)
            {
                if (min > current.Val)
                {
                    min = current.Val;
                    indexOfMin = idx;
                }
                idx++;
                current = current.Next;
            }
            return indexOfMin;
        }

        public int Max()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int max = _head.Val;

            DoublyNode current = _head;

            while (current != null)
            {
                if (max < current.Val)
                {
                    max = current.Val;
                }
                current = current.Next;
            }
            return max;
        }

        public int Min()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int min = _head.Val;

            DoublyNode current = _head;

            while (current != null)
            {
                if (min > current.Val)
                {
                    min = current.Val;
                }
                current = current.Next;
            }
            return min;
        }

        public int RemoveAll(int val)
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int count = 0;

            if (_head.Next != null)
            {
                DoublyNode current = _head;

                while (current.Next != null)
                {
                    if (_head.Val == val)
                    {
                        current = null;
                        _head = _head.Next;
                        current = _head;
                        count++;
                    }
                    else if (current.Next.Val == val)
                    {
                        current.Next = current.Next.Next;
                        count++;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                if (_head.Val == val)
                {
                    _head = null;
                    count++;
                }
            }
            return count;
        }

        public void RemoveAt(int idx)
        {
            int length = GetLength();

            if (length == 0)
            {
                throw new NullReferenceException();
            }
            else if (idx < 0 || idx >= length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (idx == 0)
            {
                RemoveFirst();
            }
            else if (idx == length - 1)
            {
                RemoveLast();
            }
            else if (idx < length / 2)
            {
                DoublyNode current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            else
            {
                DoublyNode current = _tail;

                for (int i = length - 1; i > idx; i--)
                {
                    current = current.Prev;
                }
                current.Prev = current.Prev.Prev;
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            int length = GetLength();

            if (length == 0)
            {
                throw new NullReferenceException();
            }
            else if (idx < 0 || idx >= length)
            {
                throw new IndexOutOfRangeException();
            }
            else if (length == 1 && n == 1)
            {
                RemoveFirst();
            }
            else if (idx == length - 1 && n == 1)
            {
                RemoveLast();
            }
            else if (n == length && idx == 0)
            {
                CreateEmptyList();
            }
            else if (idx < length / 2)
            {
                DoublyNode current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                DoublyNode tmp = current;

                for (int i = 0; i < n; i++)
                {
                    current = current.Next;
                }
                tmp.Next = current.Next;
            }
            else
            {
                DoublyNode current = _tail;

                for (int i = length - 1; i > idx; i--)
                {
                    current = current.Prev;
                }
                DoublyNode tmp = current;

                for (int i = 0; i < n; i++)
                {
                    current = current.Next;
                }
                tmp.Next = current.Next;
            }
        }

        public void RemoveFirst()
        {
            if (_head == null)
            {
                throw new NullReferenceException();
            }
            _head = _head.Next;
        }

        public int RemoveFirst(int val)
        {
            int idx = IndexOf(val);

            if (idx >= 0)
            {
                RemoveAt(idx);
                return idx;
            }
            else
            {
                return idx;
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            int length = GetLength();

            if (n > length)
            {
                throw new ArgumentException("Кол-во элементов списка меньше введенного n");
            }
            else if (n == 1)
            {
                RemoveFirst();
            }
            else if (n == length)
            {
                CreateEmptyList();
            }
            else
            {
                if (_head.Next != null)
                {
                    DoublyNode current = _head;

                    for (int i = 1; i < n; i++)
                    {
                        current = current.Next;
                    }
                    _head = current.Next;
                }
            }
        }

        public void RemoveLast()
        {
            if (_head == null)
            {
                throw new NullReferenceException();
            }
            else if (_head.Next != null)
            {
                _tail = _tail.Prev;
                _tail.Next = null;
            }
            else
            {
                CreateEmptyList();
            }
        }

        public void RemoveLastMultiple(int n)
        {
            int length = GetLength();

            if (n > length)
            {
                throw new ArgumentException("Кол-во элементов списка меньше введенного n");
            }
            else if (n == 1)
            {
                RemoveLast();
            }
            else if (n == length)
            {
                CreateEmptyList();
            }
            else
            {
                int idx = length - n;
                DoublyNode current = _tail;

                for (int i = length - 1; i >= idx; i--)
                {
                    current = current.Prev;
                }
                current.Next = null;
            }
        }

        public void Reverse()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            DoublyNode tmp = _head;
            _head = _tail;
            _tail = tmp;

            DoublyNode current = _head;

            while (current != null)
            {
                tmp = current.Next;
                current.Next = current.Prev;
                current.Prev = tmp;
                current = current.Next;
            }
        }

        public void Set(int idx, int val)
        {
            int length = GetLength();

            if (idx >= length || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (length == 1)
            {
                _head = new DoublyNode(val);
            }
            else if (idx == 0 && length != 1)
            {
                DoublyNode node = new DoublyNode(val);
                node.Next = _head.Next;
                _head.Next.Prev = node;
                _head = node;
            }
            else if (idx < length / 2)
            {
                DoublyNode current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                DoublyNode node = new DoublyNode(val);
                node.Next = current.Next.Next;
                current.Next = node;
                node.Prev = current.Next.Prev;
                current.Next.Next.Prev = node;
            }
            else
            {
                DoublyNode current = _tail;

                for (int i = length - 1; i > idx; i--)
                {
                    current = current.Prev;
                }
                DoublyNode node = new DoublyNode(val);

                node.Prev = current.Prev;
                current.Prev.Next = node;
                node.Next = current.Next;

                if (current == _tail)
                {
                    _tail = node;
                }
                else
                {
                    current.Next.Prev = node;
                }
            }
        }

        public void Sort()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }

            //Node current1 = _head;
            //Node current2 = _head.Next;

            //while (current1 != null)
            //{
            //    while (current2 != null)
            //    {
            //        if (current1.Val > current2.Next.Val)
            //        {
            //            if (current1 == _head)
            //            {
            //                if (current1.Next == current2)
            //                {
            //                    Node tmp = current2.Next;
            //                    current2.Next = current1;
            //                    current1.Next = tmp;
            //                    _head = current2;
            //                }
            //                else
            //                {
            //                    Node tmp = current2.Next.Next;
            //                    current2.Next.Next = _head.Next;
            //                    _head = current2.Next;
            //                    current1.Next = tmp;
            //                    current2.Next = current1;
            //                }
            //            }
            //        }
            //           current2 = current2.Next;
            //    }
            //    if (current1 != _head)
            //    {
            //        current1 = current1.Next;
            //    }
            //}      

            //for (Node i = _head; i.Next != null; i = i.Next)
            //{
            //    for (Node j = i.Next; j != null; j = j.Next)
            //    {
            //        if (i.Val > j.Val)
            //        {
            //            int tmp = i.Val;
            //            i.Val = j.Val;
            //            j.Val = tmp;

            //        }
            //    }
            //}
        }
        public void SortDesc()
        {
            throw new NotImplementedException();
        }

        private void CreateEmptyList()
        {
            _head = null;
            _tail = null;
        }

        private void Add(DoublyLinkedList list, DoublyNode current)
        {
            list._tail.Next = current.Next;
            current.Next.Prev = list._tail;
            current.Next = list._head;
            list._head.Prev = current;
        }

        private void AddDoublyNode(DoublyNode current, int val)
        {
            DoublyNode node = new DoublyNode(val);
            node.Next = current.Next;
            current.Next = node;
        }
    }
}

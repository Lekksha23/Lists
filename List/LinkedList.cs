using System;

namespace List
{
    public class LinkedList : ILoveList
    {
        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            CreateEmptyList();
        }

        public LinkedList(int val)
        {
            _head = new Node(val);
            _tail = _head;
        }

        public LinkedList(int[] arr)
        {
            if (arr.Length != 0)
            {
                _head = new Node(arr[0]);
                _tail = _head;

                for (int i = 1; i < arr.Length; i++)
                {
                    _tail.Next = new Node(arr[i]);
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
            Node current = _head;

            while (current != null)
            {
                current = current.Next;
                length++;
            }
            return length;
        }

        public int[] ToArray()
        {
            Node current = _head;
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
            Node node = new Node(val);
            node.Next = _head;
            _head = node;
        }

        public void AddFirst(LinkedList list)
        {
            if (list._head != null)
            {
                list._tail.Next = _head;
                _head = list._head;
            }
        }

        public void AddLast(int val)
        {
            if (_head != null)
            {
                _tail.Next = new Node(val);
                _tail = _tail.Next;
            }
            else
            {
                _head = new Node(val);
                _tail = _head;
            }
        }

        public void AddLast(LinkedList list)
        {
            if (_head != null)
            {
                _tail.Next = list._head;
                _tail = list._tail;
            }
            else
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
            else
            {
                Node current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                Node node = new Node(val);
                node.Next = current.Next;
                current.Next = node;
            }
        }

        public void AddAt(int idx, LinkedList list)
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
                _head = list._head;
            }
            else
            {
                Node current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                list._tail.Next = current.Next;
                current.Next = list._head;
            }
        }

        public void Set(int idx, int val)
        {
            int length = GetLength();

            if (idx >= length || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (idx == 0 && length != 1)
            {
                Node node = new Node(val);
                node.Next = _head.Next;
                _head = node;
            }
            else if (length != 1)
            {
                Node current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                Node node = new Node(val);
                node.Next = current.Next.Next;
                current.Next = node;
            }
            else
            {
                _head = new Node(val);
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

        public void RemoveLast()
        {
            if (_head == null)
            {
                throw new NullReferenceException();
            }
            else if (_head.Next != null)
            {
                Node current = _head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            else
            {
                CreateEmptyList();
            }
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
            else
            {
                Node current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
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
                    Node current = _head;

                    for (int i = 1; i < n; i++)
                    {
                        current = current.Next;
                    }
                    _head = current.Next;
                }
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
                Node current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                current.Next = null;
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
            else
            {
                Node current = _head;

                for (int i = 1; i < idx; i++)
                {
                    current = current.Next;
                }
                Node tmp = current;

                for (int i = 0; i < n; i++)
                {
                    current = current.Next;
                }
                tmp.Next = current.Next;
            }
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

        public int RemoveAll(int val)
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int count = 0;

            if (_head.Next != null)
            {
                Node current = _head;

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

        public bool Contains(int val)
        {
            if (_head is null)
            {
                return false;
            }
            Node current = _head;

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


        public int IndexOf(int val)
        {
            if (_head is null)
            {
                 return -1;
            }

            if (_head.Next != null)
            {
                Node current = _head;
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

            Node current = _head;

            for (int i = 0; i < idx; i++)
            {
                current = current.Next;
            }
            return current.Val;
        }

        public void Reverse()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }

            Node current = _head;

            while (current.Next != null)
            {
                Node tmp = current.Next;
                current.Next = tmp.Next;
                tmp.Next = _head;
                _head = tmp;
            }
            _tail = current;
        }

        public int Max()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int max = _head.Val;

            Node current = _head;

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

            Node current = _head;

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

        public int IndexOfMax()
        {
            if (_head is null)
            {
                return -1;
            }
            int idx = 0;
            int indexOfMax = 0;
            int max = _head.Val;

            Node current = _head;

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

            Node current = _head;

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

        public void Sort()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int length = GetLength(); //sorry for this. I know it's bad((
            Node current = _head;
            Node prev = _head;

            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    if (current.Val > current.Next.Val)
                    {
                        if (current == _head)
                        {
                            SwapConsideringHead(ref current, ref prev);
                        }
                        else
                        {
                            Swap(ref current, ref prev);

                            if (current.Next == _tail)
                            {
                                _tail = current;
                            }
                        }
                    }
                    else
                    {
                        prev = current;
                        current = current.Next;
                    }
                }
                prev = _head;
                current = _head;
            }
        }

        public void SortDesc()
        {
            if (_head is null)
            {
                throw new NullReferenceException();
            }
            int length = GetLength();
            Node current = _head;
            Node prev = _head;

            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    if (current.Val < current.Next.Val)
                    {
                        if (current == _head)
                        {
                            SwapConsideringHead(ref current, ref prev);
                        }
                        else
                        {
                            Swap(ref current, ref prev);

                            if (current.Next == _tail)
                            {
                                _tail = current;
                            }
                        }
                    }
                    else
                    {
                        prev = current;
                        current = current.Next;
                    }
                }
                prev = _head;
                current = _head;
            }
        }

        private void CreateEmptyList()
        {
            _head = null;
            _tail = null;
        }

        private void Swap(ref Node current, ref Node prev)
        {
            Node tmp = current.Next.Next;
            current.Next.Next = current;
            prev.Next = current.Next;
            current.Next = tmp;
            prev = prev.Next;
        }

        private void SwapConsideringHead(ref Node current, ref Node prev)
        {
            Node tmp = current.Next.Next;
            current.Next.Next = current;
            prev.Next = current.Next;
            _head = current.Next;
            current.Next = tmp;
            prev = _head;
        }
    }
}
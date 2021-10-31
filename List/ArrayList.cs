using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ArrayList
    {
        public int RealLength { get; private set; }
        private int[] _array;

        public ArrayList()
        {
            CreateEmpty();
        }

        public ArrayList(int val)
        {
            RealLength = 1;
            _array = new int[10];
            _array[0] = val;
        }

        public ArrayList(int[] arr)
        {
            if (arr.Length == 0)
            {
                CreateEmpty();
            }
            else
            {
                RealLength = arr.Length;
                _array = arr;
            }
        }

        public int GetLength()
        {
            return RealLength;
        }

        public int[] ToArray()
        {
            int[] arr = new int[RealLength];

            for (int i = 0; i < RealLength; i++)
            {
                arr[i] = _array[i];
            }
            return arr;
        }

        public void AddFirst(int val)
        {
            if (RealLength == _array.Length)
            {
                IncreaseSize();
            }

            for (int i = RealLength; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[0] = val;
            RealLength++;
        }

        public void AddFirst(ArrayList list)
        {
            int newLength = RealLength + list.RealLength;
            int[] tmpArr = new int[newLength];

            for (int i = list.RealLength; i < tmpArr.Length; i++)
            {
                tmpArr[i] = _array[i - list.RealLength];
            }

            for (int i = 0; i < list.RealLength; i++)
            {
                tmpArr[i] = list._array[i];
            }

            while (tmpArr.Length >= _array.Length)
            {
                IncreaseSize();
            }

            _array = tmpArr;
            RealLength = newLength;

        }

        public void AddLast(int val)
        {
            if (RealLength == _array.Length)
            {
                IncreaseSize();
            }

            _array[RealLength] = val;
            RealLength++;
        }

        public void AddLast(ArrayList list)
        {
            int newLength = RealLength + list.RealLength;

            while (newLength >= _array.Length)
            {
                IncreaseSize();
            }

            for (int i = RealLength; i < newLength; i++)
            {
                _array[i] = list._array[i - RealLength];
            }

            RealLength = newLength;
        }

        public void AddAt(int idx, int val)
        {
            if (idx >= RealLength || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (RealLength == _array.Length)
            {
                IncreaseSize();
            }

            if (idx == 0)
            {
                AddFirst(val);
            }
            else
            {
                for (int i = RealLength; i >= idx; i--)
                {
                    _array[i] = _array[i - 1];
                }

                _array[idx] = val;
                RealLength++;
            }
        }

        public void AddAt(int idx, ArrayList list)
        {
            if (RealLength == 0)
            {
                AddLast(list);
            }
            else
            {
                if (idx >= RealLength || idx < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                int newLength = RealLength + list.RealLength;
                int[] tmpArr = new int[newLength];

                for (int i = 0; i < RealLength; i++)
                {
                    tmpArr[i] = _array[i];
                }

                int j = 0;

                for (int i = RealLength - 1; i >= idx; i--)
                {
                    tmpArr[newLength - j - 1] = tmpArr[i];
                    j++;
                }

                for (int i = 0; i < list.RealLength; i++)
                {
                    tmpArr[idx + i] = list._array[i];
                }

                while (_array.Length <= newLength)
                {
                    IncreaseSize();
                }

                _array = tmpArr;
                RealLength = newLength;
            }
        }

        public void Set(int idx, int val)
        {
            if (idx >= RealLength || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[idx] = val;
        }

        public void RemoveFirst()
        {
            if (RealLength == 0)
            {
                throw new OverflowException();
            }

            for (int i = 1; i < RealLength; i++)
            {
                _array[i - 1] = _array[i];
            }

            RealLength--;

            if (RealLength < _array.Length * 0.5)
            {
                DecreaseSize();
            }
        }

        public void RemoveLast()
        {
            if (RealLength == 0)
            {
                throw new OverflowException();
            }

            RealLength--;

            if (RealLength < _array.Length * 0.5)
            {
                DecreaseSize();
            }
        }

        public void RemoveAt(int idx)
        {
            if (idx >= RealLength || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for( int i = idx + 1; i < RealLength; i++)
            {
                _array[i - 1] = _array[i];
            }

            RealLength--;

            if (RealLength < _array.Length * 0.5)
            {
                DecreaseSize();
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n > RealLength)
            {
                throw new OverflowException();
            }

            for (int i = 0; i < n; i++)
            {
                RemoveFirst();
            }
        }

        public void RemoveLastMultiple(int n)
        {
            if (n > RealLength)
            {
                throw new OverflowException();
            }

            RealLength -= n;

            if (RealLength < _array.Length * 0.5)
            {
                DecreaseSize();
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            for (int i = 0; i < n; i++)
            {
                RemoveAt(idx);
            }
        }

        public int RemoveFirst(int val)
        {
            for (int i = 0; i < RealLength; i++)
            {
                if (val == _array[i])
                {
                    RemoveAt(i);
                    return i;
                }
            }
            return -1;
        }

        public int RemoveAll(int val)
        {
            int count = 0;

            for (int i = 0; i < RealLength; i++)
            {
                if (val == _array[i])
                {
                    RemoveAt(i);
                    count++;
                    i = -1;
                }
            }
            return count;
        }

        public bool Contains(int val)
        {
            for (int i = 0; i < RealLength; i++)
            {
                if (val == _array[i])
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(int val)
        {
            for (int i = 0; i < RealLength; i++)
            {
                if (val == _array[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetFirst()
        {
            return _array[0];
        }

        public int GetLast()
        {
            return _array[RealLength - 1];
        }

        public int Get(int idx)
        {
            if (idx < 0 || idx >= RealLength)
            {
                throw new IndexOutOfRangeException();
            }
            return _array[idx];
        }

        public void Reverse()
        {
            for (int i = 0; i < RealLength / 2; i++)
            {
                Swap(ref _array[i], ref _array[RealLength - 1 - i]);
            }
        }

        public int Max()
        {
            int max = _array[0];

            for (int i = 1; i < RealLength; i++)
            {
                if (max < _array[i])
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int Min()
        {
            int min = _array[0];

            for (int i = 1; i < RealLength; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int IndexOfMax()
        {
            int indexOfMax = 0;

            for (int i = 0; i < RealLength; i++)
            {
                if (_array[indexOfMax] < _array[i])
                {
                    indexOfMax = i;
                }
            }
            return indexOfMax;
        }

        public int IndexOfMin()
        {
            int indexOfMin = 0;

            for (int i = 0; i < RealLength; i++)
            {
                if (_array[indexOfMin] > _array[i])
                {
                    indexOfMin = i;
                }
            }
            return indexOfMin;
        }

        public void Sort()
        {
            for (int i = 0; i < RealLength - 1; i++)
            {
                int indexOfMin = i;

                for (int j = i; j < RealLength; j++)
                {
                    if (_array[indexOfMin] > _array[j])
                    {
                        indexOfMin = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[indexOfMin];
                _array[indexOfMin] = tmp;
            }
        }

        public void SortDesc()
        {
            for (int i = 1; i < RealLength; i++)
            {
                int j;
                int tmp = _array[i];

                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] > tmp)
                        break;

                    _array[j + 1] = _array[j];
                }
                _array[j + 1] = tmp;
            }
        }

        private void IncreaseSize()
        {
            int newLength = (_array.Length * 3) / 2 + 1;
            int[] tmpArr = new int[newLength];

            for (int i = 0; i < _array.Length; i++)
            {
                tmpArr[i] = _array[i];
            }

            _array = tmpArr;
        }
        private void DecreaseSize()
        {
            int newLength = (_array.Length * 2) / 3;
            int[] tmpArr = new int[newLength];

            for (int i = 0; i < newLength; i++)
            {
                tmpArr[i] = _array[i];
            }
            _array = tmpArr;
        }

        private void CreateEmpty()
        {
            RealLength = 0;
            _array = new int[10];
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }


    }
}

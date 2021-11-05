using System;

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
            else if (arr.Length < 10)
            {
                RealLength = arr.Length;
                _array = new int[10];
                AddElementsToArray(arr, RealLength);
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
                IncreaseSize(_array.Length);
            }

            MoveElementsToTheRight(1);

            _array[0] = val;
            RealLength++;
        }

        public void AddFirst(ArrayList list)
        {
            if (list.RealLength == 1)
            {
                AddFirst(list._array[0]);
            }
            else if (list.RealLength <= (_array.Length - RealLength))
            {
                MoveElementsToTheRight(list.RealLength);
                AddElementsToArray(list._array, list.RealLength);
                RealLength += list.RealLength;
            }
            else
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

                IncreaseSize(newLength);

                _array = tmpArr;
                RealLength = newLength;
            }
        }

        public void AddLast(int val)
        {
            if (RealLength == _array.Length)
            {
                IncreaseSize(_array.Length);
            }

            _array[RealLength] = val;
            RealLength++;
        }

        public void AddLast(ArrayList list)
        {
            int newLength = RealLength + list.RealLength;

            if (newLength >= _array.Length)
            {
                 IncreaseSize(newLength);
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
                IncreaseSize(_array.Length);
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
            if (idx >= RealLength || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (list.RealLength <= (_array.Length - RealLength))
            {
                for (int i = RealLength - 1; i >= idx; i--)
                {
                    _array[i + list.RealLength] = _array[i];
                }

                for (int i = 0; i < list.RealLength; i++)
                {
                    _array[idx + i] = list._array[i]; 
                }
                RealLength += list.RealLength;
            }
            else
            {
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
                throw new ArgumentException("Список пуст");
            }

            for (int i = 1; i < RealLength; i++)
            {
                _array[i - 1] = _array[i];
            }

            RealLength--;

            if (RealLength < _array.Length * 2 / 3)
            {
                DecreaseSize();
            }
        }

        public void RemoveLast()
        {
            if (RealLength == 0)
            {
                throw new ArgumentException("Список пуст");
            }

            RealLength--;

            if (RealLength < _array.Length * 2 / 3)
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

            if (RealLength < _array.Length * 2 / 3)
            {
                DecreaseSize();
            }
        }

        public void RemoveFirstMultiple(int n)
        {
            if (n > RealLength)
            {
                throw new ArgumentException("Кол-во элементов массива меньше введенного n");
            }
            else if (n == 1)
            {
                RemoveFirst();
            }
            else
            {
                int[] tmpArr = new int[RealLength - n];

                for (int i = 0; i < tmpArr.Length; i++)
                {
                    tmpArr[i] = _array[i + n];
                }

                _array = tmpArr;
                RealLength -= n;

                if (RealLength < _array.Length * 2 / 3)
                {
                    DecreaseSize();
                }
            }
        }

        public void RemoveLastMultiple(int n)
        {
            if (n > RealLength)
            {
                throw new ArgumentException("Кол-во элементов массива меньше введенного n");
            }

            RealLength -= n;

            if (RealLength < _array.Length * 2 / 3)
            {
                DecreaseSize();
            }
        }

        public void RemoveAtMultiple(int idx, int n)
        {
            if (idx >= RealLength || idx < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (n > RealLength)
            {
                throw new ArgumentException("Кол-во элементов массива меньше введенного n");
            }
            else if (n == 1 && idx == 0)
            {
                RemoveFirst();
            }
            else
            {
                int[] tmpArr = _array;

                for (int i = idx; i < RealLength - n; i++)
                {
                    tmpArr[i] = _array[i + n];
                }

                RealLength -= n;

                if (RealLength < _array.Length * 2 / 3)
                {
                    DecreaseSize();
                }
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
            int count = 0;

            for (int i = 0; i < RealLength; i++)
            {
                if (_array[i] == val)
                {
                    for (int j = i; j < RealLength - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    count++;
                    RealLength--;

                    if (RealLength < _array.Length * 2 / 3)
                    {
                        DecreaseSize();
                    }

                    i--;
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
            if (RealLength == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return _array[0];
        }

        public int GetLast()
        {
            if (RealLength == 0)
            {
                throw new IndexOutOfRangeException();
            }
            return _array[RealLength - 1];
        }

        public int Get(int idx)
        {
            if (idx < 0 || idx >= RealLength)
            {
                throw new IndexOutOfRangeException();
            }
            if (RealLength == 0)
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
            if (RealLength == 0)
            {
                throw new ArgumentException("Список пуст");
            }
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
            if (RealLength == 0)
            {
                throw new ArgumentException("Список пуст");
            }
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

            if (RealLength > 0)
            {
                for (int i = 0; i < RealLength; i++)
                {
                    if (_array[indexOfMax] < _array[i])
                    {
                        indexOfMax = i;
                    }
                }
                return indexOfMax;
            }
            else return -1;
        }

        public int IndexOfMin()
        {
            int indexOfMin = 0;

            if (RealLength > 0)
            {
                for (int i = 0; i < RealLength; i++)
                {
                    if (_array[indexOfMin] > _array[i])
                    {
                        indexOfMin = i;
                    }
                }
                return indexOfMin;
            }
            else return -1;
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
                Swap(ref _array[i], ref _array[indexOfMin]); 
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

        private void AddElementsToArray(int[] arr, int length)
        {
            for (int i = 0; i < length; i++)
            {
                _array[i] = arr[i];
            }
        }
        private void IncreaseSize(int length)
        {
            int newLength = (length * 3) / 2 + 1;
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

        private void MoveElementsToTheRight(int length)
        {
            for (int i = RealLength; i > 0; i--)
            {
                _array[i + length - 1] = _array[i - 1];
            }
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

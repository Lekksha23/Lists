using NUnit.Framework;
using System;


namespace List.Tests
{
    public class LinkedListTests
    {
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 8 }, 1)]
        [TestCase(new int[] { 2, 2, 2, 2 }, 4)]
        [TestCase(new int[] { 2, 2, 2, 2, 4, 12, 23, 34, 23, 34, 35 }, 11)]
        public void GetLengthTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act

            //assert
            Assert.AreEqual(expected, list.GetLength());
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 8 }, new int[] { 8 })]
        [TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 254, 23, -46 }, new int[] { 1, 254, 23, -46 })]
        [TestCase(new int[] { 1, 254, 23, -46, 23, 42, 12, 3, 4, 45, 23 }, new int[] { 1, 254, 23, -46, 23, 42, 12, 3, 4, 45, 23 })]
        public void ToArrayTest(int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(new int[] { }, 42, new int[] { 42 })]
        [TestCase(new int[] { 8 }, 42, new int[] { 42, 8 })]
        [TestCase(new int[] { 8, 5, 3 }, 42, new int[] { 42, 8, 5, 3 })]
        [TestCase(new int[] { 8, 5, 3, 8, 5, 3, 8, 5, 3, 8, 5, 3 }, 42, new int[] { 42, 8, 5, 3, 8, 5, 3, 8, 5, 3, 8, 5, 3 })]
        public void AddFirstTest(int[] array, int val, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.AddFirst(val);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(new int[] { 42 }, new int[] { }, new int[] { 42 })]
        [TestCase(new int[] { }, new int[] { 42 }, new int[] { 42 })]
        [TestCase(new int[] { 34, 34, 34 }, new int[] { 20, 20, 20 }, new int[] { 20, 20, 20, 34, 34, 34 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void AddFirstTest(int[] arr1, int[] arr2, int[] expected)
        {
            //arrange
            LinkedList list1 = new LinkedList(arr1);
            LinkedList list2 = new LinkedList(arr2);

            //act
            list1.AddFirst(list2);

            //assert
            Assert.AreEqual(expected, list1.ToArray());
        }

        [TestCase(new int[] { }, 42, new int[] { 42 })]
        [TestCase(new int[] { 8 }, 42, new int[] { 8, 42 })]
        [TestCase(new int[] { 8, 5, 3 }, 42, new int[] { 8, 5, 3, 42 })]
        [TestCase(new int[] { 8, 5, 3, 8, 5, 3, 8, 5, 3, 8, 5, 3 }, 42, new int[] { 8, 5, 3, 8, 5, 3, 8, 5, 3, 8, 5, 3, 42 })]
        public void AddLastTest(int[] array, int val, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.AddLast(val);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(new int[] { 42 }, new int[] { }, new int[] { 42 })]
        [TestCase(new int[] { }, new int[] { 42, 42, 42 }, new int[] { 42, 42, 42 })]
        [TestCase(new int[] { 34, 34, 34 }, new int[] { 20, 20, 20 }, new int[] { 34, 34, 34, 20, 20, 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 })]
        public void AddLastTest(int[] arr1, int[] arr2, int[] expected)
        {
            //arrange
            LinkedList list1 = new LinkedList(arr1);
            LinkedList list2 = new LinkedList(arr2);

            //act
            list1.AddLast(list2);

            //assert
            Assert.AreEqual(expected, list1.ToArray());
        }

        [TestCase(new int[] { 5 }, 0, 42, new int[] { 42, 5 })]
        [TestCase(new int[] { 23, 23, 23, 23 }, 2, 42, new int[] { 23, 23, 42, 23, 23 })]
        [TestCase(new int[] { 8, 5, 3, 23 }, 3, 42, new int[] { 8, 5, 3, 42, 23 })]
        public void AddAtTest(int[] array, int idx, int val, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.AddAt(idx, val);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(-1, 23, new int[] { 23, 42 })]
        [TestCase(2, 23, new int[] { 23, 42 })]
        public void AddAtNegativeTest(int idx, int val, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(IndexOutOfRangeException), () => list.AddAt(idx, val));
        }

        [TestCase(1, new int[] { 34, 34, 34 }, new int[] { 20 }, new int[] { 34, 20, 34, 34 })]
        [TestCase(0, new int[] { 34 }, new int[] { 20, 20, 20 }, new int[] { 20, 20, 20, 34 })]
        [TestCase(2, new int[] { 34, 34, 34 }, new int[] { 20, 20, 20 }, new int[] { 34, 34, 20, 20, 20, 34 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, new int[] { 1, 2, 3, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 4, 5, 6, 7, 8, 9, })]
        public void AddAtTest(int idx, int[] arr1, int[] arr2, int[] expected)
        {
            //arrange
            LinkedList list1 = new LinkedList(arr1);
            LinkedList list2 = new LinkedList(arr2);

            //act
            list1.AddAt(idx, list2);

            //assert
            Assert.AreEqual(expected, list1.ToArray());
        }

        [TestCase(0, new int[] { 42 }, new int[] { })]
        [TestCase(0, new int[] { }, new int[] { 42 })]
        public void AddAtNegativeTest1(int idx, int[] arr1, int[] arr2)
        {
            //arrange
            LinkedList list1 = new LinkedList(arr1);
            LinkedList list2 = new LinkedList(arr2);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list1.AddAt(idx, list2));
        }

        [TestCase(-1, new int[] { 42 }, new int[] { 34 })]
        [TestCase(1, new int[] { 23 }, new int[] { 42 })]
        public void AddAtNegativeTest2(int idx, int[] arr1, int[] arr2)
        {
            //arrange
            LinkedList list1 = new LinkedList(arr1);
            LinkedList list2 = new LinkedList(arr2);

            //act, assert
            Assert.Throws(typeof(IndexOutOfRangeException), () => list1.AddAt(idx, list2));
        }

        [TestCase(new int[] { 5 }, 0, 42, new int[] { 42 })]
        [TestCase(new int[] { 23, 23, 23, 23 }, 0, 42, new int[] { 42, 23, 23, 23 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3 }, 2, 42, new int[] { 3, 3, 42, 3, 3 })]
        [TestCase(new int[] { 3, 3, 3, 3, 3 }, 1, 42, new int[] { 3, 42, 3, 3, 3 })]
        [TestCase(new int[] { 8, 5, 3, 23 }, 3, 42, new int[] { 8, 5, 3, 42 })]
        public void SetTest(int[] array, int idx, int val, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.Set(idx, val);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(0, 23, new int[] { })]
        [TestCase(-1, 23, new int[] { 23, 42 })]
        [TestCase(2, 23, new int[] { 23, 42 })]
        public void SetNegativeTest(int idx, int val, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(IndexOutOfRangeException), () => list.Set(idx, val));
        }

        [TestCase(new int[] { 7 }, new int[] { })]
        [TestCase(new int[] { 5, 6, 7 }, new int[] { 6, 7 })]
        public void RemoveFirstTest(int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.RemoveFirst();

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(new int[] { })]
        public void RemoveFirstNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.RemoveFirst());
        }

        [TestCase(new int[] { 7 }, new int[] { })]
        [TestCase(new int[] { 5, 6, 7 }, new int[] { 5, 6 })]
        public void RemoveLastTest(int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.RemoveLast();

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(new int[] { })]
        public void RemoveLastNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.RemoveLast());
        }

        [TestCase(0, new int[] { 7 }, new int[] { })]
        [TestCase(2, new int[] { 5, 6, 7 }, new int[] { 5, 6 })]
        [TestCase(2, new int[] { 5, 6, 7, 42 }, new int[] { 5, 6, 42 })]
        public void RemoveAtTest(int idx, int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.RemoveAt(idx);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(-1, new int[] { 23, 42 })]
        [TestCase(2, new int[] { 23, 42 })]
        public void RemoveAtNegativeTest1(int idx, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(IndexOutOfRangeException), () => list.RemoveAt(idx));
        }

        [TestCase(0, new int[] { })]
        public void RemoveAtNegativeTest2(int idx, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.RemoveAt(idx));
        }

        [TestCase(0, new int[] { 7 }, new int[] { 7 })]
        [TestCase(1, new int[] { 7 }, new int[] { })]
        [TestCase(4, new int[] { 5, 6, 7, 42 }, new int[] { })]
        [TestCase(6, new int[] { 5, 6, 7, 42, 54, 12, 23, 42 }, new int[] { 23, 42 })]
        public void RemoveFirstMultipleTest(int n, int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.RemoveFirstMultiple(n);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(3, new int[] { 23, 42 })]
        public void RemoveFirstMultipleNegativeTest(int n, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(ArgumentException), () => list.RemoveFirstMultiple(n));
        }

        [TestCase(0, new int[] { 7 }, new int[] { 7 })]
        [TestCase(1, new int[] { 7 }, new int[] { })]
        [TestCase(4, new int[] { 5, 6, 7, 42 }, new int[] { })]
        [TestCase(6, new int[] { 5, 6, 7, 42, 54, 12, 23, 42 }, new int[] { 5, 6 })]
        public void RemoveLastMultipleTest(int n, int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.RemoveLastMultiple(n);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(3, new int[] { 23, 42 })]
        public void RemoveLastMultipleNegativeTest(int n, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(ArgumentException), () => list.RemoveLastMultiple(n));
        }

        [TestCase(0, 0, new int[] { 7 }, new int[] { 7 })]
        [TestCase(0, 1, new int[] { 7 }, new int[] { })]
        [TestCase(0, 8, new int[] { 5, 6, 7, 42, 54, 12, 23, 42 }, new int[] { })]
        [TestCase(3, 3, new int[] { 5, 6, 7, 42, 54, 12, 23, 42 }, new int[] { 5, 6, 7, 23, 42 })]
        [TestCase(3, 5, new int[] { 5, 6, 7, 42, 54, 12, 23, 42 }, new int[] { 5, 6, 7 })]
        public void RemoveAtMultipleTest(int idx, int n, int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.RemoveAtMultiple(idx, n);

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(7, new int[] { 7 }, 0)]
        [TestCase(15, new int[] { 7, 23, 42 }, -1)]
        [TestCase(54, new int[] { 5, 6, 7, 42, 54, 54, 54, 42 }, 4)]
        [TestCase(42, new int[] { 5, 6, 7, 13, 54, 12, 23, 42 }, 7)]
        public void RemoveFirstTest(int val, int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.RemoveFirst(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { 7 }, 1)]
        [TestCase(15, new int[] { 7, 23, 42 }, 0)]
        [TestCase(54, new int[] { 5, 6, 7, 42, 54, 54, 54, 54 }, 4)]
        [TestCase(42, new int[] { 42, 42, 42, 13, 54, 42, 23, 42 }, 5)]
        public void RemoveAllTest(int val, int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.RemoveAll(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { }, false)]
        [TestCase(7, new int[] { 7 }, true)]
        [TestCase(15, new int[] { 7, 23, 42 }, false)]
        [TestCase(42, new int[] { 3, 7, 4, 13, 54, 7, 23, 42 }, true)]
        public void ContainsTest(int val, int[] array, bool expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            bool actual = list.Contains(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { }, -1)]
        [TestCase(7, new int[] { 7 }, 0)]
        [TestCase(15, new int[] { 7, 23, 42 }, -1)]
        [TestCase(42, new int[] { 3, 7, 4, 13, 54, 7, 23, 42 }, 7)]
        [TestCase(13, new int[] { 3, 7, 4, 13, 54, 7, 23, 42 }, 3)]
        public void IndexOfTest(int val, int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.IndexOf(val);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7 }, 7)]
        [TestCase(new int[] { -3, 7, 4, 13, 54, 7, 23, 42 }, -3)]
        public void GetFirstTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.GetFirst();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetFirstNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.GetFirst());
        }

        [TestCase(new int[] { 56 }, 56)]
        [TestCase(new int[] { -3, 7, 4, 13, 54, 7, 23, -42 }, -42)]
        public void GetLastTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.GetLast();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetLastNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.GetLast());
        }

        [TestCase(0, new int[] { 7 }, 7)]
        [TestCase(7, new int[] { -3, 7, 4, 13, 54, 7, 23, -42 }, -42)]
        [TestCase(4, new int[] { -3, 7, 4, 13, 54, 7, 23, -42 }, 54)]
        public void GetTest(int idx, int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.Get(idx);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, new int[] { 23, 42 })]
        [TestCase(2, new int[] { 23, 42 })]
        public void GetNegativeTest1(int idx, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(IndexOutOfRangeException), () => list.Get(idx));
        }

        [TestCase(0, new int[] { })]
        public void GetNegativeTest2(int idx, int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.Get(idx));
        }

        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 2, 2, 2 }, new int[] { 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 7, 1, 2, 5 }, new int[] { 5, 2, 1, 7 })]
        public void ReverseTest(int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.Reverse();

            //assert
            Assert.AreEqual(expected, list.ToArray());
        }

        [TestCase(new int[] { })]
        public void ReverseNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act

            //assert
            Assert.Throws(typeof(NullReferenceException), () => list.Reverse());
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 7, 6, 10, 20, -5, 23 }, 23)]
        [TestCase(new int[] { 99, 6, 10, 20, 45, 23 }, 99)]
        [TestCase(new int[] { 34, 6, 10, 99, 45, 23 }, 99)]
        public void MaxTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.Max();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void MaxNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.Max());
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 7, 6, 10, 20, 56, -5 }, -5)]
        [TestCase(new int[] { 99, 7, 10, 6, 45, 23 }, 6)]
        [TestCase(new int[] { -9, 7, 10, 6, 45, 23 }, -9)]
        public void MinTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.Min();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void MinNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.Min());
        }

        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { 5 }, 0)]
        [TestCase(new int[] { 7, 6, 10, 20, -5, 23 }, 5)]
        [TestCase(new int[] { 27, 6, 10, 20, -5, 23 }, 0)]
        public void IndexOfMaxTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.IndexOfMax();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, -1)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 7, 6, 10, 20, -5, 23 }, 4)]
        [TestCase(new int[] { -5, 6, 10, 20, 45, 23 }, 0)]
        public void IndexOfMinTest(int[] array, int expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            int actual = list.IndexOfMin();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 3, 1, 4, 2 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 3, 1 }, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 8, 7, 6, 5 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        public void SortTest(int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.Sort();
            int[] actual = list.ToArray();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void SortNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.Sort());
        }

        [TestCase(new int[] { 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 3 }, new int[] { 3, 1 })]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 4, 3, 2, 1, 8, 7, 6, 5 }, new int[] { 8, 7, 6, 5, 4, 3, 2, 1 })]
        public void SortDescTest(int[] array, int[] expected)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act
            list.SortDesc();
            int[] actual = list.ToArray();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void SortDescNegativeTest(int[] array)
        {
            //arrange
            LinkedList list = new LinkedList(array);

            //act, assert
            Assert.Throws(typeof(NullReferenceException), () => list.SortDesc());
        }
    }
}

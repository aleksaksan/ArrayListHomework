using NUnit.Framework;

namespace MyArrayList.Test
{
    public class Tests
    {
        ArrayList _arrlist;
        [SetUp]
        public void Setup()
        {
            _arrlist = new ArrayList();
        }

        [Test]
        public void CtorTest()
        {
            //act
            ArrayList list = new ArrayList();
            int actualLength = list.Length;
            int actualCapacity = list.GetCapacity();
            //assert
            Assert.AreEqual(0, actualLength);
            Assert.AreEqual(10, actualCapacity);
        }
        [TestCase(0, new int[] { }, 0, 10)]
        [TestCase(9, new int[] { }, 0, 10)]
        [TestCase(11, new int[] { }, 0, 11)]
        public void CtorWithNumTest(int num, int[] expectedArr, int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(num);
            int actualLength = list.Length;
            int actualCapacity = list.GetCapacity();
            //act

            int[] actualArr = list.ToArray();
            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [TestCase(new int[] { 0 }, new int[] { 0 }, 1, 10)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 3, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 11, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, 12)]
        public void CtorWithArrTest(int[] OriginArr, int[] expectedArr, int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(OriginArr);
            int actualLength = list.Length;
            int actualCapacity = list.GetCapacity();

            //act
            int[] actualArr = list.ToArray();
            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        // public int GetLength()
        [TestCase(new int[] { 0 }, new int[] { 0 }, 1, 10)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 3, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 11, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, 12)]
        public void GetLengthTest(int[] originArr, int[] expectedArr, int expectedLength, int expectedCapacity)
        {
            //arrnage
            ArrayList list = new ArrayList(originArr);
            int actualCapacity = list.GetCapacity();
            //act
            int actualLength = list.GetLength();
            int[] actualArr = list.ToArray();
            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddFirst(int val) - ���������� � ������ ������
        [TestCase(0, new int[] { }, new int[] { 0 }, 1, 10)]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 2, 3 }, 4, 10)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 12, 17)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 13, 19)]
        public void AddFirstTest(int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.AddFirst(val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddFirst(ArrayList list) ���������� � ������ ������ (�.�. ������� ���� �������)
        [TestCase(new int[] { 0, 0, 0 }, new int[] { }, new int[] { 0, 0, 0 }, 3, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 0, 0, 0, 1, 2, 3 }, 6, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 14, 17)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 20, 29)]
        public void AddListFirstTest(int[] val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList valArr = new ArrayList(val);
            ArrayList list = new ArrayList(originArr);

            //act

            list.AddFirst(valArr);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        //AddLast(int val) - ���������� � ����� ������

        [TestCase(0, new int[] { }, new int[] { 0 }, 1, 10)]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 0, }, 4, 10)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, }, 12, 17)]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, }, 13, 19)]
        public void AddLastTest(int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.AddLast(val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddLast(ArrayList list) - �� �� �����, �� � ����� ����������� �������
        [TestCase(new int[] { 0, 0, 0 }, new int[] { }, new int[] { 0, 0, 0 }, 3, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 0, 0, 0, }, 6, 10)]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 0, 0, }, 14, 17)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 0, 0, 0, 0, 0, 0, 0, }, 20, 29)]
        public void AddListLastTest(int[] val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList valArr = new ArrayList(val);
            ArrayList list = new ArrayList(originArr);

            //act

            list.AddLast(valArr);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        //AddAt(int idx, int val) - ������� �� ���������� �������
        //[TestCase(0, new int[] { }, new int[] { 0 }, 1, 10)]
        [TestCase(2, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 0, 3, }, 4, 10)]
        [TestCase(2, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 12, 17)]
        [TestCase(2, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 13, 19)]
        public void AddAtTest(int idx, int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.AddAt(idx, val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //AddAt(int idx, ArrayList list) - �� �� �����, �� � ����� ����������� �������
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 0, 0, 0, 3, }, 6, 10)]
        [TestCase(2, new int[] { 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 0, 0, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 14, 17)]
        [TestCase(2, new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 20, 29)]
        public void AddListAtTest(int idx, int[] val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList valArr = new ArrayList(val);
            ArrayList list = new ArrayList(originArr);

            //act

            list.AddAt(idx, valArr);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //Set(int idx, int val) - �������� �������� �������� � ��������� ��������
        [TestCase(1, 0, new int[] { 1, 2, 3 }, new int[] { 1, 0, 3, }, 3, 10)]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 11, 11)]
        [TestCase(1, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 12, 12)]
        public void SetTest(int idx, int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.Set(idx, val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveFirst() - �������� ������� ��������
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, }, 2, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 10, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 11, 12)]
        public void RemoveFirstTest(int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.RemoveFirst();

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveLast() - �������� ���������� ��������
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, }, 2, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, 11)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, }, 11, 12)]
        public void RemoveLastTest(int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.RemoveLast();

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveAt(int idx) - �������� �� �������
        [TestCase(1, new int[] { 1, 2, 3 }, new int[] { 1, 3 }, 2, 10)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 10, 11)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 12)]
        public void RemoveAtTest(int idx, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.RemoveAt(idx);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveFirstMultiple(int n) - �������� ������ n ���������

        //[TestCase(3, new int[] { 1, 2, 3 }, new int[] { }, 0, 10)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 4, 5, 6, 7, 8, 9, 10, 11, }, 8, 11)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, }, 9, 12)]
        public void RemoveFirstMultipleTest(int n, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.RemoveFirstMultiple(n);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        //RemoveLastMultiple(int n) - �������� ��������� n ���������
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, }, 8, 11)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, 12)]
        public void RemoveLastMultipleTest(int n, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.RemoveLastMultiple(n);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        //RemoveAtMultiple(int idx, int n) - �������� n ���������, ������� � ���������� �������
        [TestCase(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 2, 3, 7, 8, 9, 10, 11 }, 8, 11)]
        [TestCase(3, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 2, 3, 7, 8, 9, 10, 11, 12 }, 9, 12)]
        public void RemoveAtMultipleTest(int idx, int n, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.RemoveAtMultiple(idx, n);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        //RemoveFirst(int val) - ������� ������ ���������� �������,
        //�������� �������� ����� val (������� ������ ��������� ��������)

        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 3 }, 2, 10, 1)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 10, 11, 1)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 12, 1)]
        public void RemoveFirstValTest(int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity, int expectedIdx)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act
            int actualIdx = list.RemoveFirst(val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedIdx, actualIdx);
        }
        //RemoveAll(int val) - ������� ��� ��������, ������ val (������� ���-�� �������� ���������)

        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 3 }, 2, 10, 1)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10, 2 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10 }, 9, 13, 4)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                    new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 12, 1)]
        public void RemoveAllTest(int val, int[] originArr, int[] expectedArr,
            int expectedLength, int expectedCapacity, int expectedVal)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            int actualNum = list.RemoveAll(val);

            int[] actualArr = list.ToArray();
            int actualLength = list.GetLength();
            int actualCapacity = list.GetCapacity();

            //assert
            Assert.AreEqual(expectedArr, actualArr);
            Assert.AreEqual(expectedLength, actualLength);
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedVal, actualNum);
        }

        //Contains(int val) - ��������, ���� �� ������� � ������

        [TestCase(2, new int[] { 1, 2, 3 }, true)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10, 2 }, true)]
        [TestCase(2, new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, false)]
        public void ContainsTest(int val, int[] originArr, bool expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            bool actual = list.Contains(2);

            //assert

            Assert.AreEqual(expected, actual);
        }

        //IndexOf(int val) - ����� ������ ������� ���������� ��������,
        //������� val (��� -1, ���� ��������� � ����� ��������� � ������ ���)
        [TestCase(2, new int[] { 1, 2, 3 }, 1)]
        [TestCase(2, new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10, 2 }, 1)]
        [TestCase(2, new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 2 }, 11)]
        public void IndexOfTest(int val, int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.IndexOf(2);

            //assert

            Assert.AreEqual(expected, actual);
        }

        //GetFirst() - ����� �������� ������� �������� ������
        [TestCase(new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10, 2 }, 1)]
        [TestCase(new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 2 }, 1)]
        public void GetFirstTest(int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.GetFirst();

            //assert

            Assert.AreEqual(expected, actual);
        }
        //GetLast() - ����� �������� ���������� �������� ������

        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10 }, 10)]
        [TestCase(new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12)]
        public void GetLastTest(int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.GetLast();

            //assert

            Assert.AreEqual(expected, actual);
        }
        //Get(int idx) - ����� �������� �������� ������ c ��������� ��������
        [TestCase(2, new int[] { 1, 2, 3 }, 3)]
        [TestCase(3, new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10 }, 4)]
        [TestCase(9, new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11)]
        public void GetTest(int idx, int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.Get(idx);

            //assert

            Assert.AreEqual(expected, actual);
        }

        //Reverse() - ��������� ������� ��������� ������ �� ��������
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 9, 8, 7, 6, 5, 2, 2, 4, 3, 2, 1, })]
        [TestCase(new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, new int[] { 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 1 })]
        public void ReverseTest(int[] originArr, int[] expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.Reverse();
            var actual = list.ToArray();
            //assert

            Assert.AreEqual(expected, actual);
        }

        //Max() - ����� �������� ������������� ��������
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 42, 2, 2, 5, 6, 7, 8, 9, 10 }, 42)]
        [TestCase(new int[] { 1, 3, 42, 5, 6, 7, 8, 9, 10, 11, 12 }, 42)]
        public void MaxTest(int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.Max();

            //assert

            Assert.AreEqual(expected, actual);
        }

        //Min() - ����� �������� ������������� ��������
        [TestCase(new int[] { 1, 2, -3 }, -3)]
        [TestCase(new int[] { 1, 2, 3, -42, 2, 2, 5, 6, 7, 8, 9, 10 }, -42)]
        [TestCase(new int[] { 1, 3, -42, 5, 6, 7, 8, 9, 10, 11, 12 }, -42)]
        public void MinTest(int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.Min();

            //assert

            Assert.AreEqual(expected, actual);
        }
        //IndexOfMax() - ����� ������ ������������� ��������
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { 1, 2, 3, -42, 42, 2, 5, 6, 7, 8, 9, 10 }, 4)]
        [TestCase(new int[] { 1, 3, -42, 5, 6, 7, 8, 9, 10, 11, 42 }, 10)]
        public void IndexOfMaxTest(int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.IndexOfMax();

            //assert

            Assert.AreEqual(expected, actual);
        }
        //IndexOfMin() - ����� ������ ������������ ��������
        [TestCase(new int[] { 1, 2, 3 }, 0)]
        [TestCase(new int[] { 1, 2, 3, -42, 42, 2, 5, 6, 7, 8, 9, 10 }, 3)]
        [TestCase(new int[] { 1, 3, -42, 5, 6, 7, 8, 9, 10, -55, 42 }, 9)]
        public void IndexOfMinTest(int[] originArr, int expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            var actual = list.IndexOfMin();

            //assert

            Assert.AreEqual(expected, actual);
        }
        //Sort() - ���������� �� �����������

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10 },
            new int[] { 1, 2, 2, 2, 3, 4, 5, 6, 7, 8, 9, 10, })]
        [TestCase(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void SortTest(int[] originArr, int[] expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.Sort();
            var actual = list.ToArray();
            //assert

            Assert.AreEqual(expected, actual);
        }
        //SortDesc() - ���������� �� ��������

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 2, 2, 5, 6, 7, 8, 9, 10 },
            new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 2, 2, 1, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        public void SortDesc(int[] originArr, int[] expected)
        {
            //arrange
            ArrayList list = new ArrayList(originArr);

            //act

            list.SortDesc();
            var actual = list.ToArray();
            //assert

            Assert.AreEqual(expected, actual);
        }
    }
}
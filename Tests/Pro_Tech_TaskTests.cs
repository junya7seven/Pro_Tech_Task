using Pro_Tech_Task.StringOper;
namespace Tests
{
    [TestFixture]
    public class Pro_Tech_TaskTests
    {
        // ������ ������ ������ ���� �������� �������, ������ �������� ������ ���� ����������� � ���������
        // �������� ������ ������ ���� ����������� � ��������� � ����������� ������
        [TestCase("a", "aa")]
        [TestCase("abcdef", "cbafed")]
        [TestCase("abcde", "edcbaabcde")]
        public void StringSplit_ReturnsCorrectResult(string input, string expected)
        {
            var stringOperation = new StringOperation(input);

            var result = stringOperation.StringSplit();

            Assert.AreEqual(expected, result);
        }

        // ������� ������ ��������� ���� ��������� ������� � ��� ���-��

        [Test]
        [TestCase("abcde", 5)]
        [TestCase("abcdeabcde", 5)]
        [TestCase("abcdeitz", 8)]
        public void CountPrint_ReturnsCorrectDictionary(string input, int expectedCount)
        {
            var stringOperation = new StringOperation(input);
            var result = stringOperation.CountPrint();
            Dictionary<char, int> expectedDictionary = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (expectedDictionary.ContainsKey(c))
                {
                    expectedDictionary[c]++;
                }
                else
                {
                    expectedDictionary[c] = 1;
                }
            }
            Assert.AreEqual(expectedCount, result.Count);

            foreach (var pair in expectedDictionary)
            {
                Assert.IsTrue(result.ContainsKey(pair.Key));
                Assert.AreEqual(pair.Value, result[pair.Key]);
            }
        }


        // ������ ������ ���������� � ������������� �� �������, ���� "������� ���"
        [TestCase("a", "aa")]
        [TestCase("abcdef", "afe")]
        [TestCase("abcde", "edcbaabcde")]
        [TestCase("qwqwqwq", "������� ���")]
        public void FindLargestVowelSubstring_ReturnsCorrectResult(string input, string expected)
        {
            var stringOperation = new StringOperation(input);
            var modString = stringOperation.StringSplit();
            var result = stringOperation.FindLargestVowelSubstring(modString);


            Assert.AreEqual(expected, result);
        }


        // ������ ������ �������� ������ ���������� �������� �������
        [TestCase("abc123", new char[] { '1', '2', '3' })]
        [TestCase("abcdefgh$@AS", new char[] { '$', '@', 'A', 'S' })]
        public void IsTrueString_ReturnsCorrectHashSet(string input, char[] expected)
        {
            var stringOperation = new StringOperation(input);
            var result = stringOperation.isTrueString();

            Assert.AreEqual(expected, result);
        }


        // ������ ������ ���� ������������� �� �������� 
        [TestCase("edcba", "abcde", "abcde")] 
        [TestCase("edcba", "abcde", "abcde")]
        [TestCase("abc", "abc", "abc")]
        [TestCase("dcba", "abcd", "abcd")]
        public void QuickSortAndTreeSort_ValidInput_ReturnsSortedString(string input, string expectedQuick, string expectedTree)
        {
            Sort sort = new Sort();
            string resultQuick = sort.QuickSort(input);
            string resultTree = sort.TreeSort(input);

            Assert.AreEqual(expectedQuick, resultQuick);
            Assert.AreEqual(expectedTree, resultTree);
        }


        // ������ �� ������ ��������� 1 ������
        [Test]
        public async Task RemoveCharAtIndex_ValidInput_ReturnsStringWithoutCharAtIndex()
        {
            RandomNumber rnd = new RandomNumber();
            string test1 = "asdasw";
            int index = 1;
            string result = await rnd.RemoveCharAtIndex(test1,index);
            Assert.AreEqual(test1.Length-1,result.Length);
        }


    }
}
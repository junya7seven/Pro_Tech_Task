using Pro_Tech_Task.StringOper;
namespace Tests
{
    [TestFixture]
    public class Pro_Tech_TaskTests
    {
        // Четная строка должна быть поделена пополам, каждая половина должна быть перевернута и соеденина
        // Нечетная строка должна быть перевернута и добавлена к изначальной строке
        [TestCase("a", "aa")]
        [TestCase("abcdef", "cbafed")]
        [TestCase("abcde", "edcbaabcde")]
        public void StringSplit_ReturnsCorrectResult(string input, string expected)
        {
            var stringOperation = new StringOperation(input);

            var result = stringOperation.StringSplit();

            Assert.AreEqual(expected, result);
        }

        // Словарь должен содержать один экземпляр символа и его кол-во

        [Test]
        public void CountPrint_ReturnsCorrectCharacterCounts()
        {
            // Arrange
            string input = "abbcc";
            StringOperation stringOperation = new StringOperation(input);

            // Act
            Dictionary<char, int> result = new Dictionary<char, int>(stringOperation.CountPrint(input));

            // Assert
            Assert.AreEqual(1, result['a']);
            Assert.AreEqual(2, result['b']);
            Assert.AreEqual(2, result['c']);
        }


        // строка должна начинаться и заканчиваться на гласную, либо "Гласных нет"
        [TestCase("a", "aa")]
        [TestCase("abcdef", "afe")]
        [TestCase("abcde", "edcbaabcde")]
        [TestCase("qwqwqwq", "Гласных нет")]
        public void FindLargestVowelSubstring_ReturnsCorrectResult(string input, string expected)
        {
            var stringOperation = new StringOperation(input);
            var modString = stringOperation.StringSplit();
            var result = stringOperation.FindLargestVowelSubstring(modString);


            Assert.AreEqual(expected, result);
        }


        // Строка должна включать только английские строчные символы
        [TestCase("abc123", new char[] { '1', '2', '3' })]
        [TestCase("abcdefgh$@AS", new char[] { '$', '@', 'A', 'S' })]
        public void IsTrueString_ReturnsCorrectHashSet(string input, char[] expected)
        {
            var stringOperation = new StringOperation(input);
            var result = stringOperation.isTrueString();

            Assert.AreEqual(expected, result);
        }


        // Строка должна быть отсортирована по алфавиту 
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


        // Строка не должна содержать 1 символ
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
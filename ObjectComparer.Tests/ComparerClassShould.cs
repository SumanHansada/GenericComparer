using Xunit;

namespace ObjectComparer.Tests
{

    public class ComparerClassShould
    {
        [Fact]
        public void ReturnFalseWhenFirstObjectIsNull()
        {
            Student first = null;
            Student second = new Student {Name="John", Id = 100, Marks = new [] {80, 90, 100} };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);

        }
        [Fact]
        public void ReturnFalseWhenSecondObjectIsNull()
        {
            Student first = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            Student second = null; 

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnFalseWhenFirstAndSecondObjectIsNull()
        {
            Student first = null;
            Student second = null;
            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnTrueWhenTwoStudentObjectsAreSame()
        {
            Student first = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            Student second = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };

            var result = Comparer.AreSimilar(first, second);
            Assert.True(result);
        }

        [Fact]
        public void ReturnFalseWhenTwoObjectsAreDifferent()
        {
            object first = new { Name = "Suman", Address = "Baner, Pune" };
            object second = new { Name = "John", Id = 100, Marks = new[] { 80, 90, 110 } };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnFalseWhenTwoStudentObjectHaveDifferentName()
        {
            Student first = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            Student second = new Student { Name = "Suman", Id = 100, Marks = new[] { 80, 90, 100 } };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnFalseWhenTwoStudentObjectHaveDifferentId()
        {
            Student first = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            Student second = new Student { Name = "John", Id = 101, Marks = new[] { 80, 90, 100 } };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }


        [Fact]
        public void ReturnFalseWhenTwoStudentObjectsHaveDifferentMarks()
        {
            Student first = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 110 } };
            Student second = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnFalseWhenTwoStudentObjectsHaveDifferentMarksAndDifferentLengthOfMarksArray()
        {
            Student first = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100, 110 } };
            Student second = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        

        [Fact]
        public void ReturnTrueWhenPrimitiveTypesAreEqual()
        {
            int first = 10;
            int second = 10;

            var result = Comparer.AreSimilar(first, second);
            Assert.True(result);
        }

        [Fact]
        public void ReturnTrueWhenArraysAreEqual()
        {
            int [] first = { 10, 20, 30 };
            int [] second = { 10, 20, 30 };

            var result = Comparer.AreSimilar(first, second);
            Assert.True(result);
        }

        [Fact]
        public void ReturnTrueWhenArraysAreEqualWithoutSameSequence()
        {
            int[] first = { 10, 20, 30 };
            int[] second = { 10, 30, 20 };

            var result = Comparer.AreSimilar(first, second);
            Assert.True(result);
        }

        [Fact]
        public void ReturnTrueWhenStringsAreEqual()
        {
            string first = "Suman";
            string second = "Suman";

            var result = Comparer.AreSimilar(first, second);
            Assert.True(result);
        }


        [Fact]
        public void ReturnFalseWhenPrimitiveTypesAreNotEqual()
        {
            int first = 10;
            int second = 15;

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }
        
        [Fact]
        public void ReturnFlaseWhenArraysAreNotEqual()
        {
            int[] first = { 10, 20, 30 };
            int[] second = { 10, 20, 40 };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnFlaseWhenArraysLengthsAreNotEqual()
        {
            int[] first = { 10, 20, 30 };
            int[] second = { 10, 20, 30, 40 };

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }

        [Fact]
        public void ReturnFalseWhenStringsAreNotEqual()
        {
            string first = "Suman";
            string second = "Kumar";

            var result = Comparer.AreSimilar(first, second);
            Assert.False(result);
        }
    }
}

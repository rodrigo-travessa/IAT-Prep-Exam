using IatDataAccess.Data;
using IatModels;
using Microsoft.EntityFrameworkCore;

namespace IatPrepExam.Tests
{
    public class UnitTest1
    {
        private readonly AppDbContext _context;
        public UnitTest1(AppDbContext context)
        {
            _context = context; 
        }


        [Fact]
        public void Test1()
        {
           
        }

        [Fact]
        public void TestAdding2Numbers() 
        {
            Assert.Equal(2, (1 + 1));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(3, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }



    }
}
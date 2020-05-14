using System.Collections.Generic;
using Xunit;

namespace Demo
{
    public class GenericListDemo
    {
        [Fact]
        public void List_is_all_one_type()
        {
            List<int> myList = new List<int>();

            myList.Add(1);
            myList.Add(2);

            int sum = 0;
            foreach (object value in myList)
            {
                sum += (int)value;
            }

            Assert.Equal(3, sum);

            Assert.Equal(1, myList[0]);
            Assert.Equal(2, myList[1]);
        }

        [Fact]
        public void Can_enumerate_a_list()
        {
            // Behind the scenes, just calls Add()
            List<string> myList = new List<string>
            {
                "Keith",
                "Craig",
                "Ian",
            };

            foreach (string item in myList)
            {
                Assert.NotNull(item);
            }
        }
    }
}

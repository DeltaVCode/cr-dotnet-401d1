using System.Collections;
using Xunit;

namespace Demo
{
    public class ArrayListDemo
    {
        [Fact(Skip = "Expected to fail")]
        public void ArrayList_is_only_objects()
        {
            ArrayList myList = new ArrayList();

            myList.Add(1);
            myList.Add("2");

            int int0 = (int)myList[0];

            int sum = 0;
            foreach (object value in myList)
            {
                sum += (int)value;
            }

            Assert.Equal(3, sum);
        }
    }
}

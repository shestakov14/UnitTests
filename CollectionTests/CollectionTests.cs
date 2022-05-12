using NUnit.Framework;
using Collections;
using System;
using System.Linq;

namespace CollectionTests
{
    public class CollectionTests
    {
       

        [Test]
        public void Test_Empty_Constructor()
        {
            //Arange
            var nums = new Collection<int>();

            //Act

            //Assert
            Assert.AreEqual(0, nums.Count);
            Assert.AreEqual(16,nums.Capacity);
        }

        [Test]
        public void Test_Add_Two_Numbers()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            nums.Add(1);
            nums.Add(2);

            //Assert
            Assert.AreEqual(2, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
           
        }

        [Test]
        public void Test_Insert_Element()
        {
            //Arange
            var nums = new Collection<int>(1,2,3);

            //Act
            nums.InsertAt(1, 99);

            //Assert
            Assert.AreEqual(4, nums.Count);
            Assert.AreEqual(nums[1],99);
        }

        [Test]
        public void Test_Remove_Element()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3);

            //Act
            nums.RemoveAt(2);

            //Assert
            Assert.AreEqual(2, nums.Count);
            
            
        }


        [Test]
        public void Test_Remove_Elements()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3);

            //Act
            nums.RemoveAt(2);
            nums.RemoveAt(1);
            

            //Assert
            Assert.AreEqual(1, nums.Count);

        }

        [Test]
        public void Test_Exchange_Elements()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3, 4);

            //Act
            nums.Exchange(0, 3);

            //Assert
            Assert.AreEqual(nums[0],4);
            Assert.AreEqual(nums[3],1);
        }

        [Test]
        public void Test_Exchange_InvalidIndexes()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3, 4);

            //Act
            

            //Assert
            Assert.That(()=>nums.Exchange(0,4),Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => nums.Exchange(-1, 3), Throws.TypeOf<ArgumentOutOfRangeException>());

        }


        [Test]
        public void Test_Clear_Collection()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3, 4);

            //Act
            nums.Clear();

            //Assert
            Assert.AreEqual(nums.Count,0);
            Assert.AreEqual(nums.ToString(),"[]");
        }

        [Test]
        public void Test_ToString_Empty()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            


            //Assert
            Assert.AreEqual(nums.ToString(),"[]");
        }

        [Test]
        public void Test_ToString()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3, 4);

            //Act
            


            //Assert
            Assert.AreEqual(nums.ToString(), "[1, 2, 3, 4]");
        }

        [Test]
        public void Test_AddRange()
        {
            //Arange
            var nums = new Collection<int>(1, 2, 3);
            var AddNums = new int[] { 4, 5, 6 };

            //Act
            nums.AddRange(AddNums);

            //Assert
            Assert.AreEqual(nums[3], 4);
            Assert.AreEqual(nums[4], 5);
            Assert.AreEqual(nums[5], 6);
            Assert.AreEqual(nums.Count,6);

        }


        [Test]
        public void Test_EnsureRange()
        {
            //Arange
            int[] Range = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var nums = new Collection<int>(Range);
            int InitialCapacity = 16;

            //Act
            nums.AddRange(Enumerable.Range(1000, 2000).ToArray());
           
            //Assert
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(InitialCapacity));

        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            int insertNumber = 6;

            var collection = new Collection<int>(numbers);
            

            Assert.That(() => collection.InsertAt(-1, insertNumber), Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => collection.InsertAt(17, insertNumber), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
using System;
using NUnit.Framework;

namespace SparseVector.Tests;

public class Tests
{
    [Test]
    public void VectorCreatedWithLength()
    {
        IVector myVector = new Vector(10);
        Assert.AreEqual(myVector.Length, 10);
    }

    [Test]
    public void VectorCreatedUsingArray()
    {
        IVector myVector = new Vector(new []{5, 3, 0, 1, 0},10);
    }

    [Test]
    public void PositionChangesAndReturns()
    {
        IVector myVector = new Vector(new []{5, 3, 0, 1, 0}, 10);
        Assert.AreEqual(myVector.GetPosition(1), 3);
        myVector.SetPosition(1, 2);
        Assert.AreEqual(myVector.GetPosition(1), 2);
    }

    [Test]
    public void NullVectorIsNullAndNotNullVectorIsNotNull()
    {
        IVector myVector = new Vector(10);
        Assert.IsTrue(myVector.IsNull);
        myVector.SetPosition(2, 5);
        Assert.IsTrue(!myVector.IsNull);
    }

    [Test]
    public void ToArrayWorks()
    {
        IVector vector = new Vector(7);
        vector.SetPosition(2, 5);
        vector.SetPosition(5, -345);
        var convertedVector = vector.ToArray();
        Assert.AreEqual(convertedVector.Length, vector.Length);
        for (int i = 0; i < convertedVector.Length; ++i)
        {
            if (i == 2)
            {
                Assert.AreEqual(convertedVector[i], 5);
            }
            else if (i == 5)
            {
                Assert.AreEqual(convertedVector[i], -345);
            }
            else
            {
                Assert.AreEqual(convertedVector[i], 0);
            }
        }
    }

    [Test]
    public void DotProductWorks()
    {
        IVector vector1 = new Vector(new []{1, 2},2);
        IVector vector2 = new Vector(new []{3, 4},2);
        Assert.AreEqual(vector1.DotProduct(vector2), 11);
    }

    [Test]
    public void ThrowsException()
    {
        Assert.Throws<IndexOutOfRangeException>(() => new Vector(new[] {1, 2, 3}, 2));
    }
}
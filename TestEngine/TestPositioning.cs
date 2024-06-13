using IdleEngine.Model;

namespace TestEngine;

public class TestPositioning
{
    [Test]
    [TestCase(+0, +0)]
    [TestCase(-1, +1)]
    [TestCase(+0, -1)]
    [TestCase(+0, +123)]
    [TestCase(-6123, +12312314)]
    [TestCase(+123, -123)]
    public void TestEquality(int q, int r)
    {
        var a = new Position(q, r);
        var b = new Position(q, r);
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.EqualTo(b));
            Assert.That(a.CalculateDistance(b), Is.EqualTo(0));
        });
    }

    [Test]
    [TestCase(+0, +0, +1, +0)]
    [TestCase(+0, +0, +1, -1)]
    [TestCase(+0, +0, +0, -1)]
    [TestCase(+0, +0, +0, +1)]
    [TestCase(+0, +0, -1, +0)]
    [TestCase(+0, +0, -1, +1)]
    public void TestNeighbours(int q1, int r1, int q2, int r2)
    {
        var a = new Position(q1, r1);
        var b = new Position(q2, r2);

        Assert.That(a.CalculateDistance(b), Is.EqualTo(1));
    }

    [Test]
    [TestCase(+0, +0, +1, +0, +1)]
    [TestCase(+0, +0, +1, -1, +1)]
    [TestCase(+0, +0, +0, -1, +1)]
    [TestCase(+0, +0, +0, +1, +1)]
    [TestCase(+0, +0, -1, +0, +1)]
    [TestCase(+0, +0, -1, +1, +1)]
    [TestCase(+2, -2, +1, +1, +3)]
    [TestCase(+3, -3, +1, +1, +4)]
    [TestCase(-3, +0, +1, +2, +6)]
    public void TestRange(int q1, int r1, int q2, int r2, int range)
    {
        var a = new Position(q1, r1);
        var b = new Position(q2, r2);

        Assert.That(a.CalculateDistance(b), Is.EqualTo(range));
    }
}
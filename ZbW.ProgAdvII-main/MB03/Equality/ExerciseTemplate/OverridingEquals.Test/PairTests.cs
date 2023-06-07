using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace OverridingEquals.Test {
    //[TestClass]
    //public class PairTests {
    //    [TestMethod]
    //    public void TestOrderedPairGetters() {
    //        IPair a = new OrderedPair(1, 2);

    //        Assert.IsTrue(a.First.Equals(1));
    //        Assert.IsTrue(a.Second.Equals(2));
    //    }

    //    [TestMethod]
    //    public void TestUnorderedPairGetters() {
    //        IPair a = new UnorderedPair(1, 2);
    //        Assert.IsTrue(a.First.Equals(1));
    //        Assert.IsTrue(a.Second.Equals(2));
    //    }

    //    [TestMethod]
    //    public void TestOrderedPairEquals() {
    //        IPair a = new OrderedPair(1, 2);
    //        Assert.IsTrue(a.Equals(a));
    //        Assert.IsTrue(!a.Equals(null));
    //        IPair b = new OrderedPair(1, 2);
    //        Assert.IsTrue(a.Equals(b));
    //        Assert.IsTrue(b.Equals(a));
    //        Assert.IsTrue(a.GetHashCode() == b.GetHashCode());
    //    }

    //    [TestMethod]
    //    public void TestUnorderedPairEquals() {
    //        IPair a = new UnorderedPair(1, 2);
    //        Assert.IsTrue(a.Equals(a));
    //        Assert.IsTrue(!a.Equals(null));
    //        IPair b = new UnorderedPair(1, 2);
    //        Assert.IsTrue(a.Equals(b));
    //        Assert.IsTrue(b.Equals(a));
    //        Assert.IsTrue(a.GetHashCode() == b.GetHashCode());
    //        IPair c = new UnorderedPair(2, 1);
    //        Assert.IsTrue(a.Equals(c));
    //        Assert.IsTrue(c.Equals(a));
    //        Assert.IsTrue(a.GetHashCode() == c.GetHashCode());
    //    }

    //    [TestMethod]
    //    public void TestInterPairEquals() {
    //        IPair a = new OrderedPair(1, 2);
    //        IPair b = new UnorderedPair(1, 2);
    //        Assert.IsTrue(!a.Equals(b));
    //        Assert.IsTrue(!b.Equals(a));
    //    }
    //}
}
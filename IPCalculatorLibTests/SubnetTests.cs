using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPCalculatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculatorLib.Tests
{
    [TestClass()]
    public class SubnetTests
    {
        [TestMethod()]
        public void getSubnetCreatedTestShoudReturnEightWhenFiveSubnetNeed()
        {
            var scenario = this.scenarioFiveSubnet();
            Subnet subnet = new Subnet(scenario.Item1, scenario.Item2);
            Assert.AreEqual(8, subnet.getSubnetCreated());
        }

        [TestMethod]
        public void isValidShouldShouldReturnFalseWhenPrefixIsNotAValidNumber()
        {
            var scenario = this.scenarioFiveSubnet();
            Subnet subnet = new Subnet(scenario.Item1, "192.168.72.0/Z");
            Assert.IsFalse(subnet.isValid());
        }

        [TestMethod]
        public void isValidShouldShouldReturnFalseWhenSubnetNeededGreaterThanAvailable()
        {
            var scenario = this.scenarioFiveSubnet();
            Subnet subnet = new Subnet(scenario.Item1, "192.168.72.0/30");
            Assert.IsFalse(subnet.isValid());
        }

        [TestMethod]
        public void isValidShouldShouldReturnTrueWhenSubnetNeededLowerThanAvailable()
        {
            var scenario = this.scenarioFiveSubnet();
            Subnet subnet = new Subnet(scenario.Item1, scenario.Item2);
            Assert.IsTrue(subnet.isValid());
        }

        [TestMethod]
        public void getNetworksShouldReturnValidListOfNetworks()
        {
            var scenario = this.scenarioFiveSubnet();
            Subnet subnet = new Subnet(scenario.Item1, scenario.Item2);
            Assert.AreEqual("192.168.72.0", subnet.getNetworks()[0].getNetwork());
            Assert.AreEqual("192.168.72.64", subnet.getNetworks()[1].getNetwork());
            Assert.AreEqual("192.168.72.96", subnet.getNetworks()[2].getNetwork());
            Assert.AreEqual("192.168.72.128", subnet.getNetworks()[3].getNetwork());
            Assert.AreEqual("192.168.72.144", subnet.getNetworks()[4].getNetwork());
        }

        private Tuple<List<int>,string> scenarioFiveSubnet()
        {
            List<int> subnets = new List<int>();
            subnets.Add(2);
            subnets.Add(7);
            subnets.Add(15);
            subnets.Add(29);
            subnets.Add(58);
            return Tuple.Create(subnets, "192.168.72.0/24");
        }
    }
}
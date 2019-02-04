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
    public class NetworkTests
    {
        [TestMethod()]
        public void getAllocatedSizeTestShouldReturnZeroWhenSizeNeededIsLessThanTwo()
        {
            Network network = new Network(1, "192.168.10.0/24");
            Assert.AreEqual(0, network.getAllocatedSize());
        }

        /*
         * Size 2 case
         */
        [TestMethod()]
        public void getAllocatedSizeTestShouldReturnFourWhenSizeNeededAreTwo()
        {
            Network network = new Network(2, "192.168.10.0/24");
            Assert.AreEqual(4, network.getAllocatedSize());
        }

        [TestMethod()]
        public void getPrefixTestShouldReturnThirtyWhenSizeNeededAreTwo()
        {
            Network network = new Network(2, "192.168.10.0/24");
            Assert.AreEqual(30, network.getPrefix());
        }

        [TestMethod()]
        public void getNetworkMultipleTestShouldReturnFourWhenSizeNeededAreTwo()
        {
            Network network = new Network(2, "192.168.10.0/24");
            Assert.AreEqual(4, network.getNetworkMultiple());
        }

        [TestMethod()]
        public void getMaskTestShouldReturnTwoFiveTwoWhenSizeNeededAreTwo()
        {
            Network network = new Network(2, "192.168.10.0/24");
            Assert.AreEqual(252, network.getMask());
        }

        [TestMethod()]
        public void getSubnetMaskTestShouldReturnSubnetMaskForPrefixThirtyWhenSizeNeededAreTwo()
        {
            Network network = new Network(2, "192.168.10.0/24");
            Assert.AreEqual("255.255.255.252", network.getSubnetMask());
        }

        [TestMethod()]
        public void isValidMajorNetworkShouldReturnFalseWhenDoNotHaveEnoughOctets()
        {
            Network network = new Network(2, "192.168.0/24");
            Assert.IsFalse(network.isValidMajorNetwork());
        }

        [TestMethod()]
        public void isValidMajorNetworkShouldReturnFalseWhenItDoNoHavePrefix()
        {
            Network network = new Network(2, "192.168.0.0");
            Assert.IsFalse(network.isValidMajorNetwork());
        }

        [TestMethod()]
        public void isValidMajorNetworkShouldReturnFalseWhenInvalidNumbersInformed()
        {
            Network network = new Network(2, "192.168.256.0/24");
            Assert.IsFalse(network.isValidMajorNetwork());
        }

        [TestMethod()]
        public void isValidMajorNetworkShouldReturnFalseWhenAlphabetInformed()
        {
            Network network = new Network(2, "A.B.C.D/24");
            Assert.IsFalse(network.isValidMajorNetwork());
        }

        [TestMethod()]
        public void isValidMajorNetworkShouldReturnTrueWhenValidDataInformed()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.IsTrue(network.isValidMajorNetwork());
        }

        [TestMethod()]
        public void getNetworkShouldReturnEmptyWhenInvalidMajorNetworkInformed()
        {
            Network network = new Network(2, "192.168.1.0");
            Assert.AreEqual("", network.getNetwork());
        }

        [TestMethod()]
        public void getNetworkShouldReturnMajorNetworkFirstOctetPlusZeros()
        {
            Network network = new Network(2, "192.168.1.0/8");
            Assert.AreEqual("192.0.0.0", network.getNetwork());
        }

        [TestMethod()]
        public void getNetworkShouldReturnMajorNetworkTheTwoFirstOctetPlusZeros()
        {
            Network network = new Network(2, "192.168.1.0/16");
            Assert.AreEqual("192.168.0.0", network.getNetwork());
        }

        [TestMethod()]
        public void getNetworkShouldReturnMajorNetworkTheThreeFirstOctetPlusZeros()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.AreEqual("192.168.1.0", network.getNetwork());
        }

        [TestMethod]
        public void getNextNetworkShouldReturnCorrectNetworkForTwo()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.AreEqual("192.168.1.4", network.getNextNetwork());
        }

        [TestMethod]
        public void getBroadcastShouldReturnCorrectNetworkForTwo()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.AreEqual("192.168.1.3", network.getBroadcast());
        }

        [TestMethod]
        public void getFirstIPShouldReturnCorrectFirstUsableIPForTwo()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.AreEqual("192.168.1.1", network.getFirstIP());
        }

        [TestMethod]
        public void getLastIPShouldReturnCorrectLastUsableIPForTwo()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.AreEqual("192.168.1.2", network.getLastIP());
        }

        [TestMethod]
        public void getMajorNetworPrefixShouldReturnTwentyFour()
        {
            Network network = new Network(2, "192.168.1.0/24");
            Assert.AreEqual(24, network.getMajorNetworkPrefix());
        }

        /*
         * Size 1000 case
         */
        [TestMethod()]
        public void getAllocatedSizeTestShouldReturnFourWhenSizeNeededAreOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual(1024, network.getAllocatedSize());
        }

        [TestMethod()]
        public void getPrefixTestShouldReturnThirtyWhenSizeNeededAreOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual(22, network.getPrefix());
        }

        [TestMethod()]
        public void getNetworkMultipleTestShouldReturnFourWhenSizeNeededAreOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual(4, network.getNetworkMultiple());
        }

        [TestMethod()]
        public void getMaskTestShouldReturnTwoFiveTwoWhenSizeNeededAreOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual(252, network.getMask());
        }

        [TestMethod()]
        public void getSubnetMaskTestShouldReturnSubnetMaskForTwentyTwoPrefixWhenSizeNeededAreOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual("255.255.252.0", network.getSubnetMask());
        }

        [TestMethod]
        public void getNextNetworkShouldReturnCorrectNetworkForOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual("192.168.8.0", network.getNextNetwork());
        }

        [TestMethod]
        public void getBroadcastShouldReturnCorrectNetworkForOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual("192.168.7.255", network.getBroadcast());
        }

        [TestMethod]
        public void getFirstIPShouldReturnCorrectFirstUsableIPForOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual("192.168.4.1", network.getFirstIP());
        }

        [TestMethod]
        public void getLastIPShouldReturnCorrectLastUsableIPForOneThousand()
        {
            Network network = new Network(1000, "192.168.4.0/22");
            Assert.AreEqual("192.168.7.254", network.getLastIP());
        }

        [TestMethod]
        public void getMajorNetworPrefixShouldReturnTwentyTwo()
        {
            Network network = new Network(1000, "192.168.1.0/22");
            Assert.AreEqual(22, network.getMajorNetworkPrefix());
        }

        /*
         * Size 5000 case
         */
        [TestMethod()]
        public void getAllocatedSizeTestShouldReturnEightThousandWhenSizeNeededAreFiveThousand()
        {
            Network network = new Network(5000, "192.168.0.0/16");
            Assert.AreEqual(8192, network.getAllocatedSize());
        }

        [TestMethod()]
        public void getPrefixTestShouldReturnNineteenWhenSizeNeededAreFiveThousand()
        {
            Network network = new Network(5000, "192.168.0.0/16");
            Assert.AreEqual(19, network.getPrefix());
        }

        [TestMethod()]
        public void getNetworkMultipleTestShouldReturnThirtyTwoWhenSizeNeededAreFiveThousand()
        {
            Network network = new Network(5000, "192.168.0.0/16");
            Assert.AreEqual(32, network.getNetworkMultiple());
        }

        [TestMethod()]
        public void getMaskTestShouldReturnTwoTwoFourTwoWhenSizeNeededAreFiveThousand()
        {
            Network network = new Network(5000, "192.168.0.0/16");
            Assert.AreEqual(224, network.getMask());
        }

        [TestMethod()]
        public void getSubnetMaskTestShouldReturnSubnetMaskForPrefixNineteenWhenSizeNeededAreFiveThousand()
        {
            Network network = new Network(5000, "192.168.0.0/16");
            Assert.AreEqual("255.255.224.0", network.getSubnetMask());
        }

        [TestMethod]
        public void getNextNetworkShouldReturnCorrectNetworkForFiveThousand()
        {
            Network network = new Network(5000, "192.168.1.0/16");
            Assert.AreEqual("192.168.32.0", network.getNextNetwork());
        }

        [TestMethod]
        public void getBroadcastShouldReturnCorrectNetworkForFiveThousand()
        {
            Network network = new Network(5000, "192.168.1.0/16");
            Assert.AreEqual("192.168.31.255", network.getBroadcast());
        }

        [TestMethod]
        public void getLastIPShouldReturnCorrectLastIPForFiveThousand()
        {
            Network network = new Network(5000, "192.168.4.0/16");
            Assert.AreEqual("192.168.0.1", network.getFirstIP());
        }

        [TestMethod]
        public void getLasIPShouldReturnCorrectLastUsableIPForFiveThousand()
        {
            Network network = new Network(5000, "192.168.4.0/16");
            Assert.AreEqual("192.168.31.254", network.getLastIP());
        }

        [TestMethod]
        public void getMajorNetworPrefixShouldReturnSixteen()
        {
            Network network = new Network(5000, "192.168.4.0/16");
            Assert.AreEqual(16, network.getMajorNetworkPrefix());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCalculatorLib
{
    public class Subnet
    {
        private int needed;
        private List<int> hostsEachSubnet;
        private string majorNetwork;
        private List<Network> networks = new List<Network>();
        private int subnetCreated = 0;
        private int power = 0;
        private int majorNetworkPrefix = 0;

        public Subnet(List<int> hostsEachSubnet, string majorNetwork)
        {
            this.needed = hostsEachSubnet.Count;
            this.hostsEachSubnet = hostsEachSubnet;
            this.majorNetwork = majorNetwork;
            this.doMath();
        }

        public int getSubnetCreated()
        {
            return this.subnetCreated;
        }

        public bool isValid()
        {
            if (!this.isValidMajorNetwork())
                return false;

            return this.power <= (30 - this.majorNetworkPrefix);
        }

        public List<Network> getNetworks()
        {
            return this.networks;
        }

        public bool isValidMajorNetwork()
        {
            string[] ip = this.majorNetwork.Split('/');
            int[] ipOctets;

            if (!(ip.Length == 2))
                return false;

            if (!int.TryParse(ip[1], out this.majorNetworkPrefix))
                return false;

            try
            {
                ipOctets = Array.ConvertAll<string, int>(
                ip[0].Split('.'),
                int.Parse
            );
            }
            catch (Exception)
            {
                return false;
            }
            this.majorNetworkPrefix = System.Convert.ToInt32(ip[1]);

            if (!(ipOctets.Length == 4))
                return false;

            foreach (int octet in ipOctets)
            {
                if (!(octet >= 0 && octet <= 255))
                    return false;
            }
            return true;
        }

        private void doMath()
        {
            if (!this.isValid())
                return;

            string majorNetwork = this.majorNetwork;
            this.hostsEachSubnet = this.hostsEachSubnet.OrderByDescending(x => x).ToList();

            foreach (int hosts in this.hostsEachSubnet)
            {
                Network network = new Network(hosts, majorNetwork);
                this.networks.Add(network);
                majorNetwork = network.getNextNetwork() + "/" + network.getPrefix().ToString();
            }

            while(true)
            {
                this.subnetCreated = Convert.ToInt32(Math.Pow(2, this.power));
                if (this.needed <= this.subnetCreated)
                    break;
                this.power++;
            }
        }
    }
}

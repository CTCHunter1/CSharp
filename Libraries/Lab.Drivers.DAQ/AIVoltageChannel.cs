using System;
using System.Collections.Generic;
using System.Text;


using NationalInstruments.DAQmx;

namespace Lab.Drivers.DAQ
{
    public class AIVoltageChannel
    {
        private string physicalChannelName;
        private string nameToAsignChannel;
        private AITerminalConfiguration aiTerminalConfiguration;
        private double minimumVoltage;
        private double maximumVoltage;

        public AIVoltageChannel(string physicalChannelName,
                                string nameToAssignChannel,
                                AITerminalConfiguration aiTerminalConfiguration,
                                double minimumVoltage,
                                double maximumVoltage)
        {
            this.physicalChannelName = physicalChannelName;
            this.nameToAsignChannel = nameToAssignChannel;
            this.aiTerminalConfiguration = aiTerminalConfiguration;
            this.minimumVoltage = minimumVoltage;
            this.maximumVoltage = maximumVoltage;
        }

        public string PhysicalChannelName
        {
            get
            {
                return (physicalChannelName);
            }
        }

        public string NameToAssignChannel
        {
            get
            {
                return (nameToAsignChannel);
            }
        }

        public AITerminalConfiguration AITerminalConfiguration
        {
            get
            {
                return (aiTerminalConfiguration);
            }
        }

        public double MinimumVoltage
        {
            get 
            {
                return (minimumVoltage);
            }                
        }

        public double MaximumVoltage
        {
            get
            {
                return (maximumVoltage);
            }
        }

        public override string ToString()
        {
            return(physicalChannelName + " : {" + minimumVoltage.ToString() + "  , " +  maximumVoltage.ToString() + "}");
        }

        public override bool Equals(object obj)
        {
            try
            {
                // cast it
                AIVoltageChannel aiVoltageObj = (AIVoltageChannel)obj;

                if (aiVoltageObj.PhysicalChannelName == physicalChannelName)
                    return (true);

                return (false);
            }
            catch
            {
                return (false);
            }
        }
    }
    
}

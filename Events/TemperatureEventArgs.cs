using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Events
{

    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TemperatureReachedEmergencyLevel;
        event EventHandler<TemperatureEventArgs> TemperatureReachedWarningLevel;
        event EventHandler<TemperatureEventArgs> TemperatureFallsBelowWarningLevel;

        void RunHeatSensor();
    }

    public class HeatSensor : IHeatSensor
    {
        double _warningLevel = 0;
        double _emergencyLevel = 0;

        bool _hasReachedWarningTemperature = false;

        protected EventHandlerList _listEventDeletgates = new EventHandlerList();

        static readonly object _temperatureReachedWarningLevel = new();
        static readonly object _temperatureReachedEmergencyLevel = new();
        static readonly object _temperaatureFallsBelowWarnkngLevel = new();

        private double[] _temperatrueDatea = null;

        public interface ICoolingMechanisim
        {
            void On();
            void Off();
        }

        public interface IDevice
        {
            double WarningTemperature { get;}
            double EmergencyTemperature { get;}

            void RunDevice();
            void HandleEmergency();
        }

        public class Device : IDevice
        {
            const double Warning_Level = 27;
            const double Emergency_Level = 75;

            public double WarningTemperature => Warning_Level;

            public double EmergencyTemperature =>Emergency_Level;

            public void HandleEmergency()
            {
                Console.WriteLine();
                Console.WriteLine($"Sending out notificaiton to emergency services!...");
                ShutdownDevice();
                Console.WriteLine();
            }

            private void ShutdownDevice()
            {
                Console.WriteLine("Device is shutdown!");
            }

            public void RunDevice()
            {
                Console.WriteLine("Device is running...");

                ICoolingMechanisim coolingMechanism = new CoolingMechanism();
                IHeatSensor heatSensor = new HeatSensor(Warning_Level, Emergency_Level);
                IThermostat thermostat = new Thermostat(coolingMechanism, this, heatSensor);

                thermostat.RunThermostat();

            }
        }

        public interface IThermostat
        {
            void RunThermostat();
        }

        public class Thermostat : IThermostat
        {
            private ICoolingMechanisim _coolingMechanisim = null;
            private IDevice _device = null;
            private IHeatSensor _heatSensor = null;

            private const double WarningLevel = 27;
            private const double EmergencyLevel = 75;

            public Thermostat(ICoolingMechanisim coolingMechanisim, IDevice device, IHeatSensor heatSensor)
            {
                _coolingMechanisim = coolingMechanisim;
                _device = device;
                _heatSensor = heatSensor;
            }

            private void WireUpEventsToEventHander()
            {
                _heatSensor.TemperatureFallsBelowWarningLevel += _heatSensor_TemperatureFallsBelowWarningLevel;
                _heatSensor.TemperatureReachedEmergencyLevel += _heatSensor_TemperatureReachedEmergencyLevel;
                _heatSensor.TemperatureReachedWarningLevel += _heatSensor_TemperatureReachedWarningLevel;
            }

            private void _heatSensor_TemperatureReachedWarningLevel(object? sender, TemperatureEventArgs e)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine($"Warning Alert!! (Warning level is between {_device.WarningTemperature} and {_device.EmergencyTemperature}!");
                _coolingMechanisim.On();
                Console.ResetColor();
            }

            private void _heatSensor_TemperatureReachedEmergencyLevel(object? sender, TemperatureEventArgs e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"Emergency Alert!! (Temperature reached {_device.EmergencyTemperature}!");
                _device.HandleEmergency();
            }

            private void _heatSensor_TemperatureFallsBelowWarningLevel(object? sender, TemperatureEventArgs e)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine($"Information Alert!! (Temperature falls belwo {_device.WarningTemperature}!");
                _coolingMechanisim.Off();
                Console.ResetColor();
            }

            public void RunThermostat()
            {
                Console.WriteLine("Thermostat is running...");
                WireUpEventsToEventHander();
                _heatSensor.RunHeatSensor();
            }
        }


        public class CoolingMechanism : ICoolingMechanisim
        {
            public void Off()
            {
                Console.WriteLine();
                Console.WriteLine("Switching cooling mechanism off...");
                Console.WriteLine();
            }

            public void On()
            {
                Console.WriteLine();
                Console.WriteLine("Switching cooling mechanism on...");
                Console.WriteLine();
            }
        }

        private void MonitorTemperature()
        {
            foreach (double temperature in _temperatrueDatea)
            {
                Console.ResetColor();
                Console.WriteLine($"DateTime: {DateTime.Now}, Temperature:{temperature}");

                if(temperature >= _emergencyLevel)
                {
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperature,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureReachedEmergencyLevel(e);
                }
                else if(temperature >= _warningLevel)
                {
                    _hasReachedWarningTemperature = true;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperature,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureReachedWarningLevel(e);
                }
                else if (temperature < _warningLevel && _hasReachedWarningTemperature)
                {
                    _hasReachedWarningTemperature = false;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperature,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureFallsBelowWarningLevel(e);
                }

                Thread.Sleep(1000);

            }
        }
        private void SeedData()
        {
            _temperatrueDatea = new double[]
            {
                16, 17,27,24,25,5,30,45,75,23,4,38,40
            };
        }

        protected void OnTemperatureReachedWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDeletgates[_temperatureReachedWarningLevel];

            if(handler is not null)
            {
                handler(this, e);
            }
        }

        protected void OnTemperatureReachedEmergencyLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDeletgates[_temperatureReachedEmergencyLevel];

            if (handler is not null)
            {
                handler(this, e);
            }
        }

        protected void OnTemperatureFallsBelowWarningLevel(TemperatureEventArgs e)
        {
            EventHandler<TemperatureEventArgs> handler = (EventHandler<TemperatureEventArgs>)_listEventDeletgates[_temperaatureFallsBelowWarnkngLevel];

            if (handler is not null)
            {
                handler(this, e);
            }
        }

        public HeatSensor(double warningLevel, double emergencyLevel)
        {
            _warningLevel = warningLevel;
            _emergencyLevel = emergencyLevel;

            SeedData();
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachedEmergencyLevel
        {
            add
            {
                _listEventDeletgates.AddHandler(_temperatureReachedEmergencyLevel, value);
            }

            remove
            {
                _listEventDeletgates.AddHandler(_temperatureReachedEmergencyLevel, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachedWarningLevel
        {
            add
            {
                _listEventDeletgates.AddHandler(_temperatureReachedWarningLevel, value);
            }

            remove
            {
                _listEventDeletgates.RemoveHandler(_temperatureReachedWarningLevel, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallsBelowWarningLevel
        {
            add
            {
                _listEventDeletgates.AddHandler(_temperaatureFallsBelowWarnkngLevel, value);
            }

            remove
            {
                _listEventDeletgates.AddHandler(_temperaatureFallsBelowWarnkngLevel, value);
            }
        }

        public void RunHeatSensor()
        {
            Console.WriteLine("Heaat sensor is running...");
            MonitorTemperature();

        }
    }


    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}

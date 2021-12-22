namespace Bridge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var remoteControl = new AdvancedRemoteControl(new SonyTV());
            remoteControl.TurnOn();
        }
    }

    public class RemoteControl
    {
        protected Device _device;

        public RemoteControl(Device device)
        {
            _device = device;
        }

        public void TurnOn()
        {
            _device.TurnOn();
        }

        public void TurnOff()
        {
            _device.TurnOff();
        }
    }

    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(Device device) : base(device)
        { }
        public void SetChannel(int number)
        {
            _device.SetChannel(number);
        }
    }

    // public class SonyRemoteControl : RemoteControl
    // {
    //     public override void TurnOff()
    //     {
    //         Console.WriteLine("Sony: Turn on");
    //     }

    //     public override void TurnOn()
    //     {
    //         Console.WriteLine("Sony: Turn off");
    //     }

    // }

    // public class SonyAdvancedRemoteControl : AdvancedRemoteControl
    // {
    //     public override void SetChannel(int number)
    //     {
    //         Console.WriteLine("Sony: Set Channel");
    //     }

    //     public override void TurnOff()
    //     {
    //         Console.WriteLine("Sony: Turn on");
    //     }

    //     public override void TurnOn()
    //     {
    //         Console.WriteLine("Sony: Turn off");
    //     }
    // }

    public interface Device
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(int number);
    }

    public class SonyTV : Device
    {
        public void SetChannel(int number)
        {
            Console.WriteLine($"Set channel {number}");
        }

        public void TurnOn()
        {
            Console.WriteLine("Sony: turn on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Sony: turn off");
        }
    }

}
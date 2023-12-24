using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress localIp = IPAddress.Loopback;

Console.Write("Input name: ");
string name = Console.ReadLine();
Console.Write("Input receive port: ");
int portLocal = Int32.Parse(Console.ReadLine());
Console.Write("Input sending port: ");
int portRemote = Int32.Parse(Console.ReadLine());

Task.Run(ReceiveMessageAsync);
await SendMessageAsync();


async Task SendMessageAsync()
{
    using UdpClient client = new UdpClient();
    Console.WriteLine("Input and send messages");

    while(true)
    {
        var message = Console.ReadLine();
        if (message == "exit") break;

        message = $"{name}: {message}";
        byte[] buffer = Encoding.UTF8.GetBytes(message);

        var remoteClient = new IPEndPoint(localIp, portRemote);
        await client.SendAsync(buffer, remoteClient);
    }
}

async Task ReceiveMessageAsync()
{
    using UdpClient client = new UdpClient(portLocal);
    while(true)
    {
        var messageData = await client.ReceiveAsync();
        var message = Encoding.UTF8.GetString(messageData.Buffer);

        Console.WriteLine(message);
    }
}



void UdpExample()
{
    // Load messages
    //using Socket udpSocket = new Socket(AddressFamily.InterNetwork, 
    //                                    SocketType.Dgram, 
    //                                    ProtocolType.Udp);

    //var udpClient = new IPEndPoint(IPAddress.Loopback, 5000);
    //udpSocket.Bind(udpClient);

    //Console.WriteLine("Udp binding...");

    //byte[] buffer = new byte[1024];

    //EndPoint remoteClient = new IPEndPoint(IPAddress.Any, 0);

    //var messageData = await udpSocket.ReceiveFromAsync(buffer, remoteClient);
    //var message = Encoding.UTF8.GetString(buffer, 0, messageData.ReceivedBytes);

    //Console.WriteLine($"Receive data {messageData.ReceivedBytes} bites");
    //Console.WriteLine($"From client {messageData.RemoteEndPoint} bites");
    //Console.WriteLine(message);

    //using UdpClient udpClient = new UdpClient(5000);
    //Console.WriteLine("Udp binding...");

    //var messageData = await udpClient.ReceiveAsync();
    //var message = Encoding.UTF8.GetString(messageData.Buffer);

    //Console.WriteLine($"Receive data {messageData.Buffer.Length} bites");
    //Console.WriteLine($"From client {messageData.RemoteEndPoint} bites");
    //Console.WriteLine(message);





    // Send Message
    //using Socket udpSocket = new Socket(AddressFamily.InterNetwork,
    //                                    SocketType.Dgram, 
    //                                    ProtocolType.Udp);

    //string message = "Hello world";
    //byte[] buffer = Encoding.UTF8.GetBytes(message);
    //EndPoint remoteClient = new IPEndPoint(IPAddress.Any, 0);
    //int bytes = await udpSocket.SendToAsync(buffer, remoteClient);

    //using UdpClient udpClient = new();
    //udpClient.Connect(IPAddress.Loopback, 5000);

    //string message = "Hello world";
    //byte[] buffer = Encoding.UTF8.GetBytes(message);

    ////IPEndPoint remoteClient = new(IPAddress.Any, 0);
    //int bytes = await udpClient.SendAsync(buffer);
}




// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using System.Collections;
using System.Net;
using System.Net.Sockets;

internal class Program
{
    static int requestCounter;
    static ArrayList hostData = new ArrayList();
    static StringCollection hostNames = new StringCollection();

    private static void Main(string[] args)
    {
        Console.WriteLine("Async Callback");


        // Create the delegate that will process the results of the asynchronous request.
        //
        AsyncCallback callBack = new AsyncCallback(ProcessDnsInformation); // AsyncCallBack is a delegate without return type (void) that points to (refereneces) a method, here it is ProcessDnsInformation()
        
        string host;
        
        do
        {
            Console.Write(" Enter the name of a host computer or <enter> to finish: ");
            host = Console.ReadLine();
            if (host?.Length > 0)
            {
                // Increment the request counter in a thread safe manner.
                Interlocked.Increment(ref requestCounter);
                // Start the asynchronous request for DNS information.
                Dns.BeginGetHostEntry(host, callBack, host); // the delegate reference is passed as a paramter here (callback), i.e., whenever it is passed, the method is called
            }
        } while (host?.Length > 0);

        // The user has entered all of the host names for lookup.
        // Now wait until the threads complete.
        //
        while (requestCounter > 0)
        {
            UpdateUserInterface();
        }
        // Display the results.
        for (int i = 0; i < hostNames.Count; i++)
        {
            object data = hostData[i];
            string message = data as string;
            // A SocketException was thrown.
            if (message != null)
            {
                Console.WriteLine("Request for {0} returned message: {1}",
                    hostNames[i], message);
                continue;
            }
            // Get the results.
            IPHostEntry h = (IPHostEntry)data;
            string[] aliases = h.Aliases;
            IPAddress[] addresses = h.AddressList;
            if (aliases.Length > 0)
            {
                Console.WriteLine("Aliases for {0}", hostNames[i]);
                for (int j = 0; j < aliases.Length; j++)
                {
                    Console.WriteLine("{0}", aliases[j]);
                }
            }
            if (addresses.Length > 0)
            {
                Console.WriteLine("Addresses for {0}", hostNames[i]);
                for (int k = 0; k < addresses.Length; k++)
                {
                    Console.WriteLine("{0}", addresses[k].ToString());
                }
            }
        }
    }

    private static void UpdateUserInterface()
    {
        // Print a message to indicate that the application
        // is still working on the remaining requests.
        Console.WriteLine("{0} requests remaining.", requestCounter);
    }

    // The following method is called when each asynchronous operation completes.
    private static void ProcessDnsInformation(IAsyncResult result)
    {
        string hostName = (string)result.AsyncState;
        hostNames.Add(hostName);
        try
        {
            // Get the results.
            IPHostEntry host = Dns.EndGetHostEntry(result);
            hostData.Add(host);
        }
        // Store the exception message.
        catch (SocketException e)
        {
            hostData.Add(e.Message);
        }
        finally
        {
            // Decrement the request counter in a thread-safe manner.
            Interlocked.Decrement(ref requestCounter);
        }
    }
}
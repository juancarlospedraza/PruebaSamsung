using System;
using S7.Net;

namespace SiemensS7Communication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the IP address and rack/slot configuration of the S7-1200
            string ipAddress = "192.168.0.1"; // Replace with your PLC's IP address
            short rack = 0;
            short slot = 1;

            // Create a new PLC instance
            Plc plc = new Plc(CpuType.S71200, ipAddress, rack, slot);

            try
            {
                // Open a connection to the PLC
                plc.Open();
                
                if (plc.IsConnected)
                {
                    Console.WriteLine("Connected to the PLC.");

                    // Define the DB number, start byte, and the value to write
                    int dbNumber = 1; // Replace with your DB number
                    int startByte = 0; // Start byte in the DB
                    byte valueToWrite = 1; // Value to write

                    // Write the value to the PLC prueba comentarios 
                    plc.Write(DataType.DataBlock, dbNumber, startByte, valueToWrite);

                    Console.WriteLine($"Successfully wrote value {valueToWrite} to DB{dbNumber}.DBB{startByte}.");
                }
                else
                {
                    Console.WriteLine("Failed to connect to the PLC.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Close the connection to the PLC
                if (plc.IsConnected)
                {
                    plc.Close();
                }
            }
        }
    }
}
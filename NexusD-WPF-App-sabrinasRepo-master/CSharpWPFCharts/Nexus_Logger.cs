using System;
using System.IO;                    // Needed to write to file
using System.Threading;             // Threading required to run a custom thread outside of the console thread.
using NexusD3_Csharp_Lib;             // Using the Nexus CSharp DLL
using System.Collections.Concurrent;

namespace CSharpWPFCharts
{
    class Nexus_Logger
    {
        private Thread logging_thread;          // The thread that handles timing for logging
        private Nexus_Interface the_nexus;      // The Nexus-D DLL object
        public static ConcurrentQueue<SensorData> queueSensorData;
        public static int nSamples;
        private int channel;
        private StreamWriter file_writer;       // Datastream to A file, easiest way to write to a file

        // Constructor for the class. Opens the communication channel the the Nexus and the files to save data to
        public Nexus_Logger(string COMPORT, int channel, string filePath)
        {
            // Create a Nexus Interface
            the_nexus = new Nexus_Interface(COMPORT, 3);
            the_nexus.initialize();
            this.channel = channel;

            Nexus_Logger.queueSensorData = new ConcurrentQueue<SensorData>();

            // Create a file and stream objects
            if (File.Exists(filePath))
                file_writer = File.AppendText(filePath);
            else
                file_writer = File.CreateText(filePath);

            file_writer.AutoFlush = true;
        }

        // Public function that starts up the logging threads and starts the flow of data from the Nexus-D
        public void start_sensing()
        {
            // Start up logging thread
            logging_thread = new Thread(logging_loop);
            logging_thread.Start();
            the_nexus.set_422Channel(3);

            // Try to start sensing  
            while (!the_nexus.enable_NexusSensing(true))
            {
                // Failed to start
                Console.WriteLine("Sensing not yet enabled, press key to proceed to try again");
                Console.ReadKey();
            }
        }

        // Public function that shuts down everything in the object. Should be called before program exit
        public void dispose()
        {
            // Check if logging was ever started
            if (logging_thread != null)
            {
                // Stop logging thread
                logging_thread.Abort();
            }

            // Flush file buffers
            file_writer.Flush();

            // Close files
            file_writer.Close();

            // Close Nexus-D Connection
            the_nexus.dispose();
        }        
        
        // Thread function that handles reading in new data and writing it to the file stream object
        private void logging_loop()
        {
            // Do forever until an abort command is sent
            try
            {
                while (true)
                {
                    // Blocking wait for data to be available
                    the_nexus.Sense_Wait();

                    // New data is available
                    sense_data the_data = the_nexus.get_sensed_data(this.channel-1);

                    // Log data corresponding to first sequence number
                    int p1_seqnum = the_data.data_sequence_num >> 8;
                    Nexus_Logger.nSamples = the_data.raw_data.Length / 2;
                    for (int i = 0; i < Nexus_Logger.nSamples; i++)
                    {
                        // Save data point in the following format: data point, sequence number/514, data index in packet
                        Nexus_Logger.queueSensorData.Enqueue(new SensorData(the_data.raw_data[i], p1_seqnum, i));
                        // Writes a line with the following format: data point, sequence number/514, data index in packet
                        file_writer.WriteLine((the_data.raw_data[i].ToString() + "," + p1_seqnum.ToString() + "," + i.ToString()).ToCharArray());
                    }

                    // Log data corresponding to first sequence number
                    int p2_seqnum = the_data.data_sequence_num & 0x00FF;
                    int p2_bound = the_data.raw_data.Length;
                    for (int i = Nexus_Logger.nSamples; i < p2_bound; i++)
                    {
                        // Save data point in the following format: data point, sequence number/514, data index in packet
                        Nexus_Logger.queueSensorData.Enqueue(new SensorData(the_data.raw_data[i], p2_seqnum, (i - Nexus_Logger.nSamples)));
                        // Writes a line with the following format: data point, sequence number/514, data index in packet
                        file_writer.WriteLine((the_data.raw_data[i].ToString() + "," + p2_seqnum.ToString() + "," + (i - Nexus_Logger.nSamples).ToString()).ToCharArray());
                    }
                }
            }
            catch (ThreadAbortException)
            {
                // Handle the abort command and exit
                Console.WriteLine("Aborting Logging Thread...");
            }
        }

        public void setChannel(int channel)
        {
            this.channel = channel;
        }

        public int getChannel()
        {
            return this.channel;
        }

        public void clearQueue()
        {
            Nexus_Logger.queueSensorData = new ConcurrentQueue<SensorData>();
        }
    }
}

using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using ChartDirector;
using System.Numerics;
using System.Linq;
using MathNet.Numerics.IntegralTransforms;

namespace CSharpWPFCharts
{
    public partial class RealTimeSensorData : Window
    {
        Nexus_Logger the_logger;

        // The data arrays that store the visible data. The data arrays are updated in realtime. In
        // this demo, we plot the last 1024 samples.
        //private const int sampleRate = 200;
        private const int sampleSizeSensorData = 1024;

        //variables related to the first chart that shows the sensor data
        private DateTime[] timeStampsChart1;
        private double[] dataBufferChart1;
        // Keep track of 255 sequence cycles
        private int nCycle;
        private int channelIndex;

        //variables for showing band power
        private Boolean ShowBandPower;
        private double[] bandPowerBuffer;

        //variables related to the second chart that shows fft
        private int fftLength;
        private int fftOutLength;
        private Complex[] rawDataArray;
        private double[] fftBuffer;
        private Boolean ShowFFT;
        private double[] hann_window = {0.0000000000, 0.0000377966, 0.0001511806, 0.0003401349, 0.0006046310, 0.0009446287, 0.0013600769, 0.0018509125, 0.0024170615, 0.0030584382, 0.0037749457, 0.0045664756, 0.0054329083, 0.0063741127, 0.0073899466, 0.0084802564, 0.0096448773, 0.0108836332, 0.0121963367, 0.0135827895, 0.0150427819, 0.0165760932, 0.0181824916, 0.0198617342, 0.0216135671, 0.0234377255, 0.0253339336, 0.0273019047, 0.0293413412, 0.0314519350, 0.0336333667, 0.0358853068, 0.0382074146, 0.0405993391, 0.0430607187, 0.0455911813, 0.0481903443, 0.0508578147, 0.0535931893, 0.0563960544, 0.0592659864, 0.0622025514, 0.0652053053, 0.0682737943, 0.0714075543, 0.0746061116, 0.0778689827, 0.0811956742, 0.0845856832, 0.0880384971, 0.0915535940, 0.0951304424, 0.0987685015, 0.1024672213, 0.1062260427, 0.1100443972, 0.1139217078, 0.1178573880, 0.1218508430, 0.1259014690, 0.1300086536, 0.1341717757, 0.1383902061, 0.1426633070, 0.1469904322, 0.1513709277, 0.1558041311, 0.1602893723, 0.1648259730, 0.1694132474, 0.1740505021, 0.1787370358, 0.1834721401, 0.1882550991, 0.1930851896, 0.1979616815, 0.2028838374, 0.2078509132, 0.2128621579, 0.2179168140, 0.2230141172, 0.2281532968, 0.2333335760, 0.2385541714, 0.2438142939, 0.2491131482, 0.2544499331, 0.2598238419, 0.2652340619, 0.2706797754, 0.2761601590, 0.2816743840, 0.2872216169, 0.2928010190, 0.2984117468, 0.3040529519, 0.3097237815, 0.3154233783, 0.3211508806, 0.3269054224, 0.3326861337, 0.3384921406, 0.3443225653, 0.3501765262, 0.3560531384, 0.3619515135, 0.3678707595, 0.3738099817, 0.3797682821, 0.3857447599, 0.3917385115, 0.3977486307, 0.4037742090, 0.4098143353, 0.4158680964, 0.4219345772, 0.4280128603, 0.4341020269, 0.4402011564, 0.4463093267, 0.4524256142, 0.4585490944, 0.4646788413, 0.4708139283, 0.4769534279, 0.4830964118, 0.4892419513, 0.4953891172, 0.5015369803, 0.5076846110, 0.5138310798, 0.5199754577, 0.5261168154, 0.5322542247, 0.5383867576, 0.5445134869, 0.5506334865, 0.5567458309, 0.5628495961, 0.5689438593, 0.5750276992, 0.5811001959, 0.5871604313, 0.5932074893, 0.5992404556, 0.6052584181, 0.6112604670, 0.6172456948, 0.6232131966, 0.6291620704, 0.6350914165, 0.6410003387, 0.6468879436, 0.6527533411, 0.6585956443, 0.6644139700, 0.6702074386, 0.6759751742, 0.6817163047, 0.6874299622, 0.6931152829, 0.6987714071, 0.7043974799, 0.7099926506, 0.7155560732, 0.7210869067, 0.7265843149, 0.7320474667, 0.7374755360, 0.7428677023, 0.7482231504, 0.7535410705, 0.7588206586, 0.7640611166, 0.7692616522, 0.7744214791, 0.7795398173, 0.7846158928, 0.7896489384, 0.7946381929, 0.7995829022, 0.8044823187, 0.8093357016, 0.8141423172, 0.8189014388, 0.8236123468, 0.8282743291, 0.8328866808, 0.8374487046, 0.8419597108, 0.8464190174, 0.8508259501, 0.8551798427, 0.8594800371, 0.8637258829, 0.8679167384, 0.8720519699, 0.8761309523, 0.8801530688, 0.8841177114, 0.8880242806, 0.8918721858, 0.8956608454, 0.8993896864, 0.9030581452, 0.9066656672, 0.9102117068, 0.9136957281, 0.9171172042, 0.9204756179, 0.9237704614, 0.9270012367, 0.9301674552, 0.9332686383, 0.9363043171, 0.9392740327, 0.9421773360, 0.9450137882, 0.9477829604, 0.9504844340, 0.9531178004, 0.9556826617, 0.9581786299, 0.9606053279, 0.9629623886, 0.9652494557, 0.9674661835, 0.9696122368, 0.9716872912, 0.9736910329, 0.9756231590, 0.9774833774, 0.9792714069, 0.9809869771, 0.9826298286, 0.9841997131, 0.9856963932, 0.9871196427, 0.9884692464, 0.9897450002, 0.9909467113, 0.9920741979, 0.9931272897, 0.9941058274, 0.9950096630, 0.9958386599, 0.9965926929, 0.9972716478, 0.9978754221, 0.9984039244, 0.9988570748, 0.9992348049, 0.9995370576, 0.9997637870, 0.9999149590, 0.9999905508, 0.9999905508, 0.9999149590, 0.9997637870, 0.9995370576, 0.9992348049, 0.9988570748, 0.9984039244, 0.9978754221, 0.9972716478, 0.9965926929, 0.9958386599, 0.9950096630, 0.9941058274, 0.9931272897, 0.9920741979, 0.9909467113, 0.9897450002, 0.9884692464, 0.9871196427, 0.9856963932, 0.9841997131, 0.9826298286, 0.9809869771, 0.9792714069, 0.9774833774, 0.9756231590, 0.9736910329, 0.9716872912, 0.9696122368, 0.9674661835, 0.9652494557, 0.9629623886, 0.9606053279, 0.9581786299, 0.9556826617, 0.9531178004, 0.9504844340, 0.9477829604, 0.9450137882, 0.9421773360, 0.9392740327, 0.9363043171, 0.9332686383, 0.9301674552, 0.9270012367, 0.9237704614, 0.9204756179, 0.9171172042, 0.9136957281, 0.9102117068, 0.9066656672, 0.9030581452, 0.8993896864, 0.8956608454, 0.8918721858, 0.8880242806, 0.8841177114, 0.8801530688, 0.8761309523, 0.8720519699, 0.8679167384, 0.8637258829, 0.8594800371, 0.8551798427, 0.8508259501, 0.8464190174, 0.8419597108, 0.8374487046, 0.8328866808, 0.8282743291, 0.8236123468, 0.8189014388, 0.8141423172, 0.8093357016, 0.8044823187, 0.7995829022, 0.7946381929, 0.7896489384, 0.7846158928, 0.7795398173, 0.7744214791, 0.7692616522, 0.7640611166, 0.7588206586, 0.7535410705, 0.7482231504, 0.7428677023, 0.7374755360, 0.7320474667, 0.7265843149, 0.7210869067, 0.7155560732, 0.7099926506, 0.7043974799, 0.6987714071, 0.6931152829, 0.6874299622, 0.6817163047, 0.6759751742, 0.6702074386, 0.6644139700, 0.6585956443, 0.6527533411, 0.6468879436, 0.6410003387, 0.6350914165, 0.6291620704, 0.6232131966, 0.6172456948, 0.6112604670, 0.6052584181, 0.5992404556, 0.5932074893, 0.5871604313, 0.5811001959, 0.5750276992, 0.5689438593, 0.5628495961, 0.5567458309, 0.5506334865, 0.5445134869, 0.5383867576, 0.5322542247, 0.5261168154, 0.5199754577, 0.5138310798, 0.5076846110, 0.5015369803, 0.4953891172, 0.4892419513, 0.4830964118, 0.4769534279, 0.4708139283, 0.4646788413, 0.4585490944, 0.4524256142, 0.4463093267, 0.4402011564, 0.4341020269, 0.4280128603, 0.4219345772, 0.4158680964, 0.4098143353, 0.4037742090, 0.3977486307, 0.3917385115, 0.3857447599, 0.3797682821, 0.3738099817, 0.3678707595, 0.3619515135, 0.3560531384, 0.3501765262, 0.3443225653, 0.3384921406, 0.3326861337, 0.3269054224, 0.3211508806, 0.3154233783, 0.3097237815, 0.3040529519, 0.2984117468, 0.2928010190, 0.2872216169, 0.2816743840, 0.2761601590, 0.2706797754, 0.2652340619, 0.2598238419, 0.2544499331, 0.2491131482, 0.2438142939, 0.2385541714, 0.2333335760, 0.2281532968, 0.2230141172, 0.2179168140, 0.2128621579, 0.2078509132, 0.2028838374, 0.1979616815, 0.1930851896, 0.1882550991, 0.1834721401, 0.1787370358, 0.1740505021, 0.1694132474, 0.1648259730, 0.1602893723, 0.1558041311, 0.1513709277, 0.1469904322, 0.1426633070, 0.1383902061, 0.1341717757, 0.1300086536, 0.1259014690, 0.1218508430, 0.1178573880, 0.1139217078, 0.1100443972, 0.1062260427, 0.1024672213, 0.0987685015, 0.0951304424, 0.0915535940, 0.0880384971, 0.0845856832, 0.0811956742, 0.0778689827, 0.0746061116, 0.0714075543, 0.0682737943, 0.0652053053, 0.0622025514, 0.0592659864, 0.0563960544, 0.0535931893, 0.0508578147, 0.0481903443, 0.0455911813, 0.0430607187, 0.0405993391, 0.0382074146, 0.0358853068, 0.0336333667, 0.0314519350, 0.0293413412, 0.0273019047, 0.0253339336, 0.0234377255, 0.0216135671, 0.0198617342, 0.0181824916, 0.0165760932, 0.0150427819, 0.0135827895, 0.0121963367, 0.0108836332, 0.0096448773, 0.0084802564, 0.0073899466, 0.0063741127, 0.0054329083, 0.0045664756, 0.0037749457, 0.0030584382, 0.0024170615, 0.0018509125, 0.0013600769, 0.0009446287, 0.0006046310, 0.0003401349, 0.0001511806, 0.0000377966, 0.0000000000 };
        private double window_size = 0;

        //variables for time related book-keeping
        private DispatcherTimer dataRateTimer = new DispatcherTimer(DispatcherPriority.Render);
        private DateTime referenceTime = DateTime.Now;

        // Timer used to updated the chart
        private DispatcherTimer chartUpdateTimer = new DispatcherTimer(DispatcherPriority.Render);

        public RealTimeSensorData()
        {
            nCycle = 0;
            this.ShowFFT = false;

            this.ShowBandPower = false;
            this.bandPowerBuffer = new double[sampleSizeSensorData];
            this.timeStampsChart1 = new DateTime[sampleSizeSensorData];
            this.dataBufferChart1 = new double[sampleSizeSensorData];
            //fft on last 256 data points
            this.fftLength = 512;
            this.rawDataArray = new Complex[fftLength];
            this.fftOutLength = this.fftLength / 2;
            this.fftBuffer = new double[fftOutLength];
            // Calculate total size of the window
            for (int i = 0; i < hann_window.Length; i++)
            {
                window_size += hann_window[i];
            }
            // Square the window_gain
            window_size = window_size * window_size;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            channelIndex = int.Parse(channel.Text);

            try
            {
                the_logger = new Nexus_Logger("COM3", channelIndex, "D:\\Research_Related\\v9_autoset_time_interval\\data_from_sensor\\data\\generated_data.txt"); // Create the Nexus Logger, access via COM11, write data to SenseLog.txt
            }
            catch (Exception err)
            {
                MessageBox.Show("Failed Initialization: " + err.Message);
                System.Windows.Application.Current.Shutdown();
            }

            the_logger.start_sensing();
            // Set the interval rate
            int intervalRate = 200 / Nexus_Logger.nSamples;
            dataRate.Text = intervalRate.ToString();
            samplePeriod.Text = intervalRate.ToString();

            // Data generation rate
            dataRateTimer.Interval = new TimeSpan(0, 0, 0, 0, intervalRate);
            dataRateTimer.Tick += dataRateTimer_Tick;

            // Chart update rate, which can be different from the data generation rate.
            chartUpdateTimer.Interval = new TimeSpan(0, 0, 0, 0, intervalRate);
            chartUpdateTimer.Tick += chartUpdateTimer_Tick;

            // Initialize data buffer to no data.
            for (int i = 0; i < timeStampsChart1.Length; ++i)
                timeStampsChart1[i] = DateTime.MinValue;

            // Enable RunPB button
            runPB.IsChecked = true;

            // Now can start the timers for data collection and chart update
            dataRateTimer.Start();
            chartUpdateTimer.Start();
        }

        //
        // The data update routine.
        //
        private void dataRateTimer_Tick(object sender, EventArgs e)
        {
            SensorData sensorData;
            bool successful = Nexus_Logger.queueSensorData.TryDequeue(out sensorData);
            while (successful)
            {
                double time = calculateTime((nCycle * 255) + sensorData.seqNum, sensorData.index, Nexus_Logger.nSamples, 200.0);
                // After obtaining the new values, we need to update the data arrays.
                shiftData(dataBufferChart1, sensorData.data);
                shiftData(timeStampsChart1, referenceTime.AddMilliseconds(time));

                if (sensorData.seqNum == 255 && sensorData.index == Nexus_Logger.nSamples - 1)
                {
                    nCycle++;
                }

                successful = Nexus_Logger.queueSensorData.TryDequeue(out sensorData);
            }
            valueA.Content = dataBufferChart1[dataBufferChart1.Length - 1].ToString(".##");

            //calculate band power if required
            if (this.ShowBandPower)
            {
                shiftData(this.bandPowerBuffer, calculateBandPower());
            }
        }

        private double calculateBandPower() {
            //int sampleFreq = (Nexus_Logger.nSamples == 40) ? 200 : 422;
            int sampleFreq = 200;
            float maxFreq = (((float)sampleFreq/2) * (this.fftOutLength - 1)) / this.fftOutLength;
            float minFreq = 0;

            // Power Estimate Bounds
            float binSize = (float) sampleFreq / this.fftLength;     
            int powerUpperBound = (int)(maxFreq / binSize);           
            int powerLowerBound = (int)(minFreq / binSize);          

            // Sum all power between selected bounds
            double sum = 0;
            double[] fftBuffer = computeFFT(this.fftLength, this.fftOutLength);
            for (int i = powerLowerBound; i < powerUpperBound; i++)
                sum += fftBuffer[i];

            return sum;
        }

        public double calculateTime (int seqNum, int index, int nSamplesPerSequence, double timePeriod)
        {
            return ((double)seqNum + ((double)index / (double)nSamplesPerSequence)) * timePeriod;
        }

        /*
         * Compute normalized FFT
         * First Parameter: Number of points to consider from data buffer
         * Second Parameter: Number of points in output fft array
         */
        public double[] computeNormalizedFFT(int fftLength, int fftOutLength)
        {
            double[] fft = new double[fftOutLength];
            // Load data into buffer and subtract the mean
            double mean = 0;
            for (int index = 0; index < fftLength; index++)
            {
                // Get the data from theDevice
                mean += this.dataBufferChart1[this.dataBufferChart1.Length - fftLength + index];
            }
            mean = mean / fftLength;

            // Move the latest data minus the mean times the hanning window
            for (int data_index = 0; data_index < fftLength; data_index++)
            {
                this.rawDataArray[data_index] = new Complex((this.dataBufferChart1[this.dataBufferChart1.Length - fftLength + data_index] - mean) * hann_window[data_index], 0);
            }
            
            Fourier.Forward(this.rawDataArray);

            for (int i = 0; i < fftOutLength; i++)
            {
                fft[i] = this.rawDataArray[i].Magnitude / window_size;
            }
            return fft;
        }

        /*
 * Compute normalized FFT
 * First Parameter: Number of points to consider from data buffer
 * Second Parameter: Number of points in output fft array
 */
        public double[] computeFFT(int fftLength, int fftOutLength)
        {
            double[] fft = new double[fftOutLength];
            // Load data into buffer and subtract the mean
            double mean = 0;
            for (int index = 0; index < fftLength; index++)
            {
                // Get the data from theDevice
                mean += this.dataBufferChart1[this.dataBufferChart1.Length - fftLength + index];
            }
            mean = mean / fftLength;

            // Move the latest data minus the mean times the hanning window
            for (int data_index = 0; data_index < fftLength; data_index++)
            {
                this.rawDataArray[data_index] = new Complex((this.dataBufferChart1[this.dataBufferChart1.Length - fftLength + data_index] - mean) * hann_window[data_index], 0);
            }

            Fourier.Forward(this.rawDataArray);

            for (int i = 0; i < fftOutLength; i++)
            {
                fft[i] = this.rawDataArray[i].Magnitude;
            }
            return fft;
        }

        //
        // Utility to shift a double value into an array

        //
        private void shiftData(double[] data, double newValue)
        {
            for (int i = 1; i < data.Length; ++i)
                data[i - 1] = data[i];
            data[data.Length - 1] = newValue;
        }

        //
        // Utility to shift a DataTime value into an array
        //
        private void shiftData(DateTime[] data, DateTime newValue)
        {
            for (int i = 1; i < data.Length; ++i)
                data[i - 1] = data[i];
            data[data.Length - 1] = newValue;
        }

        //
        // Enable/disable chart update based on the state of the Run button.
        //
        private void runPB_CheckedChanged(object sender, RoutedEventArgs e)
        {
            chartUpdateTimer.IsEnabled = runPB.IsChecked == true;
        }

        private void FFTPB_Click(object sender, RoutedEventArgs e)
        {
            if (this.ShowFFT)
            {
                this.ShowFFT = false;
                Array.Clear(this.fftBuffer, 0, this.fftBuffer.Length);
            }
            else
            {
                this.ShowFFT = true;
            }
        }

        private void BandPowerPB_Click(object sender, RoutedEventArgs e)
        {
            if (this.ShowBandPower)
            {
                this.ShowBandPower = false;
                Array.Clear(this.bandPowerBuffer, 0, this.bandPowerBuffer.Length);
            }
            else
            {
                this.ShowBandPower = true;
            }
        }

        //
        // Updates the chartUpdateTimer interval if the user selects another interval.
        //

        private void samplePeriod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedText = (samplePeriod.SelectedValue as ComboBoxItem).Content as string;
            if (!string.IsNullOrEmpty(selectedText))
                chartUpdateTimer.Interval = new TimeSpan(0, 0, 0, 0, int.Parse(selectedText));
        }

        private void channel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedText = (channel.SelectedValue as ComboBoxItem).Content as string;
            if (!string.IsNullOrEmpty(selectedText))
            {
                this.the_logger.clearQueue();
                this.clearBuffers();
                this.the_logger.setChannel(int.Parse(selectedText));
            }
        }

        private void clearBuffers()
        {
            this.timeStampsChart1 = new DateTime[sampleSizeSensorData];
            this.dataBufferChart1 = new double[sampleSizeSensorData];
            this.rawDataArray = new Complex[this.fftLength];
            this.fftBuffer = new double[this.fftOutLength];
        }

        private void dataRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedText = (dataRate.SelectedValue as ComboBoxItem).Content as string;
            if (!string.IsNullOrEmpty(selectedText))
                dataRateTimer.Interval = new TimeSpan(0, 0, 0, 0, int.Parse(selectedText));
        }

        //
        // The chartUpdateTimer Tick event - this updates the chart periodicially by raising
        // viewPortChanged events.
        //
        private void chartUpdateTimer_Tick(object sender, EventArgs e)
        {
            WPFChartViewer1.updateViewPort(true, false);
            WPFChartViewer2.updateViewPort(true, false);
        }

        //
        // The viewPortChanged event handler.
        //
        private void WPFChartViewer1_ViewPortChanged(object sender, WPFViewPortEventArgs e)
        {
            drawChart1(sender as WPFChartViewer);
        }

        //
        // The viewPortChanged event handler.
        //
        private void WPFChartViewer2_ViewPortChanged(object sender, WPFViewPortEventArgs e)
        {
            drawChart2(sender as WPFChartViewer);
        }

        //
        // Draw the chart and display it in the given viewer.
        //
        private void drawChart1(WPFChartViewer viewer)
        {
            // Create an XYChart object 600 x 270 pixels in size, with light grey (f4f4f4) 
            // background, black (000000) border, 1 pixel raised effect, and with a rounded frame.
            XYChart c = new XYChart(600, 270, 0xf4f4f4, 0x000000, 1);
            c.setRoundedFrame(0xffffff);

            // Set the plotarea at (55, 62) and of size 520 x 175 pixels. Use white (ffffff) 
            // background. Enable both horizontal and vertical grids by setting their colors to 
            // grey (cccccc). Set clipping mode to clip the data lines to the plot area.
            c.setPlotArea(55, 62, 520, 175, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
            c.setClipping();

            // Add a title to the chart using 15 pts Times New Roman Bold Italic font, with a light
            // grey (dddddd) background, black (000000) border, and a glass like raised effect.
            c.addTitle("Sensor Data", "Times New Roman Bold Italic", 15
                ).setBackground(0xdddddd, 0x000000, Chart.glassEffect());

            // Add a legend box at the top of the plot area with 9pts Arial Bold font. We set the 
            // legend box to the same width as the plot area and use grid layout (as opposed to 
            // flow or top/down layout). This distributes the 3 legend icons evenly on top of the 
            // plot area.
            LegendBox b = c.addLegend2(55, 33, 1, "Arial Bold", 9);
            b.setBackground(Chart.Transparent, Chart.Transparent);
            b.setWidth(520);

            // Configure the y-axis with a 10pts Arial Bold axis title
            c.yAxis().setTitle("Amplitude", "Arial Bold", 10);

            // Configure the x-axis to auto-scale with at least 75 pixels between major tick and 15 
            // pixels between minor ticks. This shows more minor grid lines on the chart.
            c.xAxis().setTickDensity(75, 15);

            // Set the axes width to 2 pixels
            c.xAxis().setWidth(2);
            c.yAxis().setWidth(2);

            // Now we add the data to the chart
            DateTime lastTime = timeStampsChart1[timeStampsChart1.Length - 1];
            if (lastTime != DateTime.MinValue)
            {
                // Set up the x-axis scale. In this demo, we set the x-axis to show the last 240 
                // samples, with 250ms per sample.
                c.xAxis().setDateScale(lastTime.AddMilliseconds(
                    -dataRateTimer.Interval.TotalMilliseconds * this.fftLength), lastTime);
                //c.xAxis().setDateScale(timeStampsChart1[0], lastTime);
                //c.yAxis().setDateScale(this.minVal - (this.maxVal - this.minVal)/10.0, this.maxVal + (this.maxVal - this.minVal)/10.0);

                // Set the x-axis label format
                c.xAxis().setLabelFormat("{value|hh:nn:ss}");

                // Create a line layer to plot the lines
                LineLayer layer = c.addLineLayer2();

                // The x-coordinates are the timeStamps.
                layer.setXData(timeStampsChart1);

                // Add the dataset to the layer
                layer.addDataSet(dataBufferChart1, 0xff0000);
                if (this.ShowBandPower)
                {
                    layer.addDataSet(this.bandPowerBuffer, 0x00cc00, "Band Power: <*bgColor=CCFFCC*>" + 
                        c.formatValue(this.bandPowerBuffer[this.bandPowerBuffer.Length - 1], " {value|2} "));
                }
            }

            // Assign the chart to the WinChartViewer
            viewer.Chart = c;
        }

        //
        // Draw the chart and display it in the given viewer.
        //
        private void drawChart2(WPFChartViewer viewer)
        {
            // Create an XYChart object 600 x 270 pixels in size, with light grey (f4f4f4) 
            // background, black (000000) border, 1 pixel raised effect, and with a rounded frame.
            XYChart c = new XYChart(600, 270, 0xf4f4f4, 0x000000, 1);
            c.setRoundedFrame(0xffffff);

            // Set the plotarea at (55, 62) and of size 520 x 175 pixels. Use white (ffffff) 
            // background. Enable both horizontal and vertical grids by setting their colors to 
            // grey (cccccc). Set clipping mode to clip the data lines to the plot area.
            c.setPlotArea(55, 62, 520, 175, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
            c.setClipping();

            // Add a title to the chart using 15 pts Times New Roman Bold Italic font, with a light
            // grey (dddddd) background, black (000000) border, and a glass like raised effect.
            c.addTitle("Fast Fourier Transform", "Times New Roman Bold Italic", 15
                ).setBackground(0xdddddd, 0x000000, Chart.glassEffect());

            // Add a legend box at the top of the plot area with 9pts Arial Bold font. We set the 
            // legend box to the same width as the plot area and use grid layout (as opposed to 
            // flow or top/down layout). This distributes the 3 legend icons evenly on top of the 
            // plot area.
            LegendBox b = c.addLegend2(55, 33, 1, "Arial Bold", 9);
            b.setBackground(Chart.Transparent, Chart.Transparent);
            b.setWidth(520);

            // Configure the y-axis with a 10pts Arial Bold axis title
            c.yAxis().setTitle("Magnitude", "Arial Bold", 10);

            // Configure the x-axis to auto-scale with at least 75 pixels between major tick and 15 
            // pixels between minor ticks. This shows more minor grid lines on the chart.
            c.xAxis().setTickDensity(75, 15);

            // Set the axes width to 2 pixels
            c.xAxis().setWidth(2);
            c.yAxis().setWidth(2);

           // c.yAxis().setDateScale(0, 600);

            // Set the x-axis label format
            //c.xAxis().setLabelFormat("{0:0.##}");

            // Create a line layer to plot the lines
            LineLayer layer = c.addLineLayer2();

            // Perform FFT if the option is chosen
            if (this.ShowFFT)
            {
                this.fftBuffer = this.computeNormalizedFFT(this.fftLength, this.fftOutLength);
            }
            // Add data to the layer
            layer.addDataSet(this.fftBuffer, 0xff0000);
            // Assign the chart to the WinChartViewer
            viewer.Chart = c;
        }

        private void QuitPB_Click(object sender, RoutedEventArgs e)
        {
            the_logger.dispose();
            System.Windows.Application.Current.Shutdown();
        }
    }
}

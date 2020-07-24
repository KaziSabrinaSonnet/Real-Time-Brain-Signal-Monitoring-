namespace CSharpWPFCharts
{
    class SensorData
    {
        public double data { get; set; }
        public int seqNum { get; set; }
        public int index { get; set; }

        public SensorData(double data, int seqNum, int index)
        {
            this.data = data;
            this.seqNum = seqNum;
            this.index = index;
        }
    }
}

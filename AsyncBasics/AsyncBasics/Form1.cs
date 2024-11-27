namespace AsyncBasics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        Thread counter;
        private void button1_Click(object sender, EventArgs e)
        {
            counter = new Thread(Count);
            counter.Start();
            MessageBox.Show("sayım bitti");
        }

        void Count()
        {
            for (int i = 0; i < 100000; i++)
            {
                label1.Text = i.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             tcounter();

            MessageBox.Show("sayım bitti");
        }

        async Task tcounter()
        {
            for (int i = 0; i < 10000; i++)
            {
                label2.Text = i.ToString();
            }
            await Task.CompletedTask;
        }
    }
}

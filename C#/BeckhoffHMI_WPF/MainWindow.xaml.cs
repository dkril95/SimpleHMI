using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TwinCAT.Ads;

namespace BeckhoffHMI_WPF
{
    public partial class MainWindow : Window
    {
        private AdsClient? adsClient;
        private uint handleCounter;
        private uint handleTemp;
        private uint handleIncrease;
        private bool isConnected = false;
        private CancellationTokenSource? cancelToken;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                try
                {
                    adsClient = new AdsClient();
                    adsClient.Connect("127.0.0.1.1.1", 851);

                    handleCounter = adsClient.CreateVariableHandle("MAIN.iCounter");
                    handleTemp = adsClient.CreateVariableHandle("MAIN.rTemperature");
                    handleIncrease = adsClient.CreateVariableHandle("MAIN.bIncrease");

                    isConnected = true;
                    StatusLed.Fill = Brushes.LimeGreen;
                    BtnConnect.Content = "Disconnect";
                    cancelToken = new CancellationTokenSource();

                    _ = Task.Run(() => RefreshLoop(cancelToken.Token));
                    MessageBox.Show("✅ Connected to PLC!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ No connection: " + ex.Message);
                }
            }
            else
            {
                cancelToken.Cancel();
                adsClient.Dispose();
                isConnected = false;
                StatusLed.Fill = Brushes.Red;
                BtnConnect.Content = "Connect to PLC";
                LblCounter.Text = "Counter: ---";
                LblTemperature.Text = "Temperature: --- °C";
            }
        }

        private async Task RefreshLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    uint valCounter = (uint)adsClient.ReadAny(handleCounter, typeof(uint));
                    float valTemp = (float)adsClient.ReadAny(handleTemp, typeof(float));

                    Dispatcher.Invoke(() =>
                    {
                        LblCounter.Text = $"Counter: {valCounter}";
                        LblTemperature.Text = $"Temperature: {valTemp:F2} °C";
                    });
                }
                catch { }

                await Task.Delay(500, token);
            }
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                adsClient.WriteAny(handleIncrease, true);
            }
            else
            {
                MessageBox.Show("⚠️No connection with PLC.");
            }
        }
    }
}
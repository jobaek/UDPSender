# UDPSender
UDP Sender program with us delay function


#Using stopwatch function from System.Diagnostics

static void udelay(long us)
{

    var sw = System.Diagnostics.Stopwatch.StartNew();
    long v = (us * System.Diagnostics.Stopwatch.Frequency) / 1000000;
    while (sw.ElapsedTicks < v)
    {
    }
}


#Sample Test Code

for(int idx=0; idx<listBox1.Items.Count; idx++)
{

    string strData = listBox1.Items[idx].ToString();
    
    Byte[] sendBytes = CreateSpecialByteArray(strData, strData.Length);

    udpClient.Send(sendBytes, sendBytes.Length);
    udelay(interval);
}

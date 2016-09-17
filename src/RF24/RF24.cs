using System;
using System.Runtime.InteropServices;
using RF24N = Y56380X.RF24.RF24.NativeMethods;

namespace Y56380X.RF24
{
	public class RF24
	{
		#region Nested Classes / Enums

		internal static class NativeMethods
		{
			[DllImport("rf24wrapper")]
			public static extern IntPtr Create(byte cepin, byte cspin, int spi_speed);

			[DllImport("rf24wrapper")]
			public static extern void Delete(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void Begin(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void SetAutoAck(IntPtr rf24, bool autoAck);

			[DllImport("rf24wrapper")]
			public static extern void StartListening(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void StopListening(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void SetChannel(IntPtr rf24, byte channel);

			[DllImport("rf24wrapper")]
			public static extern bool TestCarrier(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void PrintDetails(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern byte GetChannel(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern bool SetDataRate(IntPtr rf24, byte dataRate);

			[DllImport("rf24wrapper")]
			public static extern byte GetDataRate(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void SetPALevel(IntPtr rf24, byte paLevel);

			[DllImport("rf24wrapper")]
			public static extern byte GetPALevel(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern bool Available(IntPtr rf24, ref byte pipeNumber);

			[DllImport("rf24wrapper")]
			public static extern bool Available(IntPtr rf24, IntPtr pipeNumber);

			[DllImport("rf24wrapper")]
			public static extern void OpenWritingPipe(IntPtr rf24, byte[] address);

			[DllImport("rf24wrapper")]
			public static extern void OpenReadingPipe(IntPtr rf24, byte number, byte[] address);

			[DllImport("rf24wrapper")]
			public static extern void CloseReadingPipe(IntPtr rf24, byte pipe);

			[DllImport("rf24wrapper")]
			public static extern void EnableDynamicPayloads(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern byte GetDynamicPayloadSize(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void SetCRCLength(IntPtr rf24, byte length);

			[DllImport("rf24wrapper")]
			public static extern byte GetCRCLength(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void Read(IntPtr rf24, byte[] buffer, byte length);

			[DllImport("rf24wrapper")]
			public static extern bool Write(IntPtr rf24, byte[] buffer, byte length);

			[DllImport("rf24wrapper")]
			public static extern void PowerUp(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void PowerDown(IntPtr rf24);

			[DllImport("rf24wrapper")]
			public static extern void SetRetries(IntPtr rf24, byte delay, byte count);
		}

		public enum PALevel : byte
		{
			Min,
			Low,
			High,
			Max,
			Error
		}

		public enum DataRate : byte
		{
			Normal,
			Fast,
			Slow
		}

		public enum CRC : byte
		{
			Disabled,
			CRC8,
			CRC16
		}

		#endregion

		#region Fields

		private readonly IntPtr rf24Handle;

		#endregion

		#region Constructors

		public RF24(byte cePin, byte csPin, int spiSpeed)
		{
			rf24Handle = RF24N.Create(cePin, csPin, spiSpeed);
		}

		#endregion

		#region Methods

		public void Begin()
		{
			RF24N.Begin(rf24Handle);
		}

		public void SetAutoAck(bool autoAck)
		{
			RF24N.SetAutoAck(rf24Handle, autoAck);
		}

		public void StartListening()
		{
			RF24N.StartListening(rf24Handle);
		}

		public void StopListening()
		{
			RF24N.StopListening(rf24Handle);
		}

		public void SetChannel(byte channel)
		{
			RF24N.SetChannel(rf24Handle, channel);
		}

		public byte GetChannel()
		{
			return RF24N.GetChannel(rf24Handle);
		}

		public bool TestCarrier()
		{
			return RF24N.TestCarrier(rf24Handle);
		}

		public void PrintDetails()
		{
			RF24N.PrintDetails(rf24Handle);
		}

		public bool SetDataRate(DataRate dataRate)
		{
			return RF24N.SetDataRate(rf24Handle, (byte)dataRate);
		}

		public DataRate GetDataRate()
		{
			return (DataRate)RF24N.GetDataRate(rf24Handle);
		}

		public void SetPALevel(PALevel paLevel)
		{
			RF24N.SetPALevel(rf24Handle, (byte)paLevel);
		}

		public PALevel GetPALevel()
		{
			return (PALevel)RF24N.GetPALevel(rf24Handle);
		}

		public bool Available()
		{
			return RF24N.Available(rf24Handle, IntPtr.Zero);
		}

		public bool Available(byte pipeNumber)
		{
			return RF24N.Available(rf24Handle, ref pipeNumber);
		}

		public void OpenWritingPipe(byte[] address)
		{
			RF24N.OpenWritingPipe(rf24Handle, address);
		}

		public void OpenReadingPipe(byte number, byte[] address)
		{
			RF24N.OpenReadingPipe(rf24Handle, number, address);
		}

		public void CloseReadingPipe(byte number)
		{
			RF24N.CloseReadingPipe(rf24Handle, number);
		}

		public void EnableDynamicPayloads()
		{
			RF24N.EnableDynamicPayloads(rf24Handle);
		}

		public byte GetDynamicPayloadSize()
		{
			return RF24N.GetDynamicPayloadSize(rf24Handle);
		}

		public void SetCRCLength(CRC crc)
		{
			RF24N.SetCRCLength(rf24Handle, (byte)crc);
		}

		public CRC GetCRCLength()
		{
			return (CRC)RF24N.GetCRCLength(rf24Handle);
		}

		public void Read(byte[] buffer, byte length)
		{
			RF24N.Read(rf24Handle, buffer, length);
		}

		public void Read(byte[] buffer)
		{
			RF24N.Read(rf24Handle, buffer, (byte)buffer.Length);
		}

		public bool Write(byte[] buffer, byte length)
		{
			return RF24N.Write(rf24Handle, buffer, length);
		}

		public bool Write(byte[] buffer)
		{
			return RF24N.Write(rf24Handle, buffer, (byte)buffer.Length);
		}

		public void PowerUp()
		{
			RF24N.PowerUp(rf24Handle);
		}

		public void PowerDown()
		{
			RF24N.PowerDown(rf24Handle);
		}

		public void SetRetries(byte delay, byte count)
		{
			RF24N.SetRetries(rf24Handle, delay, count);
		}

		#endregion

		~RF24()
		{
			RF24N.Delete(rf24Handle);
		}
	}
}
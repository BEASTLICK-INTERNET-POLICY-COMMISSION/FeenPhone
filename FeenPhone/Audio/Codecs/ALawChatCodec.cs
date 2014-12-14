﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using NAudio.Codecs;
using System.ComponentModel.Composition;

namespace FeenPhone.Audio.Codecs
{
    class AcmALawChatCodec : AcmChatCodec
    {
        public override CodecID CodecID { get { return CodecID.AcmALawChatCodec; } }

        public AcmALawChatCodec()
            : base(new WaveFormat(8000, 16, 1), WaveFormat.CreateALawFormat(8000, 1))
        {
        }

        public override string Name
        {
            get { return "ACM G.711 a-law"; }
        }
    }


    [Export(typeof(INetworkChatCodec))]
    class ALawChatCodec : INetworkChatCodec
    {
        public CodecID CodecID { get { return CodecID.ALawChatCodec; } }

        public string Name
        {
            get { return "G.711 a-law"; }
        }

        public int BitsPerSecond
        {
            get { return RecordFormat.SampleRate * 8; }
        }

        public WaveFormat RecordFormat
        {
            get { return new WaveFormat(8000, 16, 1); }
        }

        public byte[] Encode(byte[] data, int length)
        {
            return Encode(data, 0, length);
        }

        public byte[] Encode(byte[] data, int offset, int length)
        {
            byte[] encoded = new byte[length / 2];
            int outIndex = 0;
            for (int n = 0; n < length; n += 2)
            {
                encoded[outIndex++] = ALawEncoder.LinearToALawSample(BitConverter.ToInt16(data, offset + n));
            }
            return encoded;
        }

        public byte[] Decode(byte[] data, int length)
        {
            return Decode(data, 0, length);
        }

        public byte[] Decode(byte[] data, int offset, int length)
        {
            byte[] decoded = new byte[length * 2];
            int outIndex = 0;
            for (int n = 0; n < length; n++)
            {
                short decodedSample = ALawDecoder.ALawToLinearSample(data[n + offset]);
                decoded[outIndex++] = (byte)(decodedSample & 0xFF);
                decoded[outIndex++] = (byte)(decodedSample >> 8);
            }
            return decoded;
        }

        public void Dispose()
        {
            // nothing to do
        }

        public bool IsAvailable { get { return false; } }
    }
}

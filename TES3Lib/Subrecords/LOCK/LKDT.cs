﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.LOCK
{
    /// <summary>
    /// Lockpick item details
    /// </summary>
    public class LKDT : Subrecord
    {
        public float Weight { get; set; }

        public int Value { get; set; }

        public int Uses { get; set; }

        public float Quality { get; set; }

        public LKDT()
        {
        }

        public LKDT(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Weight = reader.ReadBytes<float>(Data);
            Value = reader.ReadBytes<int>(Data);
            Uses = reader.ReadBytes<int>(Data);
            Quality = reader.ReadBytes<float>(Data);
        }
    }
}

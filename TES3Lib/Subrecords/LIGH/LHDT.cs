﻿using System.Collections.Generic;
using TES3Lib.Base;
using TES3Lib.Enums.Flags;
using Utility;

namespace TES3Lib.Subrecords.LIGH
{
    public class LHDT : Subrecord
    {
        public float Weight { get; set; }

        public int Value { get; set; }

        public int Time { get; set; }

        public int Radius { get; set; }

        /// <summary>
        /// RGB 1 byte per color with 4th unknown
        /// </summary>
        public int Color { get; set; }

        public HashSet<LightFlag> Flags { get; set; }

        public LHDT()
        {
        }

        public LHDT(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Weight = reader.ReadBytes<float>(Data);
            Value = reader.ReadBytes<int>(Data);
            Time = reader.ReadBytes<int>(Data);
            Radius = reader.ReadBytes<int>(Data);
            Color = reader.ReadBytes<int>(Data);
            Flags = reader.ReadFlagBytes<LightFlag>(Data);
        }
    }
}
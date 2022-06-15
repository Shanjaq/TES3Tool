﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.REFR
{
    public class INTV : Subrecord
    {
        public int NumberOfUses { get; set; }

        public INTV()
        {

        }

        public INTV(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            NumberOfUses = reader.ReadBytes<int>(Data);
        }
    }
}
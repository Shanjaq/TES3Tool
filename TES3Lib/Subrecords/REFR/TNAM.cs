﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.REFR
{
    public class TNAM : Subrecord
    {
        public string TrapName { get; set; }

        public TNAM()
        {

        }

        public TNAM(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            TrapName = reader.ReadBytes<string>(Data, Size);
        }
    }
}

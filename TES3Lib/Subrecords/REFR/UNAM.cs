﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.REFR
{
    public class UNAM : Subrecord
    {
        public byte ReferenceBlocked { get; set; }

        public UNAM()
        {

        }

        public UNAM(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            ReferenceBlocked = reader.ReadBytes<byte[]>(Data, Size)[0];
        }
    }
}

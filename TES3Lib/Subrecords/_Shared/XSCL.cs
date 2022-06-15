﻿using System.Diagnostics;
using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.Shared
{
    /// <summary>
    /// Scale (4 bytes, float, optional)
    /// Only present if the scale is not 1.0	
    /// </summary>
    [DebuggerDisplay("{Scale}")]
    public class XSCL : Subrecord
    {
        public float Scale { get; set; }

        public XSCL()
        {
        }

        public XSCL(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Scale = reader.ReadBytes<float>(Data);
        }
    }
}

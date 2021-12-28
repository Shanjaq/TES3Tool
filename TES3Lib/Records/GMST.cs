﻿using System.Diagnostics;
using TES3Lib.Base;
using TES3Lib.Subrecords.GMTS;
using TES3Lib.Subrecords.Shared;

namespace TES3Lib.Records
{
    /// <summary>
    /// Game settings Record
    /// </summary>
    [DebuggerDisplay("{NAME.EditorId}")]
    public class GMST : Record
    {
        /// <summary>
        /// EditorId
        /// </summary>
        public NAME NAME { get; set; }

        /// <summary>
        /// String value
        /// </summary>
        public STRV STRV { get; set; }

        /// <summary>
        /// Integer value
        /// </summary>
        public INTV INTV { get; set; }

        /// <summary>
        /// Float value
        /// </summary>
        public FLTV FLTV { get; set; }

        public GMST()
        {
        }

        public GMST(byte[] rawData) : base(rawData)
        {
            BuildSubrecords();
        }
    }
}

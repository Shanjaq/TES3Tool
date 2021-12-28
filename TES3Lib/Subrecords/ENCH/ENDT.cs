﻿using TES3Lib.Base;
using TES3Lib.Enums;
using TES3Lib.Enums.Flags;
using Utility;

namespace TES3Lib.Subrecords.ENCH
{
    /// <summary>
    /// Enchantment data
    /// </summary>
    public class ENDT : Subrecord
    {
        public EnchantmentType Type { get; set; }

        public int EnchantCost { get; set; }

        public int Charge { get; set; }

        public AutoCalculateFlag AutoCalculate { get; set; }

        public ENDT()
        {
        }

        public ENDT(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Type = reader.ReadBytes<EnchantmentType>(base.Data);
            EnchantCost = reader.ReadBytes<int>(base.Data);
            Charge = reader.ReadBytes<int>(base.Data);
            AutoCalculate = reader.ReadBytes<AutoCalculateFlag>(base.Data);
        }
    }
}

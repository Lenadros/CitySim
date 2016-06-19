using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitySim
{
    class BlockKit
    {
        public int mMineral;

        public BlockKit(int pMineral)
        {
            mMineral = pMineral;
        }
    }

    class Grass_Block : BlockKit
    {
        public int mFertile;

        public Grass_Block(int pMineral, int pFertile)
            : base(pMineral)
        {
            mFertile = pFertile;
        }
    }
}

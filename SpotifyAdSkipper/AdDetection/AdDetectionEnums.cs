﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAdSkipper.AdDetection
{
    public enum MatchStrength
    {
        Exact,
        Contains
    }

    public enum AudioProperty
    {
        Title,
        Album,
        Artist
    }
}

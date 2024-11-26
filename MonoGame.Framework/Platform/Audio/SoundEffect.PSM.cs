// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.
﻿
using System;
using System.Collections.Generic;
using System.IO;

using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

using Sce.PlayStation.Core.Audio;

namespace Microsoft.Xna.Framework.Audio
{
    public sealed partial class SoundEffect : IDisposable
    {
        internal const int MAX_PLAYING_INSTANCES = 128;

        private Sound _audioBuffer;
        private SoundEffectInstance _instance;

        internal static void PlatformInitialize()
        {
        }
        
        private void PlatformLoadAudioStream(Stream s, out TimeSpan duration)
        {
            var data = new byte[s.Length];
            s.Read(data, 0, (int)s.Length);
            
            _audioBuffer = new Sound(data);
            var soundPlayer = _audioBuffer.CreatePlayer();
            duration = new TimeSpan((long)(soundPlayer.Duration * 10000000));
            soundPlayer.Dispose();
        }

        private void PlatformInitializePcm(byte[] buffer, int offset, int count, int sampleBits, int sampleRate, AudioChannels channels, int loopStart, int loopLength)
        {
            _name = "";
            
            _audioBuffer = new Sound(AudioUtil.FormatWavData(buffer, sampleRate, (int)channels));
        }

        private void PlatformInitializeFormat(byte[] header, byte[] buffer, int bufferSize, int loopStart, int loopLength)
        {
            _name = "";

#warning Fixme: wrong
            _audioBuffer = new Sound(buffer);
        }

        private void PlatformInitializeXact(MiniFormatTag codec, byte[] buffer, int channels, int sampleRate, int blockAlignment, int loopStart, int loopLength, out TimeSpan duration)
        {
            throw new NotSupportedException("Unsupported sound format!");
        }

        private void PlatformSetupInstance(SoundEffectInstance inst)
        {   
            inst._audioBuffer = _audioBuffer;
            inst._soundPlayer = _audioBuffer.CreatePlayer();
        }

        internal static void PlatformSetReverbSettings(ReverbSettings reverbSettings)
        {
        }

        private void PlatformDispose(bool disposing)
        {
            if (disposing)
            {
                if (_audioBuffer != null)
                    _audioBuffer.Dispose();
            }
            _audioBuffer = null;
        }

        internal static void PlatformShutdown()
        {
        }
    }
}

